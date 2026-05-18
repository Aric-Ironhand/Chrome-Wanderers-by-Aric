using System;

namespace XRL.World.Quests
{

    [Serializable]
    public class Aric_Ekuemekiyye_Main_System : IQuestSystem
    {
        public override void Start()
        {

        }

        public override GameObject GetInfluencer()
        {
            return GameObject.FindByBlueprint("Aric Priest of All Suns");
        }
    }
}