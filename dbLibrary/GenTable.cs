using System;
using System.Collections.Generic;

namespace dbLibrary;

public partial class GenTable
{
    public int Id { get; set; }

    public string? Feedback { get; set; }

    public string? State { get; set; }

    public string? Length { get; set; }

    public string? SequenceLength { get; set; }

    public string? Sequence { get; set; }

    public DateTime? Date { get; set; }
}
