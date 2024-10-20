using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Models;

public partial class User
{
    [Key]
    [Column("username")]
    [StringLength(16)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(20)]
    [Unicode(false)]
    public string Password { get; set; } = null!;
}
