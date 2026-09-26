using System;
using System.Collections.Generic;

namespace PhungXuanCuong2410900014_exam.Models;

public partial class PxcEmployee
{
    public int Id { get; set; }

    public string PxcName { get; set; } = null!;

    public bool PxcGender { get; set; }

    public DateOnly? PxcBirthDay { get; set; }

    public string? PxcEmail { get; set; }

    public string? PxcPhone { get; set; }

    public bool PxcActive { get; set; }
}
