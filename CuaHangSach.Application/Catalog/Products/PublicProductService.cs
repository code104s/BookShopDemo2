using Azure.Core;
using CuaHangSach.ViewModels.Catalog.Products;
using CuaHangSach.ViewModels.Common;
using CuaHangSach.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using CuaHangSach.Data.Entities;

namespace CuaHangSach.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
         

        private readonly shopDbcontext _context;
        public PublicProductService(shopDbcontext context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.SanPhamProducts
                        join pt in _context.sanPhamTranslations on p.Id equals pt.ProductId
                        join pic in _context.sanPhamInDanhMucs on p.Id equals pic.ProductId
                        join c in _context.DanhMucCategories on pic.CategoryId equals c.id
                        where pt.LanguageId == languageId
                        select new { p, pt, pic };
            //2 . filter

            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new ProductViewModel()
            {
                Id = x.p.Id,
                Name = x.pt.Name,
                NgayTao = x.p.NgayTao,
                Description = x.pt.Description,
                Details = x.pt.Details,
                LanguageId = x.pt.LanguageId,
                GiaGoc = x.p.GiaGoc,
                Gia = x.p.Gia,
                SeoAlias = x.pt.SeoAlias,
                SeoDescription = x.pt.SeoDescription,
                SeoTitle = x.pt.SeoTitle,
                SoLuong = x.p.SoLuong,


            }).ToListAsync();
            ; //trang 2 : 2-1 = 1 , 1 * 10 = 10 

            //4. select and project
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data

            };
            return pagedResult;
        }

        
    }
}
