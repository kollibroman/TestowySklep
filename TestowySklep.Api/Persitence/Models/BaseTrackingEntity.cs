using System.ComponentModel.DataAnnotations.Schema;

namespace TestowySklep.Api.Persitence.Models;

public class BaseTrackingEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Name { get; set; }
}