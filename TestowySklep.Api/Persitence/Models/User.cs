namespace TestowySklep.Api.Persitence.Models;

public class User : BaseTrackingEntity
{
    public required string Email { get; set; }
    public int Age { get; set; }
    public bool IsMale { get; set; }
}