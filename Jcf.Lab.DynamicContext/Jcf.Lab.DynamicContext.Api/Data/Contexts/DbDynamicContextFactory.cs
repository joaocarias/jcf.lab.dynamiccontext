namespace Jcf.Lab.DynamicContext.Api.Data.Contexts
{
    public class DbDynamicContextFactory
    {
        public DbDynamicContext Create(string connectionString)
        {
            return new DbDynamicContext(connectionString);
        }
    }
}
