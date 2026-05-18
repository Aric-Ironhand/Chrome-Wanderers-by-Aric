using System;

namespace XRL.World.Parts
{


    [Serializable]
    public class AricObjectOnEntering : IPart
    {
        public string Blueprint = "Rubble";


        public override bool SameAs(IPart p)
        {
            AricObjectOnEntering AricObjectOnEntering = p as AricObjectOnEntering;
            if (AricObjectOnEntering.Blueprint != Blueprint)
            {
                return false;
            }

            return base.SameAs(p);
        }

        public override void Register(GameObject Object, IEventRegistrar Registrar)
        {
            Registrar.Register("ProjectileEntering");
            base.Register(Object, Registrar);
        }

        public override bool FireEvent(Event E)
        {
            if (E.ID == "ProjectileEntering" && E.GetParameter("Cell") is Cell cell)
            {
                GameObject gameObject = GameObject.Create(Blueprint);
                cell.AddObject(gameObject);
            }
            return base.FireEvent(E);
        }
    }
}