using XRL.World.ZoneParts;

namespace XRL.World.Conversations.Parts
{

    public class Aric_CW_HP_Handler : IConversationPart
    {
        public string Drone;

        public string Deployment;

        public string Hostiles;

        public string Map;

        public string Clear;



        public override bool WantEvent(int ID, int Propagation)
        {
            if (!base.WantEvent(ID, Propagation))
            {
                return ID == EnteredElementEvent.ID;
            }
            return true;
        }

        public override bool HandleEvent(EnteredElementEvent E)
        {
            
            if (!Drone.IsNullOrEmpty() && !Deployment.IsNullOrEmpty())
            {
                Aric_CW_HP_TestingGroundsScripts.RemoveDrones();
                Aric_CW_HP_TestingGroundsScripts.PlaceDrones(Drone, Deployment);
            }

            if (!Map.IsNullOrEmpty())
            {
                Aric_CW_HP_TestingGroundsScripts.ClearHoloFurniture();

                Aric_CW_HP_TestingGroundsScripts.SpawnMapChunk(Map);
            }

            if (!Hostiles.IsNullOrEmpty())
            {
                Aric_CW_HP_TestingGroundsScripts.ClearHoloFighters();
                Aric_CW_HP_TestingGroundsScripts.PlaceHoloFighters(Hostiles);
            }

            if (!Clear.IsNullOrEmpty())
            {
                if(Clear == "environment")
                {
                    Aric_CW_HP_TestingGroundsScripts.ClearHoloFurniture();
                }
                if (Clear == "combatants")
                {
                    Aric_CW_HP_TestingGroundsScripts.ClearHoloFighters();
                }
                if (Clear == "drones")
                {
                    Aric_CW_HP_TestingGroundsScripts.RemoveDrones();
                }
                if (Clear == "all")
                {
                    Aric_CW_HP_TestingGroundsScripts.ClearHolos();
                    Aric_CW_HP_TestingGroundsScripts.RemoveDrones();
                    IComponent<Zone>.AddPlayerMessage("In clear holofurniture");
                }



            }
            return base.HandleEvent(E);
        }
    }
}