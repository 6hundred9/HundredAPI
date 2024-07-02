using Exiled.Events.Features;
using HundredAPI.Events.EventArgs.Map;

namespace HundredAPI.Events.Handlers
{
    public class Map
    {
        /// <summary>
        /// Invoked after placing bullet holes.
        /// </summary>
        public static Event<PlacedBulletHoleEventArgs> PlacedBulletHole { get; set; } = new();
        
        /// <summary>
        /// Invoked after placing blood.
        /// </summary>
        public static Event<PlacedBloodEventArgs> PlacedBlood { get; set; } = new();
        
        /// <summary>
        /// Called after placing a bullet hole
        /// </summary>
        /// <param name="ev">The <see cref="PlacedBloodEventArgs"/> instace</param>
        public static void OnPlacedBulletHole(PlacedBulletHoleEventArgs ev) => PlacedBulletHole.InvokeSafely(ev);
        /// <summary>
        /// Called after placing blood
        /// </summary>
        /// <param name="ev">The <see cref="PlacedBloodEventArgs"/> instance</param>
        public static void OnPlacedBlood(PlacedBloodEventArgs ev) => PlacedBlood.InvokeSafely(ev);
    }
}