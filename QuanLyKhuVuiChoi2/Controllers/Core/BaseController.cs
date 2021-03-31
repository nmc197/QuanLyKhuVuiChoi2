using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;

namespace QuanLyKhuVuiChoi2.Controllers.Core
{
    public class BaseController : Controller
    {
        private readonly ICacheHelper _cacheHelper;
        public BaseController(ICacheHelper cacheHelper)
        {
            _cacheHelper = cacheHelper;
        }
    }
}