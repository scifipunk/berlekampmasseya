using System;
using System.Collections.Generic;

namespace dbLibrary;

public partial class ExcepTable
{
    public int Id { get; set; }

    public string? Message { get; set; }

    public string? TargetSite { get; set; }

    public DateTime? DateTime { get; set; }

    public string? Form { get; set; }
}
