using Genkit;
using Microsoft.CodeAnalysis;
using System;
using XRL;
using XRL.World;
using XRL.World.Parts;
using XRL.World.WorldBuilders;
using XRL.World.ZoneBuilders;

namespace Aric.ChromeWanderers
{
    [JoppaWorldBuilderExtension]
    public class Aric_ChromeWanderersWorldBuilder : IJoppaWorldBuilderExtension
    {
        public MutabilityMap mutableMap = new MutabilityMap();
        public override void OnAfterBuild(JoppaWorldBuilder builder)
        {

            Zone WorldZone = The.ZoneManager.GetZone("JoppaWorld");

            //Ibul

            var AricCampIbullocation = builder.popMutableLocationOfTerrain("Ruins", centerOnly: true);
            var AricCampIbulzoneID = builder.ZoneIDFromXY("JoppaWorld", AricCampIbullocation.X, AricCampIbullocation.Y);

            The.ZoneManager.AddZoneBuilder(AricCampIbulzoneID, 6000, "Aric_ChromeWanderers_Ibul_Encampment");

            var IbulSecret = builder.AddSecret(AricCampIbulzoneID,
                 "Archaeological Expedition of the Arcology of Ibul",
                    new string[2] { "lair", "Aric Ibul" },
                   "Lairs",
                   "$Aric_ChromeWanderers_Ibul_Encampment");

            (The.ZoneManager.GetZone("JoppaWorld").GetCell(AricCampIbullocation.X / 3, AricCampIbullocation.Y / 3).GetFirstObjectWithPart("TerrainTravel")?.GetPart<TerrainTravel>()).AddEncounter(new EncounterEntry("The sounds of artificers at work, the smell of burnt metal fill the air. Recent, high plastcrete walls obsure and contrast the ancient ruin of the Eaters that the encampment is nestled within. Will you investigate? ", AricCampIbulzoneID, "", "$Aric_ChromeWanderers_Ibul_Encampment", Optional: true));


            builder.mutableMap.SetMutable(AricCampIbullocation, 0);

            //Ekuemekiyye

            var AricCampEkuemekiyyelocation = builder.popMutableLocationOfTerrain("Jungle", centerOnly: true);
            var AricCampEkuemekiyyezoneID = builder.ZoneIDFromXY("JoppaWorld", AricCampEkuemekiyyelocation.X, AricCampEkuemekiyyelocation.Y);

            The.ZoneManager.AddZoneBuilder(AricCampEkuemekiyyezoneID, 6000, "Aric_ChromeWanderers_Ekuemekiyye_Encampment");

            var EkuemekiyyeSecret = builder.AddSecret(AricCampEkuemekiyyezoneID,
                 "Ekuemekiyyen hunting camp",
                    new string[2] { "lair", "Aric Ekuemekiyye"},
                   "Lairs",
                   "$Aric_ChromeWanderers_Ekuemekiyye_Encampment");

            (The.ZoneManager.GetZone("JoppaWorld").GetCell(AricCampEkuemekiyyelocation.X / 3, AricCampEkuemekiyyelocation.Y / 3).GetFirstObjectWithPart("TerrainTravel")?.GetPart<TerrainTravel>()).AddEncounter(new EncounterEntry("An acrid fetor cuts through the aromas of the jungle. Camoflauged foamcrete walls hide the dark deeds within. Will you investigate? ", AricCampEkuemekiyyezoneID, "", "$Aric_ChromeWanderers_Ekuemekiyye_Encampment", Optional: true));

            string Ekundergroundzone = builder.ZoneIDFromXYz("JoppaWorld", AricCampEkuemekiyyelocation.X, AricCampEkuemekiyyelocation.Y, 11);

            The.ZoneManager.AddZoneBuilder(Ekundergroundzone, 4900, "ClearAll");
            The.ZoneManager.AddZonePostBuilder(Ekundergroundzone, "MapBuilder", "FileName", "Aric_ekuemekiyye_sacrifice_pit.rpm");

            builder.mutableMap.SetMutable(AricCampEkuemekiyyelocation, 0);

            //Yawningmoon

            var AricCampYawningmoonlocation = builder.popMutableLocationOfTerrain("Jungle", centerOnly: true);
            var AricCampYawningmoonzoneID = builder.ZoneIDFromXY("JoppaWorld", AricCampYawningmoonlocation.X, AricCampYawningmoonlocation.Y);

            The.ZoneManager.AddZoneBuilder(AricCampYawningmoonzoneID, 6000, "Aric_ChromeWanderers_Yawningmoon_Encampment");

            var YawningmoonSecret = builder.AddSecret(AricCampYawningmoonzoneID,
                 "Yawningmoon lakeside naval base",
                    new string[2] { "lair", "Aric Yawningmoon" },
                   "Lairs",
                   "$Aric_ChromeWanderers_Yawningmoon_Encampment");

            (The.ZoneManager.GetZone("JoppaWorld").GetCell(AricCampYawningmoonlocation.X / 3, AricCampYawningmoonlocation.Y / 3).GetFirstObjectWithPart("TerrainTravel")?.GetPart<TerrainTravel>()).AddEncounter(new EncounterEntry("Ringing bells and the shouts of workers announce a vibrant lakeside community. A whiff of sulfur and the roar of nanopnemuatics identifies the inhabitants as Children of the Yawningmoon. Will you investigate? ", AricCampYawningmoonzoneID, "", "$Aric_ChromeWanderers_Yawningmoon_Encampment", Optional: true));


            builder.mutableMap.SetMutable(AricCampYawningmoonlocation, 0);

            // Heavenpiercer

            var AricHPlocation = builder.popMutableLocationOfTerrain("BaroqueRuins", centerOnly: true);
            var AricHPzoneID = builder.ZoneIDFromXY("JoppaWorld", AricHPlocation.X, AricHPlocation.Y);

            //actual builders- need to create the terrain and place it here.
            Cell AricHPCell = WorldZone.GetCell(AricHPlocation.X / 3, AricHPlocation.Y / 3);

            AricHPCell.Clear();
            AricHPCell.AddObject("Aric Heavenpiercer Terrain");

            // The.ZoneManager.SetZoneName(AricHPzoneID, "Heavenpiercer", Proper: true);
            //The.ZoneManager.SetZoneIncludeStratumInZoneDisplay(AricHPzoneID, true);

            //Stockade

            var AricStockadelocation = builder.popMutableLocationOfTerrain("Jungle", centerOnly: true);
            var AricStockadezoneID = builder.ZoneIDFromXY("JoppaWorld", AricStockadelocation.X, AricStockadelocation.Y);

            The.ZoneManager.ClearZoneBuilders(AricStockadezoneID);
           // The.ZoneManager.AddZoneBuilder(AricStockadezoneID, 4900, "ClearAll");
            The.ZoneManager.AddZonePostBuilder(AricStockadezoneID, "MapBuilder", "FileName", "Aric_Stockade_C.rpm");
            The.ZoneManager.AddZonePostBuilder(AricStockadezoneID, "Music", "Track", "Music/Overworld");
            The.ZoneManager.SetZoneName(AricStockadezoneID, "The Stockade", Proper: true);
            The.ZoneManager.SetZoneProperty(AricStockadezoneID, "NoBiomes", "Yes");
            The.ZoneManager.SetZoneProperty(AricStockadezoneID, "SkipTerrainBuilders", true);
           // The.ZoneManager.AddZoneBuilder(AricStockadezoneID, -1000, "Population", "Table", "Aric_Grove_Guardians");





            Location2D StockadeLocationN = AricStockadelocation.FromDirection("NW");
            string StockadeNzoneID = Zone.XYToID("JoppaWorld", StockadeLocationN.X, StockadeLocationN.Y, 10);
            The.ZoneManager.AdjustZoneGenerationTierTo(StockadeNzoneID);
            The.ZoneManager.ClearZoneBuilders(StockadeNzoneID);
            //The.ZoneManager.AddZoneBuilder(StockadeNzoneID, 4900, "ClearAll");
            The.ZoneManager.AddZonePostBuilder(StockadeNzoneID, "MapBuilder", "FileName", "Aric_Sower_plantation.rpm");
            The.ZoneManager.AddZoneBuilder(StockadeNzoneID, 5000, "Music", "Track", "Music/Overworld");
            The.ZoneManager.SetZoneName(StockadeNzoneID, "Sowers' Grove", Proper: true);
            The.ZoneManager.SetZoneProperty(StockadeNzoneID, "NoBiomes", "Yes");
            The.ZoneManager.SetZoneProperty(StockadeNzoneID, "SkipTerrainBuilders", true);
            //The.ZoneManager.AddZoneBuilder(AricStockadezoneID, 5100, "Population", "Table", "GoatfolkParty");



            var StockadeSecret = builder.AddSecret(AricStockadezoneID,
                 "The Stockade",
                    new string[2] { "ruin", "Goatfolk" },
                   "Lairs",
                   "$Aric_ChromeWanderers_Stockade");

            (The.ZoneManager.GetZone("JoppaWorld").GetCell(AricStockadelocation.X / 3, AricStockadelocation.Y / 3).GetFirstObjectWithPart("TerrainTravel")?.GetPart<TerrainTravel>()).AddEncounter(new EncounterEntry("The smell of roasted boar is cut through with the stench of suffering. Brick walls loom, enclosing the chained victims of the goatfolk's ire. Will you investigate? ", AricStockadezoneID, "", "$Aric_ChromeWanderers_Stockade", Optional: true));


            builder.mutableMap.SetMutable(AricStockadelocation, 0);


        }

    }
} 