using System;
using System.Collections.Generic;

namespace DPA.Practica0118101100.Core.Infrastructure.Data;

public partial class Carrera
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Estudiante> Estudiante { get; set; } = new List<Estudiante>();
}
