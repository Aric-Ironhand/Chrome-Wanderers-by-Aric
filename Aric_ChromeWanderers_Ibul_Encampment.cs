namespace XRL.World.ZoneBuilders
{
    public class Aric_ChromeWanderers_Ibul_Encampment
    {
// maybe we set this up with a constructor and simplify the 3 down to 1, but not sure how that interacts with zonemanager.zonebuilder

        public bool BuildZone(Zone Z)
        {
            return new AricChromeWanderersEncampmentMaker().BuildZone(Z, bRoads: true, "Foamcrete", RoundBuildings: false, Huts:"6",Features: null, HutTable: "Aric_Ibul_building", ZoneTable: "Aric Ibul Expedition", Widgets: null, ClearCombatObjectsFirst: true, HQtable:"Aric_Ibul_HQ", HasTurrets:true, "Aric Ibul Floating Arc Turret", TraderTable: "Aric_Ibul_Trader_1", Faction: "Ibul");
        }
    }
}