using MSharp;

namespace Domain
{
    class TheClass : EntityType
    {
        public TheClass()
        {
            String("Name");
            Associate<TheType>("Type");
            AssociateManyToMany<TheOption>("Options");
        }
    }
}