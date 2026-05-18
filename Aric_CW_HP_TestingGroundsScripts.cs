using System;
using Microsoft.SqlServer.Server;
using XRL.World.Parts;

namespace XRL.World.ZoneParts
{

    [Serializable]
    public class Aric_CW_HP_TestingGroundsScripts : IZonePart
    {
        string rpm;
        string hostiletype;


        //So we need some scripts for what we want to happen
        //We need the clear all holos (walls and creatures)
        //We need to check how many drones are in the zone
        //We need to remove drones that remain to reset test (with a popup that says that they return from whence they came. Do we want a basement storage thing that gives a count of remaining drones?)
        //

        public static void ClearHolos()
        {
            ClearHoloFurniture();
            ClearHoloFighters();

        }

        public static void ClearHoloFurniture()
        {
            foreach (GameObject holos in The.Player.CurrentZone.FindObjects((GameObject o) => o.HasIntProperty("Aric_HoloFurniture")))
            {
                holos.Obliterate();
            }

        }

        public static void ClearHoloFighters()
        {
            foreach (GameObject holos in The.Player.CurrentZone.FindObjects((GameObject o) => o.HasIntProperty("Aric_HoloFighter")))
            {
                holos.Obliterate();
            }

        }

        public static void SpawnMapChunk(string map)
        {
            ClearHoloFurniture();

            if (map == "jungle")
            {

                PopulationManager.Generate("Aric_HoloJungle");
            }
            else
            {

                The.Player.CurrentZone.GetCell(1, 1).AddObject(map);
            }
        }

        public static void PlaceDrones(string dronetype, string deployment)
        {
            RemoveDrones();
            // 15,7
            //67,20

            if (dronetype == "security" && deployment == "standard")
            {

                The.Player.CurrentZone.GetCell(15, 7).AddObject("Aric_Drone_Patrol_placer");
                The.Player.CurrentZone.GetCell(67, 20).AddObject("Aric_Drone_Patrol_placer");

            }

            if (dronetype == "security" && deployment == "heavy")
            {

                The.Player.CurrentZone.GetCell(15, 7).AddObject("Aric_Drone_Force_placer");
                The.Player.CurrentZone.GetCell(67, 20).AddObject("Aric_Drone_Force_placer");
            }

            if (dronetype == "military" && deployment == "standard")
            {

                The.Player.CurrentZone.GetCell(15, 7).AddObject("Aric_Military_Drone_Patrol_placer");
                The.Player.CurrentZone.GetCell(67, 20).AddObject("Aric_Military_Drone_Patrol_placer");
            }

            if (dronetype == "military" && deployment == "heavy")
            {

                The.Player.CurrentZone.GetCell(15, 7).AddObject("Aric_Military_Drone_Force_placer");
                The.Player.CurrentZone.GetCell(67, 20).AddObject("Aric_Military_Drone_Force_placer");
            }
        }
        public static void PlaceHoloFighters(String Hostile)
        {
            ClearHoloFighters();

            if (Hostile == "jungle")
            {
                The.Player.CurrentZone.GetCell(40, 12).AddObject("Aric_Jungle_Guerilla_placer");
            }

            if (Hostile == "mining")
            {
                The.Player.CurrentZone.GetCell(40, 12).AddObject("Aric_Miner_Radical_placer");
            }

            if (Hostile == "corpo")
            {
                The.Player.CurrentZone.GetCell(40, 12).AddObject("Aric_Corpo_Ninja_placer");
            }

        }

        public static void CheckExistingDrones()
        {

        }

        public static void RemoveDrones()
        {
            

            foreach (GameObject drones in The.Player.CurrentZone.FindObjects((GameObject o) => o.HasIntProperty("Aric_Drone")))
            {
                drones.Obliterate();
            }

        }

        public static bool CheckHostiles()
        {
            
            foreach (GameObject objects in The.Player.CurrentZone.FindObjects((GameObject o) => o.HasPart("Brain") &! o.InSamePartyAs(The.Player)))
            {
                return true;
                
            }
            return false;
        }

    }
}