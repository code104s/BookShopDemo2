using CuaHangSach.ViewModels.Catalog.Products;
using CuaHangSach.ViewModels.Catalog.Products.Manager;
using CuaHangSach.ViewModels.Common;
using CuaHangSach.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Application.Catalog.Products
{

    public interface IManagerProductService
    { 
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<bool> UpadatePrice(int productId, decimal newPrice);
        Task<bool> UpadateSoLuong(int productId, int addedQuantity);

        /*Task<List<ProductViewModel>> GetAll();*/

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);   

    }
}
