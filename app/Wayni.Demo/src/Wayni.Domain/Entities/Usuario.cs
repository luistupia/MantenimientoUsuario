using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wayni.Domain.Entities;

[Table("Usuario", Schema = "dbo")]
public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nombres { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string NumeroDocumento { get; set; } = null!;
    public string Avatar { get; set; } = null!;
}