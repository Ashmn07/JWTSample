using System;
using System.Collections.Generic;

namespace SampleJWTApp.Models;

public partial class CustomerLogin
{
    public string? Username { get; set; }

    public string? Pwd { get; set; }

    public int? IsEmployee { get; set; }
}
