using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HundredAPI.DataStoring;

public class Write
{
    public Write()
    {
        CreateDir();
    }
    private string Path = System.IO.Path.Combine(Exiled.API.Features.Paths.Exiled, "DataStore");

    private void CreateDir()
    {
        if (Directory.Exists(Path)) return;
        Directory.CreateDirectory(Path);
    }
    /// <summary>
    /// Creates a folder to contain plugin data across rounds
    /// </summary>
    /// <param name="pluginName">Name of the plugin (THIS CANNOT BE THE SAME AS OTHER PLUGINS)</param>
    public void CreatePluginData(string pluginName)
    {
        string pluginPath = System.IO.Path.Combine(Path, $"{pluginName}.yml");
        Assembly PluginUsing = Assembly.GetCallingAssembly();
        if (File.Exists(pluginPath))
        {
            throw new IOException($"pluginName cannot be the same as another plugin!\nError triggered by {PluginUsing.Location}");
        }

        File.Create(pluginPath);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pluginName">Name of the plugin</param>
    /// <param name="contents"></param>
    public void WritePluginData(string pluginName, List<object> contents)
    {
        Assembly PluginUsing = Assembly.GetCallingAssembly();
        string pluginPath = System.IO.Path.Combine(Path, $"{pluginName}.yml");
        if (!File.Exists(pluginPath))
        {
            throw new IOException($"pluginName {pluginName} does not exist!\nError triggered by {PluginUsing.Location}");
        }
        File.WriteAllText(pluginPath,SerializeAndDeserialize.Serialize(contents));
    }
}