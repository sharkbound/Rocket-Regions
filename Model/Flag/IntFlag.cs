﻿using System;
using Rocket.API;
using RocketRegions.Model.Safezone;

namespace RocketRegions.Model.Flag
{
    public abstract class IntFlag : RegionFlag
    {
        public override bool ParseValue(IRocketPlayer caller, Region zone, string rawValue, Group group = Group.NONE)
        {
            try
            {
                SetValue(Convert.ToInt32(rawValue), group);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}