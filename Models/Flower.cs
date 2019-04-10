using System.ComponentModel.DataAnnotations;

namespace fullFlowershopServer.Models
{

  public class Flower
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Color { get; set; }
  }
}