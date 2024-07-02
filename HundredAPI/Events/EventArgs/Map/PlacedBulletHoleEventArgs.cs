using Exiled.API.Features;
using Exiled.Events.EventArgs.Interfaces;
using InventorySystem.Items.Firearms;
using UnityEngine;

namespace HundredAPI.Events.EventArgs.Map
{
    public class PlacedBulletHoleEventArgs : IPlayerEvent
    {
        
        public PlacedBulletHoleEventArgs(RaycastHit Hit, Exiled.API.Features.Player Player, Firearm Weapon)
        {
            this.Hit = Hit;
            this.Player = Player;
            this.Weapon = Weapon;
        }
        /// <summary>
        /// The raycast of the bullet hole
        /// </summary>
        public RaycastHit Hit { get; }
        /// <summary>
        /// The player creating the bullet hole
        /// </summary>
        public Exiled.API.Features.Player Player { get; }
        /// <summary>
        /// The firearm used to create the bullet hole
        /// </summary>
        public Firearm Weapon { get; }
    }
}