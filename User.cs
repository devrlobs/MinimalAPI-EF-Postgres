using System;
using System.Collections.Generic;

namespace MinimalAPI_EF_Postgres;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public int? Age { get; set; }
}
