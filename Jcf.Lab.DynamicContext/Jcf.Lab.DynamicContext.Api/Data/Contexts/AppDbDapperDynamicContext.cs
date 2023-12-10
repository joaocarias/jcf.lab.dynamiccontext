using System.Data;

namespace Jcf.Lab.DynamicContext.Api.Data.Contexts
{
    public class AppDbDapperDynamicContext : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        public IConfiguration Configuration { get; }

        public AppDbDapperDynamicContext(IConfiguration configuration)
        {
            Configuration = configuration;

            Connection = new MySqlConnector.MySqlConnection(Configuration.GetConnectionString("DefaultConnection"));
            Connection.Open();
        }

        public AppDbDapperDynamicContext(string connectinString)
        { 
            Connection = new MySqlConnector.MySqlConnection(connectinString);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();       
    }
}
