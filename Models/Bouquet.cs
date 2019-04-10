using System.ComponentModel.DataAnnotations;

namespace fullFlowershopServer.Models
{

  public class Bouquet
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
  }
}