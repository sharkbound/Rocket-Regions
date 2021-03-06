﻿using System;
using System.Linq;
using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;

namespace RocketRegions.Util
{
    public static class PlayerUtil
    {
        public static UnturnedPlayer GetUnturnedPlayer(IRocketPlayer player)
        {
            if (player == null) return null;
            if (!(player is UnturnedPlayer))
            {
                throw new NotSupportedException("This plugin is for Unturned!");
            }

            return (UnturnedPlayer)player;
        }

        public static CSteamID GetCSteamId(IRocketPlayer player)
        {
            if (player == null) return CSteamID.Nil;
            //for some reason one of the fiels below can be null
            var steamPlayerId= GetUnturnedPlayer(player)?.Player?.SteamChannel?.SteamPlayer?.SteamPlayerID;
            return steamPlayerId?.CSteamID ?? CSteamID.Nil;
        }

        public static ulong GetId(IRocketPlayer player)
        {
            var id = GetCSteamId(player);
            return id.m_SteamID;
        }

        public static ulong GetId(SteamPlayer player)
        {
            if (player == null) return CSteamID.Nil.m_SteamID;
            var id = player.playerID.CSteamID;
            return id.GetAccountID().m_AccountID;
        }
    }
}