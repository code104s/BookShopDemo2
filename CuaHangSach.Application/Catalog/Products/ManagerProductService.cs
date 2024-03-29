﻿using CuaHangSach.ViewModels.Common;
using CuaHangSach.Data.Entities;
using CuaHangSach.Data.EF;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuaHangSach.ViewModels.Catalog.Products.Manager;
using CuaHangSach.ViewModels.Catalog.Products;
using CuaHangSach.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using CuaHangSach.Application.Common;
using Microsoft.AspNetCore.Hosting;

namespace CuaHangSach.Application.Catalog.Products
{
    public class ManagerProductService : IManagerProductService
    {
        private readonly shopDbcontext _context;
        private readonly IStrorageService _storageService;
        public ManagerProductService(shopDbcontext context, IStrorageService strorageService)
        {
            _context = context;
            _storageService = strorageService;
        }
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new SanPhamProduct()
            {
                Gia = request.Gia,
                GiaGoc = request.GiaGoc,
                SoLuong = request.SoLuong,
                NgayTao = DateTime.Now,
                SanPhamTranslations = new List<SanPhamTranslation>()
                {
                    new SanPhamTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoAlias = request.SeoAlias,
                        SeoDescription = request.SeoDescription,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId,

                    }
                }
            };

            //Save Image
            if(request.ThubnailImage != null)
            {
                product.ProductImages = new List<ProductImage>
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThubnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThubnailImage),
                        IsDefault= true,
                        SortOrder = 1,
                    }
                };
            }


            _context.SanPhamProducts.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.SanPhamProducts.FindAsync(productId);
            if (product == null) throw new ShopException("Khong tim thay san pham : {productId}");

            _context.SanPhamProducts.Remove(product);
            return await _context.SaveChangesAsync();
        }

       /* public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }*/

        
        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {

            //1. Select join
            var query = from p in _context.SanPhamProducts
                        join pt in _context.sanPhamTranslations on p.Id equals pt.ProductId
                        join pic in _context.sanPhamInDanhMucs on p.Id equals pic.ProductId
                        join c in _context.DanhMucCategories on pic.CategoryId equals c.id
                        select new { p, pt,pic };
            //2 . filter
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.pt.Name.Contains(request.keyword));

            if(request.CategoryId.Count>0)
            {
                query = query.Where(p => request.CategoryId.Contains(p.pic.CategoryId));
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Take(request.PageSize)
                .Select(x=>new ProductViewModel() 
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
                Items = data,

            };
            return pagedResult;
        }

        public async Task<bool> UpadatePrice(int productId, decimal newPrice)
        {
            var product = await _context.SanPhamProducts.FindAsync(productId);
            if (product == null) throw new ShopException($"Cannot find a product with id: {productId} ");
            product.Gia = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

       
        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.SanPhamProducts.FindAsync(request.Id);
            var productTranslation = _context.sanPhamTranslations.FirstOrDefault(x => x.ProductId == request.Id
            && x.LanguageId==request.LanguageId);

            if (product == null || productTranslation == null) throw new ShopException($"Cannot find a product with id:{request.Id}");

            productTranslation.Name = request.Name;
            productTranslation.SeoAlias = request.SeoAlias;
            productTranslation.SeoDescription = request.SeoDescription;
            productTranslation.SeoTitle = request.SeoTitle;
            productTranslation.Description = request.Description;
            productTranslation.Details = request.Details;
            return await _context.SaveChangesAsync();

        }
        public async Task<bool> UpadateSoLuong(int productId, int addedQuantity)
        {
            var product = await _context.SanPhamProducts.FindAsync(productId);
            if (product == null) throw new ShopException($"Cannot find a product with id: {productId} ");
            product.SoLuong += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

    }
}
