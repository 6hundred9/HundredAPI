using System;
using Exiled.API.Features;
using HarmonyLib;

namespace HundredAPI
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; }
        
        public override string Author { get; } = "6hundred9";
        public override string Name { get; } = "HundredAPI";
        public override string Prefix { get; } = "hAPI";
        public override Version Version { get; } = new(1, 1, 0);
        public override Version RequiredExiledVersion { get; } = new(8,9,6);
        public override bool IgnoreRequiredVersionCheck { get; } = true;

        private Harmony _harmony;
        
        public override void OnEnabled()
        {
            Instance = this;
            _harmony = new("6hundred9.HundredAPI.EA.Sports.Its.In.The.Game");
            _harmony.PatchAll();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            _harmony.UnpatchAll();
            base.OnDisabled();
        }
    }
}