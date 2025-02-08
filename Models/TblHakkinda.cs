using System;
using System.Collections.Generic;

namespace CvProject.Models;

public partial class TblHakkinda
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public string? Adres { get; set; }

    public string? Telefon { get; set; }

    public string? Mail { get; set; }

    public string? Aciklama { get; set; }

    public string? Image { get; set; }
}
