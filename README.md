# MinimalAPI-EF-Postgres
a prototype project to connect ASP Minimal API with postgres using EF





dotnet-ef dbcontext scaffold "Host=localhost:15432;Database=postgres;Username=postgres;Password=test1234" -f Npgsql.EntityFrameworkCore.PostgreSQL

--no-onconfiguring



dotnet-ef dbcontext scaffold "Host=localhost:15432;Database=postgres;Username=postgres;Password=test1234" --no-onconfiguring -f Npgsql.EntityFrameworkCore.PostgreSQL