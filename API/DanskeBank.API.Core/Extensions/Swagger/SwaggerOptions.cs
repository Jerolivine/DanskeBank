using System;
using System.Collections.Generic;
using System.Text;

namespace PaketTDanskeBankaxi.API.Core.Extensions.Swagger
{
    public class SwaggerOptions
    {
        public bool Enable { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public string FileName { get; set; }
        public string ApplicationVersion { get; set; }
    }
}
