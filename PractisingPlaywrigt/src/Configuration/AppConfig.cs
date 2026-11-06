using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingPlaywright.src.Configuration
{
    public class AppConfig
    {
        public string BaseUrl { get; set; } = "";
        public bool Headless { get; set; }
        public bool FullScreen { get; set; }
    }

}
