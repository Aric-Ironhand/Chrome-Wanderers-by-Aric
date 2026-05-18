using System;

namespace XRL.World.Quests
{

    [Serializable]
    public class Aric_Ibul_Main_System : IQuestSystem
    {
        public override void Start()
        {

        }

        public override GameObject GetInfluencer()
        {
            return GameObject.FindByBlueprint("Aric Consul");
        }
    }
}