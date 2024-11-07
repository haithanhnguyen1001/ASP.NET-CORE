

using SV21T1020712.DataLayers;
using SV21T1020712.DataLayers.SQLServer;
using SV21T1020712.DomainModels;

namespace SV21T1020712.BusinessLayers
{
    public static class ProductDataService
    {
        private static readonly IProductDAL<Product> productDB;


        static ProductDataService()
        {
            productDB = new ProductDAL(Configuration.ConnectionString);
        }
        /// <summary>
        /// Tìm kiếm và lấy danh sách mặt hàng (không phân trang)
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>

        public static List<Product> ListProducts(string searchValue = "")
        {

        }
        /// <summary>
        /// Tìm kiếm và lấy danh sách mặt hàng dưới dạng phân trang
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="categoryId"></param>
        /// <param name="supplierId"></param>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <returns></returns>

        public static List<Product> ListProducts(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "", int categoryId = 0, int supplierId = 0, decimal minPrice = 0, decimal maxPrice = 0)
        {

        }
        /// <summary>
        /// Lấy thông tin 1 mặt hàng theo mã mặt hàng
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>

        public static Product? GetProduct(int productID)
        {

        }
        /// <summary>
        /// Bổ sung thông tin 1 mặt hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>

        public static int AddProduct(Product data)
        {

        }
        /// <summary>
        /// Cập nhật thông tin 1 mặt hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>

        public static bool UpdateProduct(Product data)
        {

        }
        /// <summary>
        /// Xoá thông tin 1 mặt hàng theo mã mặt hàng
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>

        public static bool DeleteProduct(int productID)
        {

        }
        /// <summary>
        /// Kiểm tra xem mặt hàng hiện đang có đơn hàng liên quan hay không
        /// </summary>
        /// <param name="productID"></param>

        public static InUsedProduct(int productID)
        {

        }


        public static List<ProductPhoto> ListPhotos(int productID)
        {

        }

        public static ProductPhoto? GetPhoto(long photoID)
        {

        }

        public static long AddPhoto(ProductPhoto data)
        {

        }

        public static bool UpdatePhoto(ProductPhoto data)
        {

        }

        public static bool DeletePhoto(long photoID)
        {

        }

    }
}