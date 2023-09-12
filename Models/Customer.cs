using System;
using System.Collections.Generic;

namespace SampleJWTApp.Models;

public partial class Customer
{
    public int Cid { get; set; }

    public string? Cname { get; set; }

    public DateTime? Doj { get; set; }
}
