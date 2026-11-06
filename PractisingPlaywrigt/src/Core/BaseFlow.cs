using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingPlaywright.src.Core
{
    public abstract class BaseFlow
    {
        protected PageManager Pages { get; }
        protected StepLogger Steps { get; }

        protected BaseFlow(PageManager pages, StepLogger steps)
        {
            Pages = pages;
            Steps = steps;
        }
    }
}
