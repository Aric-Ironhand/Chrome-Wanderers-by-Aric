using System;
using System.Collections.Generic;
using XRL.World.Parts.Mutation;

namespace XRL.World.Parts
{

    [Serializable]
    public class AricSpikedCollar : IActivePart
    {

        public AricSpikedCollar()
        {


        }

        public override bool WantEvent(int ID, int cascade)
        {
            if (!base.WantEvent(ID, cascade) && ID != AIGetOffensiveAbilityListEvent.ID && ID != BeforeApplyDamageEvent.ID && ID != SingletonEvent<BeginTakeActionEvent>.ID && ID != PooledEvent<CommandEvent>.ID)
            {
                return ID == TookDamageEvent.ID;
            }
            return true;
        }

        public override bool HandleEvent(TookDamageEvent E)
        {
           
            if (E.Actor != null && E.Actor != ParentObject && !ParentObject.OnWorldMap() && !E.Actor.HasPart<Quills>() && E.Damage.Amount > 0 && !E.Damage.HasAttribute("reflected") && E.Damage.HasAttribute("Melee"))
            {
               
                double num2 = E.Damage.Amount *0.2;
                int dmg = Convert.ToInt32(num2);
               
                if (dmg == 0)
                {
                    dmg = 1;
                  
                }
              
               
                if (dmg > 0)
                {
                    if (ParentObject.IsPlayer())
                    {
                        IComponent<GameObject>.AddPlayerMessage(E.Actor.Does("impale") + " " + E.Actor.itself + " on the spiked collar and" + E.Actor.GetVerb("take") + " " + dmg + " damage!", 'G');
                    }
                    else if (E.Actor != null)
                    {
                        if (E.Actor.IsPlayer())
                        {
                            IComponent<GameObject>.AddPlayerMessage("You impale " + E.Actor.itself + " on the spiked collar and take " + dmg + " damage!", 'R');
                        }
                        else if (IComponent<GameObject>.Visible(E.Actor))
                        {
                            if (E.Actor.IsPlayerLed())
                            {
                                IComponent<GameObject>.AddPlayerMessage(E.Actor.Does("impale") + " " + E.Actor.itself + " on the spiked collar and" + E.Actor.GetVerb("take") + " " + dmg + " damage!", 'r');
                            }
                            else
                            {
                                IComponent<GameObject>.AddPlayerMessage(E.Actor.Does("impale") + " " + E.Actor.itself + " on the spiked collar and" + E.Actor.GetVerb("take") + " " + dmg + " damage!", 'g');
                            }
                        }



                        Event @event = new Event("TakeDamage");
                        Damage damage = new Damage(dmg);
                        damage.Attributes = new List<string>(E.Damage.Attributes);
                        if (!damage.HasAttribute("reflected"))
                        {
                            damage.Attributes.Add("reflected");
                        }
                        @event.SetParameter("Damage", damage);
                        @event.SetParameter("Owner", ParentObject);
                        @event.SetParameter("Attacker", ParentObject);
                        @event.SetParameter("Message", null);
                        E.Actor.FireEvent(@event);
                        ParentObject.FireEvent("ReflectedDamage");
                    }
                }
            }
            return base.HandleEvent(E);
        }

    }
}