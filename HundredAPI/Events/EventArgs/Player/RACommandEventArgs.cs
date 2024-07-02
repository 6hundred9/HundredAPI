using Exiled.Events.EventArgs.Interfaces;

namespace HundredAPI.Events.EventArgs.Player;

public class RACommandEventArgs : IPlayerEvent, IDeniableEvent
{
    public RACommandEventArgs(Exiled.API.Features.Player Player, string Query, bool IsAllowed = true)
    {
        this.Player = Player;
        this.IsAllowed = IsAllowed;
        this.Query = Query;
    }
    public Exiled.API.Features.Player Player { get; }
    public bool IsAllowed { get; set; }
    public string Query { get; }
}