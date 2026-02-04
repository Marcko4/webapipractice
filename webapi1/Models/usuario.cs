using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webapi1.Models;

[Table("usuario")]
public partial class usuario
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string nombre { get; set; } = null!;

    [StringLength(50)]
    public string apellido { get; set; } = null!;

    [StringLength(100)]
    public string? correo { get; set; }

    [StringLength(100)]
    public string? username { get; set; }

    public DateTime? fecha_creacion { get; set; }
}
