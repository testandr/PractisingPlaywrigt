using Microsoft.Playwright;
using PracticingPlaywright.src.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingPlaywright.src
{
    public class PageManager
    {
        public LoginPage LoginPage { get; }

        public PageManager(IPage page)
        {
            LoginPage = new LoginPage(page);
        }
    }
}
