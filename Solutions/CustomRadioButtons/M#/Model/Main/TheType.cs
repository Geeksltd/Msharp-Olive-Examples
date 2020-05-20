using MSharp;

namespace Domain
{
    class TheType : EntityType
    {
        public TheType()
        {
            String("Title");
            SecureImage("Image")
                .PreserveTransparency()
                .AutoOptimize(false);
        }
    }
}