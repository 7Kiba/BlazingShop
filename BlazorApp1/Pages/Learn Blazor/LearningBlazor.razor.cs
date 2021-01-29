using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Pages.Learn_Blazor
{
    public class LearningBlazorBase : ComponentBase
    {
        protected string title = "LearningBlazor";
        protected string input;

        protected void GetName()
        {
            input = "WOLOLO!";
        }
    }
}
