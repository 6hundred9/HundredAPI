using System.ComponentModel;
using Exiled.API.Interfaces;

namespace HundredAPI
{
    public class Config : IConfig
    {
        [Description(
            "Whether the API and it's other services are enabled (If disabled breaks all plugins using the API)")]
        public bool IsEnabled { get; set; } = true;

        [Description("Does nothing (for now)")]
        public bool Debug { get; set; } = false;
    }
}