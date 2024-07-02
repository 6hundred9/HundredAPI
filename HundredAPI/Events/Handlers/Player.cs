using Exiled.Events.Features;
using HundredAPI.Events.EventArgs.Map;
using HundredAPI.Events.EventArgs.Player;

namespace HundredAPI.Events.Handlers;

public class Player
{
    /// <summary>
    /// Invoked after an RA command is executed.
    /// </summary>
    public static Event<RACommandEventArgs> RACommandExecuted { get; set; } = new();
    
    /// <summary>
    /// Called after an RA command is executed
    /// </summary>
    /// <param name="ev">The <see cref="RACommandEventArgs"/> instace</param>
    public static void OnExecutedRACommand(RACommandEventArgs ev) => RACommandExecuted.InvokeSafely(ev);
}