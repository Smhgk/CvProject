using System;
using System.Collections.Generic;

namespace CvProject.Models;

public partial class TblYetenekler
{
    public int Id { get; set; }

    public string? Yetenek { get; set; }

    public byte? Oran { get; set; }
}
