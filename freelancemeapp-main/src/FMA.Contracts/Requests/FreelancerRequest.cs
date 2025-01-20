namespace FMA.Contracts.Requests;

public class FreelancerRequest
{
    public string Name { get; set; }
    public string ExpertiseName { get; set; }
    public double MaxHourlyRate { get; set; }
    public double MinRating { get; set; }
    public double MaxDistance { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}