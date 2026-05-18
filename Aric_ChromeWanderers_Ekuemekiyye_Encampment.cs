namespace XRL.World.ZoneBuilders
{
    public class Aric_ChromeWanderers_Ekuemekiyye_Encampment
    {
// maybe we set this up with a constructor and simplify the 3 down to 1, but not sure how that interacts with zonemanager.zonebuilder

        public bool BuildZone(Zone Z)
        {
            return new AricChromeWanderersEncampmentMaker().BuildZone(Z, bRoads: true, WallObject: "Aric camo foamcrete", RoundBuildings: true, Huts:"6",Features: null, HutTable: "Aric_Ekuemekiyye_building", ZoneTable: "Aric Ekuemekiyye Expedition", Widgets: null, ClearCombatObjectsFirst: true, HQtable:"Aric_Ekuemekiyye_HQ", HasTurrets:true, "Aric Ekuemekiyye Fortification", TraderTable: "Aric_Ekuemekiyye_Trader_1", Faction:"Ekuemekiyye");
        }
    }
}