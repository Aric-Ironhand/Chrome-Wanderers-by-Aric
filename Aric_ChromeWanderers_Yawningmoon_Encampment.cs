namespace XRL.World.ZoneBuilders
{
    public class Aric_ChromeWanderers_Yawningmoon_Encampment
    {
// maybe we set this up with a constructor and simplify the 3 down to 1, but not sure how that interacts with zonemanager.zonebuilder

        public bool BuildZone(Zone Z)
        {
            return new AricChromeWanderersEncampmentMaker().BuildZone(Z, bRoads: true, "Foamcrete", RoundBuildings: false, Huts:"6",Features: null, HutTable: "Aric_Yawningmoon_building", ZoneTable: "Aric Yawningmoon Expedition", Widgets: null, ClearCombatObjectsFirst: true, HQtable:"Aric_Yawningmoon_HQ", HasTurrets:true, "ChaingunTurret", TraderTable: "Aric_Yawningmoon_Trader_1", Faction: "Yawningmoon");
        }
    }
}