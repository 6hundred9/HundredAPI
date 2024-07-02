using HarmonyLib;
using HundredAPI.Events.EventArgs.Player;
using RemoteAdmin;

namespace HundredAPI.Events.Patches.Player;

[HarmonyPatch(typeof(CommandProcessor), nameof(CommandProcessor.ProcessQuery))]
public class RemoteAdminCommandEvent
{
    private static bool Prefix(string q, CommandSender sender)
    {
        [HarmonyPrefix]
        RACommandEventArgs ev = new(Exiled.API.Features.Player.Get(sender), q);
        Handlers.Player.OnExecutedRACommand(ev);
        return ev.IsAllowed;
    }
}