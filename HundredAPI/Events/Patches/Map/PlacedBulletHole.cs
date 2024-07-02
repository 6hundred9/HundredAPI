using Player = Exiled.API.Features.Player;
using HarmonyLib;
using HundredAPI.Events.EventArgs.Map;
using InventorySystem.Items.Firearms.Modules;
using UnityEngine;

namespace HundredAPI.Events.Patches.Map;
[HarmonyPatch(typeof(StandardHitregBase), nameof(StandardHitregBase.PlaceBulletholeDecal))]

public class PlacedBulletHoleEvent
{

    [HarmonyPostfix]
    private static void Postfix(RaycastHit hit, StandardHitregBase __instance)
    {
        Exiled.API.Features.Player player = Exiled.API.Features.Player.Get(__instance.Hub);
        PlacedBulletHoleEventArgs ev = new PlacedBulletHoleEventArgs(hit, player, __instance.Firearm);
        HundredAPI.Events.Handlers.Map.OnPlacedBulletHole(ev);
    }
}