using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_2.Models;

[Table("tb_receitas")]
public class Receitas
{
    [Key]
    public long Id { get; set; }
    [Required]
    [StringLength(150, MinimumLength = 5, ErrorMessage = "A descricao deve ter entre 5 e 150 caracteres")]
    public string? Descricao { get; set; }
    [Required]
    [Range(0,100000, ErrorMessage = "O valor deve estar entre 0 e 100000")]
    public double Valor { get; set; }
    public DateTime Data { get; set; }
}
