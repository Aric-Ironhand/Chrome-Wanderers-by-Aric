using System;
using XRL.UI;
using XRL.World.AI;
using XRL.World.Conversations.Parts;
using XRL.World.Effects;
using XRL.World.ZoneParts;
using XRL.World.ZoneBuilders;

namespace XRL.World.Conversations.Parts
{
    public class Aric_CW_RescuePrisoner : IConversationPart
    {
        // What we want:
        //When the choice is clicked
        //set the player to leader
        //set the object's brain part to mobile=true
        //make any goatfolk consider this a hostile action.

        string faction = "Goatfolk";

        public override bool WantEvent(int ID, int Propagation)
        {
            return base.WantEvent(ID, Propagation)
                || ID == EnteredElementEvent.ID;

        }

        public override bool HandleEvent(EnteredElementEvent E)
        {
            
                       
            GameObject prisoner = The.Speaker;
            The.Speaker.SetAlliedLeader<AllyProselytize>(The.Player);
            if (The.Speaker.TryGetEffect(out Lovesick love))
            {
                love.PreviousLeader = The.Player;
            }

            Popup.Show("You break the bonds of the prisoner. They join you! Any remaining goatfolk will not take kindly to this.");

            The.Speaker.Brain.Mobile = true;

            foreach (GameObject goat in The.Player.CurrentZone.FindObjects((GameObject o) => o.BelongsToFaction(faction)))
            {
                //Make hostile.
                goat.AddOpinion<OpinionGoad>(The.Player);
            }

                return base.HandleEvent(E);
        }

    }
}
