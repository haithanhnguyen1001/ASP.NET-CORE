using Microsoft.Data.SqlClient;

namespace SV21T1020712.DataLayers.SQLServer
{
    /// <summary>
    /// Lớp cơ sở (lớp cha) của các lớp cài đặt các phép xử lý dữ liệu trên SQL Server
    /// </summary> <summary>
    /// 
    /// </summary>
    public abstract class BaseDAL
    {
        /// <summary>
        /// Chuỗi tham số kết nối đến CSDL SQL Server
        /// </summary>
        protected string connectionString = "";

        public BaseDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// Tạo và mở một kết nối đến CSDL (SQL Server)
        /// </summary>
        /// <returns></returns>
        protected SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}