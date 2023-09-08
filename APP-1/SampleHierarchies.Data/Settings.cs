using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Settings class
    /// </summary>
    public class Settings : ISettings
    {   
        public Dictionary<ScreenEnum, ConsoleColor> ScreensColor { get; set; } = new Dictionary<ScreenEnum, ConsoleColor>();
    }
}
