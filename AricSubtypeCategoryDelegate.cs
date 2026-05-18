using System;


//While this has Aric in the name, this is purely for consistency and to satisfy prefixing requirements. It is actually the product of books/librarianmage, who put it on the Caves of Qud modding discord


namespace XRL.World.Conversations
{
    [HasConversationDelegate]
    public class AricSubtypeCategoryDelegate
    {
        [ConversationDelegate(Speaker = true)]
        public static bool IfSubtypeCategory(DelegateContext Context) =>
            SubtypeFactory.TryGetSubtypeEntry(Context.Target.GetSubtype(), out SubtypeEntry subtypeEntry)
            && subtypeEntry.Category is SubtypeCategory subtypeCategory
            && Context.Value.HasDelimitedSubstring(',', subtypeCategory.Name);
    }
}