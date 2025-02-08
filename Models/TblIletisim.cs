using System;
using System.Collections.Generic;

namespace CvProject.Models;

public partial class TblIletisim
{
    public int Id { get; set; }

    public string? Adsoyad { get; set; }

    public string? Mail { get; set; }

    public string? Konu { get; set; }

    public string? Mesaj { get; set; }

    public DateTime? Tarih { get; set; }
}
