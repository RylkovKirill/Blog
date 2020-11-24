using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class TimeZoneService
    {
        private readonly IHttpContextAccessor _httpContext;

        private TimeSpan? _userOffset;

        public TimeZoneService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public DateTime GetUTCDateTime(DateTime dateTime)
        {
            if (_userOffset == null)
            {
                int offsetInMinutes = Convert.ToInt32(_httpContext.HttpContext.Request.Cookies["ClientTimeZone"]);
                _userOffset = TimeSpan.FromMinutes(-offsetInMinutes);
            }

            return dateTime.Subtract(_userOffset.Value);
        }

        public DateTime GetLocalDateTime(DateTime dateTime)
        {
            if (_userOffset == null)
            {
                int offsetInMinutes = Convert.ToInt32(_httpContext.HttpContext.Request.Cookies["ClientTimeZone"]);
                _userOffset = TimeSpan.FromMinutes(-offsetInMinutes);
            }

            return dateTime.Add(_userOffset.Value);
        }
    }
}
