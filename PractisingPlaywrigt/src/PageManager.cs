using Microsoft.Playwright;
using PracticingPlaywright.src.Core;
using PracticingPlaywright.src.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingPlaywright.src
{
    public class PageManager
    {
        public LoginPage LoginPage { get; }
        protected StepLogger Steps { get; }

        public PageManager(IPage page, StepLogger steps)
        {
            Steps = steps;
            LoginPage = new LoginPage(page, steps);
        }
    }
}
