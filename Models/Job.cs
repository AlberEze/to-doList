using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Models;

public partial class Job
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(25)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("completed")]
    public int? Completed { get; set; }
}
