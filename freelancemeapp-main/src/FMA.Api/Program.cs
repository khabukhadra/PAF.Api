using System.Security.AccessControl;
using System.Collections.Immutable;
using System.Text;
using System.Text.Json.Serialization;
using FMA.Application.Data;
using FMA.Application.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using FMA.Application.NewEntities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});
// builder.Services.AddDbContext<FreelancerContext>(options => 
// {
//     // options.UseNpgsql(builder.Configuration["ConnectionString"]);
//     options.UseSqlServer(builder.Configuration["ConnectionString"],
//         options => options.EnableRetryOnFailure());
// });


// builder.Services.AddDbContext<IdentityContext>(options => 
// {
//     // options.UseNpgsql(builder.Configuration["ConnectionString"]);
//     options.UseSqlServer(builder.Configuration["PAFConnectionString"],
//         options => options.EnableRetryOnFailure());
// });

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration["PAFConnectionString"], 
        sqlServerOptions => 
        {
            sqlServerOptions.CommandTimeout(300);
            sqlServerOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null
            );
        }
    )
);

builder.Services.AddDbContext<PingAFreelancerContext>(options =>
    options.UseSqlServer(builder.Configuration["PAFConnectionString"], 
        sqlServerOptions => 
        {
            sqlServerOptions.CommandTimeout(300);
            sqlServerOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null
            );
        }
    )
);
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<PingAFreelancerContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IFreelanceMeRepository, FreelanceMeRepository>();
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
    options.AddPolicy("corsPolicy", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin();
    }));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => 
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk"))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireClientRole", policy => policy.RequireRole("Client"));
    options.AddPolicy("CanPing", policy => policy.RequireClaim("CanPing", "true"));
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var identityContext = scope.ServiceProvider.GetRequiredService<IdentityContext>();

    // await identityContext.Database.MigrateAsync();

    var dbContext = scope.ServiceProvider.GetRequiredService<PingAFreelancerContext>();

    // await dbContext.Database.MigrateAsync();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    
    if (!await roleManager.RoleExistsAsync("Freelancer"))
    {
        await roleManager.CreateAsync(new IdentityRole("Freelancer"));
    }
    
    if (!await roleManager.RoleExistsAsync("Client"))
    {
        await roleManager.CreateAsync(new IdentityRole("Client"));
    }

    foreach (var freelancer in dbContext.Freelancers.Include(f => f.User).ToList())
    {
        var user = freelancer.User;
        if (!await userManager.IsInRoleAsync(user, "Freelancer"))
        {
            await userManager.AddToRoleAsync(user, "Freelancer");
        }
        if (!(await userManager.GetClaimsAsync(user)).Any(c => c.Type == "CanContract"))
        {
            await userManager.AddClaimAsync(user, new Claim("CanContract", "true"));
        }
    }
    foreach (var client in dbContext.Clients.Include(c => c.User).ToList())
    {
        var user = client.User;
        if (!await userManager.IsInRoleAsync(user, "Client"))
        {
            await userManager.AddToRoleAsync(user, "Client");
        }
        var clientClaims = new[] 
        {
            new Claim("CanPing", "true"),
            new Claim("CanEndContract", "true")
        };
        foreach (var claim in clientClaims)
        {
            if (!(await userManager.GetClaimsAsync(user)).Any(c => c.Type == claim.Type))
            {
                await userManager.AddClaimAsync(user, claim);
            }
        }
    }
}

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;

//     services.GetRequiredService<Pi

// }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => 
    builder.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin()
           .SetIsOriginAllowed(_ => true));

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


/*

# Pull the Azure SQL Edge image (compatible with ARM64)
docker pull mcr.microsoft.com/azure-sql-edge

# Create and run the container
docker run --name sql-server -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=Kanaan123!' -p 1433:1433 -d mcr.microsoft.com/azure-sql-edge --platform linux/arm64

# connStr
  "PAFConnectionString": "Server=localhost,1433;Database=pafdb;User Id=sa;Password=Kanaan123!;TrustServerCertificate=True"


docker run \
--name sql-server \
-e 'ACCEPT_EULA=Y' \
-e 'MSSQL_SA_PASSWORD=Kanaan123!' \
-e 'MSSQL_PID=Developer' \
-p 1433:1433 \
--platform linux/arm64 \
--cap-add SYS_PTRACE \
-m 2GB \
--restart unless-stopped \
-d mcr.microsoft.com/azure-sql-edge:latest

  dotnet ef migrations add InitialIdentity --context IdentityContext --project src/FMA.Application/ --startup-project src/FMA.Api
  dotnet ef migrations add InitialPing --context PingAFreelancerContext --project src/FMA.Application/ --startup-project src/FMA.Api


*/