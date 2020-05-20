using MSharp;

namespace Domain
{
    class Product : EntityType
    {
        public Product()
        {
            String("Title");
            Associate<Brand>("Brand");
        }
    }
}