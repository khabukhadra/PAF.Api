namespace FMA.Contracts.Responses;

public class ExpertiseResponse 
{
    public  int Id { get; set; }

    public string ExpertiseName { get; set; }

    public string PhotoPath { get; set; }

    public string BorderColor { get; set; }

    public FreelancersResponse Freelancers { get; set; } 
}
 