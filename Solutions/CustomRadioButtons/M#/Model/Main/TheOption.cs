using MSharp;

namespace Domain
{
    class TheOption : EntityType
    {
        public TheOption()
        {
            String("Name");
            String("Brand");
        }
    }
}