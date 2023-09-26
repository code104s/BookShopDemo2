﻿using CuaHangSach.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.ViewModels.Catalog.Products.Manager
{
    public class GetProductPagingRequest : PagingRequestBase
    {


        public string keyword { get; set; }

        public List<int> CategoryId { get; set; } //chuyen list Category  + keyword de tim kiem
    }
}
