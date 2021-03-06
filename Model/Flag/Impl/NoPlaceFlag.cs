﻿using System.Collections.Generic;
using System.Linq;
using Rocket.Unturned.Player;
using RocketRegions.Util;
using SDG.Unturned;
using Steamworks;

namespace RocketRegions.Model.Flag.Impl
{
    public class NoPlaceFlag : BoolFlag
    {
        public override string Description => "Allow/Disallow placing of structures";

        public override void UpdateState(List<UnturnedPlayer> players)
        {
            foreach (var p in from p in players
                              where PlayerUtil.GetCSteamId(p) != CSteamID.Nil
                              let playerGroup = Region.GetGroup(p)
                              let equippedItem = p.Player.Equipment.useable as UseableBarricade
                              where equippedItem != null && GetValue<bool>(playerGroup)
                              select p)
            {
                p.Player.equipment.dequip();
            }
        }

        public override void OnSafeZoneEnter(UnturnedPlayer player)
        {
            //do nothing
        }

        public override void OnSafeZoneLeave(UnturnedPlayer player)
        {
            //do nothing
        }
    }
}