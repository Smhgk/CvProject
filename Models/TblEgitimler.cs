using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CvProject.Models;

public partial class TblEgitimler
{
    public int Id { get; set; }

    public string? Baslik { get; set; }

    public string? AltBaslik1 { get; set; }

    public string? AltBaslik2 { get; set; }

    public string? Gpa { get; set; }

    public string? Tarih { get; set; }
}
