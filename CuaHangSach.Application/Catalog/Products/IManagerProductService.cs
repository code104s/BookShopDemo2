using CuaHangSach.ViewModels.Catalog.Products;

using CuaHangSach.ViewModels.Common;
using CuaHangSach.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CuaHangSach.ViewModels.Catalog.ProductImages;

namespace CuaHangSach.Application.Catalog.Products;


public interface IManagerProductService
{ 
    Task<int> Create(ProductCreateRequest request);

    Task<int> Update(ProductUpdateRequest request);

    Task<int> Delete(int productId);

    Task<ProductViewModel> GetById(int productId, string Lan);

    Task<bool> UpadatePrice(int productId, decimal newPrice);
    Task<bool> UpadateSoLuong(int productId, int addedQuantity);

    /*Task<List<ProductViewModel>> GetAll();*/

    Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);   

    Task<int> AddImages(int productId ,ProductImageCreateRequest request);
    Task<int> RemoveImages( int imageId);
    Task<int> UpdateImages( int imageId, ProductImageUpdateRequest request);

    Task<ProductImageViewModel> GetImageById(int imageId);

    Task<List<ProductImageViewModel>> GetListImage(int productId);

    /*Task<bool> UpdateNgayTao(int NgayTao);*/

}
