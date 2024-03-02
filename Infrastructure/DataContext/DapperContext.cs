using Npgsql;
namespace Infrastructure.DataContext;
public class DapperContext
{
    private readonly string _connectionString =
        "Host=localhost;Port=5432;Database=Exam;User Id=postgres;Password=2008;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
