using Exiled.API.Features;
using HarmonyLib;
using HundredAPI.Events.EventArgs.Map;
using InventorySystem.Items.Firearms.Modules;
using UnityEngine;
using Player = Exiled.API.Features.Player;

namespace HundredAPI.Events.Patches.Map;

[HarmonyPatch(typeof(StandardHitregBase), nameof(StandardHitregBase.PlaceBulletholeDecal))]

public class PlacedBloodEvent
{

    [HarmonyPostfix]
    private static void Postfix(RaycastHit hit, StandardHitregBase __instance)
    {
        Exiled.API.Features.Player player = Exiled.API.Features.Player.Get(__instance.Hub);
        PlacedBloodEventArgs ev = new PlacedBloodEventArgs(hit, player, __instance.Firearm);
        HundredAPI.Events.Handlers.Map.OnPlacedBlood(ev);
    }
}