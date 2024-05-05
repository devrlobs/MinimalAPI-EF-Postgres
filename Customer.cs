using System;
using System.Collections.Generic;

namespace MinimalAPI_EF_Postgres;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
