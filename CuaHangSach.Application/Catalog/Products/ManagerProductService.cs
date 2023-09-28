using CuaHangSach.ViewModels.Common;
using CuaHangSach.Data.Entities;
using CuaHangSach.Data.EF;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuaHangSach.ViewModels.Catalog.Products;
using CuaHangSach.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using CuaHangSach.Application.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using static System.Net.Mime.MediaTypeNames;
using CuaHangSach.ViewModels.Catalog.ProductImages;

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
            if (request.ThubnailImage != null)
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
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.SanPhamProducts.FindAsync(productId);
            if (product == null) throw new ShopException("Khong tim thay san pham : {productId}");

            var images = _context.productImages.Where(i => i.IsDefault == true && i.ProductId == product.Id);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }

            _context.SanPhamProducts.Remove(product);

            return await _context.SaveChangesAsync();
        }

        /* public async Task<List<ProductViewModel>> GetAll()
         {
             throw new NotImplementedException();
         }*/


        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {

            //1. Select join
            var query = from p in _context.SanPhamProducts
                        join pt in _context.sanPhamTranslations on p.Id equals pt.ProductId
                        join pic in _context.sanPhamInDanhMucs on p.Id equals pic.ProductId
                        join c in _context.DanhMucCategories on pic.CategoryId equals c.id
                        select new { p, pt, pic };
            //2 . filter
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.pt.Name.Contains(request.keyword));

            if (request.CategoryId.Count > 0)
            {
                query = query.Where(p => request.CategoryId.Contains(p.pic.CategoryId));
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
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
            && x.LanguageId == request.LanguageId);

            if (product == null || productTranslation == null) throw new ShopException($"Cannot find a product with id:{request.Id}");

            productTranslation.Name = request.Name;
            productTranslation.SeoAlias = request.SeoAlias;
            productTranslation.SeoDescription = request.SeoDescription;
            productTranslation.SeoTitle = request.SeoTitle;
            productTranslation.Description = request.Description;
            productTranslation.Details = request.Details;

            //Save Image
            if (request.ThubnailImage != null)
            {
                var thumbnaiImage = await _context.productImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumbnaiImage != null)
                {


                    thumbnaiImage.FileSize = request.ThubnailImage.Length;
                    thumbnaiImage.ImagePath = await this.SaveFile(request.ThubnailImage);
                    _context.productImages.Update(thumbnaiImage);

                }

            }

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





        public async Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            return await _context.productImages.Where(x => x.ProductId == productId)
                .Select(i => new ProductImageViewModel()
                {
                    Caption = i.Caption,
                    DateCreated = i.DateCreated,
                    FileSize = i.FileSize,
                    Id = i.Id,
                    ImagePath = i.ImagePath,
                    IsDefault = i.IsDefault,
                    ProductId = i.ProductId,
                    SortOrder = i.SortOrder,
                }).ToListAsync();


        }

        public async Task<ProductViewModel> GetById(int productId, string languageId)
        {
            var product = await _context.SanPhamProducts.FindAsync(productId);
            var productTranslation = await _context.sanPhamTranslations.FirstOrDefaultAsync(x => x.ProductId == productId
            && x.LanguageId == languageId);
            var productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                NgayTao = product.NgayTao,
                Description = productTranslation != null ? productTranslation.Description : null,
                LanguageId = productTranslation.LanguageId,
                Details = productTranslation != null ? productTranslation.Details : null,
                Name = productTranslation != null ? productTranslation.Name : null,
                GiaGoc = product.GiaGoc,
                Gia = product.Gia,
                SeoAlias = productTranslation != null ? productTranslation.SeoAlias : null,
                SeoDescription = productTranslation != null ? productTranslation.SeoDescription : null,
                SeoTitle = productTranslation != null ? productTranslation.SeoTitle : null,
                SoLuong = product.SoLuong

            };
            return productViewModel;
        }

        public async Task<int> AddImages(int productId, ProductImageCreateRequest request)
        {
            var productImage = new ProductImage()
            {
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                SortOrder = request.SortOrder,
            };
            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.productImages.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage.Id;

        }




        public async Task<int> UpdateImages(  int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.productImages.FindAsync(imageId);
            if (productImage == null)
            {
                throw new ShopException($"Cannot find an image id {imageId}");
            }
            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.productImages.Update(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveImages(int imageId)
        {
            var productImage = await _context.productImages.FindAsync(imageId);
            if (productImage == null)
            {
                throw new ShopException($"Cannot finf an image with id {imageId}");
            }
            _context.productImages.Remove(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductImageViewModel> GetImageById(int imageId)
        {
            var image = await _context.productImages.FindAsync(imageId);
            if (image == null)
            { throw new ShopException($"Cannot find an image whith id {imageId}"); }
            var viewModel = new ProductImageViewModel()
            {
                Caption = image.Caption,
                DateCreated = image.DateCreated,
                FileSize = image.FileSize,
                Id = image.Id,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                ProductId = image.ProductId,
                SortOrder = image.SortOrder,
            };
            return viewModel;
        }
    }
}
