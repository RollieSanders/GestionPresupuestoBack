using System.Configuration;

namespace Repository
{
    public class DataAccess
    {
        public string ReturnConnectionString_Acceso()
        {

            var strConn = ConfigurationManager.ConnectionStrings["CONEXACCESO"].ConnectionString;

            return strConn;
        }

        public string ReturnConnectionString_Formulacion()
        {
            var strConn = ConfigurationManager.ConnectionStrings["CONEXPRESUPUESTO"].ConnectionString;

            return strConn;
        }

        public string ReturnConnectionString_Gestion()
        {
            var strConn = ConfigurationManager.ConnectionStrings["CONEXPRESUPUESTO"].ConnectionString;

            return strConn;
        }
    }
}
