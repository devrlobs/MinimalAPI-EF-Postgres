using System;
using System.Collections.Generic;

namespace MinimalAPI_EF_Postgres;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}
