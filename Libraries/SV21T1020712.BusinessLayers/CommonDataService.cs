using SV21T1020712.DataLayers;
using SV21T1020712.DomainModels;

namespace SV21T1020712.BusinessLayers
{
    public static class CommonDataService
    {
        private static readonly ICommonDAL<Customer> customerDB;
        private static readonly ICommonDAL<Shipper> shipperDB;
        private static readonly ICommonDAL<Supplier> supplierDB;
        private static readonly ICommonDAL<Category> categoryDB;
        private static readonly ICommonDAL<Employee> employeeDB;
        private static readonly ISimpleQueryDAL<Province> provinceDB;
        static CommonDataService()
        {
            string connectionString = @"server=.;user id=sa;password=Password123456789;database=LiteCommerceDB;TrustServerCertificate=true";
            customerDB = new DataLayers.SQLServer.CustomerDAL(connectionString);
            shipperDB = new DataLayers.SQLServer.ShipperDAL(connectionString);
            supplierDB = new DataLayers.SQLServer.SupplierDAL(connectionString);
            categoryDB = new DataLayers.SQLServer.CategoryDAL(connectionString);
            employeeDB = new DataLayers.SQLServer.EmployeeDAL(connectionString);
            provinceDB = new DataLayers.SQLServer.ProvinceDAL(connectionString);
        }
        public static List<Province> ListOfProvinces()
        {
            return provinceDB.List();
        }
        /// <summary>
        ///     Tìm kiếm và lấy danh sách khách hàng dưới dạng phân trang
        /// </summary>
        /// <param name="rowCount">Tham số đầu ra cho biết số dòng tìm được</param>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng hiển thị trên mỗi trang</param>
        /// <param name="searchValue">Tên khách hàng hoặc tên giao dịch cần tìm</param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = customerDB.Count(searchValue);
            return customerDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// Lấy thông tin của 1 khách hàng dựa vào mã
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Customer? GetCustomer(int id)
        {
            return customerDB.Get(id);
        }
        /// <summary>
        /// Bổ sung 1 khách hàng mới. Hàm trả về mã của khách hàng được bổ sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCustomer(Customer data)
        {
            return customerDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin của 1 khách hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCustomer(Customer data)
        {
            return customerDB.Update(data);
        }
        /// <summary>
        /// Xoá 1 khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteCustomer(int id)
        {
            if (customerDB.InUsed(id))
            {
                return false;
            }
            return customerDB.Delete(id);
        }
        /// <summary>
        /// Kiểm tra 1 khách hàng hiện đang có đơn hàng hay không?
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool InUsedCustomer(int id)
        {
            return customerDB.InUsed(id);
        }

        public static List<Shipper> ListOfShippers(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = shipperDB.Count(searchValue);
            return shipperDB.List(page, pageSize, searchValue);
        }

        public static Shipper? GetShipper(int id)
        {
            return shipperDB.Get(id);
        }

        public static int AddShipper(Shipper data)
        {
            return shipperDB.Add(data);
        }

        public static bool UpdateShipper(Shipper data)
        {
            return shipperDB.Update(data);
        }

        public static bool DeleteShipper(int id)
        {
            if (shipperDB.InUsed(id))
            {
                return false;
            }
            return shipperDB.Delete(id);
        }

        public static bool InUsedShipper(int id)
        {
            return shipperDB.InUsed(id);
        }

        public static List<Supplier> ListOfSuppliers(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = supplierDB.Count(searchValue);
            return supplierDB.List(page, pageSize, searchValue);
        }
        public static Supplier? GetSupplier(int id)
        {
            return supplierDB.Get(id);
        }

        public static int AddSupplier(Supplier data)
        {
            return supplierDB.Add(data);
        }

        public static bool UpdateSupplier(Supplier data)
        {
            return supplierDB.Update(data);
        }

        public static bool DeleteSupplier(int id)
        {
            if (supplierDB.InUsed(id))
            {
                return false;
            }
            return supplierDB.Delete(id);
        }

        public static bool InUsedSupplier(int id)
        {
            return supplierDB.InUsed(id);
        }

        public static List<Category> ListOfCategories(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = categoryDB.Count(searchValue);
            return categoryDB.List(page, pageSize, searchValue);
        }
        public static Category? GetCategory(int id)
        {
            return categoryDB.Get(id);
        }

        public static int AddCategory(Category data)
        {
            return categoryDB.Add(data);
        }

        public static bool UpdateCategory(Category data)
        {
            return categoryDB.Update(data);
        }
        public static bool DeleteCategory(int id)
        {
            if (categoryDB.InUsed(id))
            {
                return false;
            }
            return categoryDB.Delete(id);
        }

        public static bool InUsedCategory(int id)
        {
            return categoryDB.InUsed(id);
        }




        public static List<Employee> ListOfEmployees(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = employeeDB.Count(searchValue);
            return employeeDB.List(page, pageSize, searchValue);
        }



    }
}