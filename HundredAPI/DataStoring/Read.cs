using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using JetBrains.Annotations;
using YamlDotNet.Serialization;

namespace HundredAPI.DataStoring;

public class Read
{
    public Read()
    {
        CreateDir();
    }
    private string Path = System.IO.Path.Combine(Exiled.API.Features.Paths.Exiled, "DataStore");
    private IDeserializer Deserializer = new DeserializerBuilder().Build();
    private void CreateDir()
    {
        if (Directory.Exists(Path)) return;
        Directory.CreateDirectory(Path);
    }

    public List<object> ReadFile([CanBeNull] string pluginName)
    {
        string pluginPath = System.IO.Path.Combine(Path, $"{pluginName}.yml");
        Assembly PluginUsing = Assembly.GetCallingAssembly();
        if (Plugins.PluginNames.ContainsKey(PluginUsing.FullName))
        {
            pluginPath = System.IO.Path.Combine(Path, $"{Plugins.PluginNames[PluginUsing.FullName]}.yml");
        }
        if (!File.Exists(pluginPath))
        {
            throw new IOException($"pluginName {pluginName} does not exist!\nError triggered by {PluginUsing.FullName}");
        }

        try
        {
            return SerializeAndDeserialize.Deserialize<List<object>>(File.ReadAllText(pluginPath));
        }
        catch (Exception e)
        {
            throw new Exception(
                $"An unexpected error has happened while deserializing plugin data: {e.InnerException}");
        }
    }
}