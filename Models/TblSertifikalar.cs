using System;
using System.Collections.Generic;

namespace CvProject.Models;

public partial class TblSertifikalar
{
    public int Id { get; set; }

    public string? Aciklama { get; set; }

    public string? Tarih { get; set; }

    public string? Kaynak { get; set; }
}
