namespace DemoDapperPlus.Infrasctructure;

public static class EnviromentSettings
{
    public static string ConnectionString => Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION");
}
