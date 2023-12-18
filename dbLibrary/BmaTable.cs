using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace dbLibrary;

public partial class BmaTable
{
    public int Id { get; set; }

    public string? Data { get; set; }

    public string? Length { get; set; }

    public string? Feedback { get; set; }

    public string? State { get; set; }

    public string? Sequence { get; set; }

    public DateTime? Date { get; set; }
}
