using System;
using System.Collections.Generic;

namespace PxcLesson10.Models;

public partial class PxcMember
{
    public long Id { get; set; }

    public string? PxcUserName { get; set; }

    public string? PxcPassword { get; set; }

    public string? PxcFullName { get; set; }

    public string? PxcEmail { get; set; }

    public string? PxcPhone { get; set; }

    public bool? PxcStatus { get; set; }
}
