using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

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
    /// <exception cref="IOException">File with the same plugin name exists</exception>
    public void CreatePluginData([CanBeNull] string pluginName)
    {
        string pluginPath = System.IO.Path.Combine(Path, $"{pluginName}.yml");
        Assembly PluginUsing = Assembly.GetCallingAssembly();
        if (Plugins.PluginNames.ContainsKey(PluginUsing.FullName))
        {
            pluginPath = System.IO.Path.Combine(Path, $"{Plugins.PluginNames[PluginUsing.FullName]}.yml");
        }
        if (File.Exists(pluginPath))
        {
            throw new IOException($"pluginName cannot be the same as another plugin!\nError triggered by {PluginUsing.FullName}");
        }

        File.Create(pluginPath);
    }
    /// <summary>
    /// Write the data you want into the plugin data file (this will overwrite the already existing contents of the fiel)
    /// </summary>
    /// <param name="pluginName">Plugin name</param>
    /// <param name="contents">The contents written into the plugin storage</param>
    /// <typeparam name="T">Type of contents</typeparam>
    /// <exception cref="IOException">File with the same plugin name exists</exception>
    public void WritePluginData<T>([CanBeNull] string pluginName, T contents)
    {
        Assembly PluginUsing = Assembly.GetCallingAssembly();
        string pluginPath = System.IO.Path.Combine(Path, $"{pluginName}.yml");
        if (Plugins.PluginNames.ContainsKey(PluginUsing.FullName))
        {
            pluginPath = System.IO.Path.Combine(Path, $"{Plugins.PluginNames[PluginUsing.FullName]}.yml");
        }
        if (!File.Exists(pluginPath))
        {
            throw new IOException($"pluginName {pluginName} does not exist!\nError triggered by {PluginUsing.FullName}");
        }
        File.WriteAllText(pluginPath,SerializeAndDeserialize.Serialize(contents));
    }
}