using MySql.Data.MySqlClient;

namespace Pantallas_Sistema_Facturacion
{
    public static class DBHelper
    {
        private static readonly string connectionString = "Server=localhost;Database=SistemaFacturacion;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}