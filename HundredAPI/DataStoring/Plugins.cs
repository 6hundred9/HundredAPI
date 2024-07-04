using System.Collections.Generic;
using System.Reflection;

namespace HundredAPI.DataStoring;

public class Plugins
{
    public static Dictionary<string, string> PluginNames = new();

    public static void AddToDict(string pluginName)
    {
        Assembly PluginUsing = Assembly.GetCallingAssembly();
        PluginNames.Add(PluginUsing.FullName, pluginName);
    }
}