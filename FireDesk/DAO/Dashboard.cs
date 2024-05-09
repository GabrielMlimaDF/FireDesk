using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace FireDesk.DAO
{
    public class Dashboard
    {
        private readonly IConfiguration _configuration;

        public Dashboard(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}