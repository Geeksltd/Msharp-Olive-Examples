using MSharp;

namespace Domain
{
    class StockRoomItem : EntityType
    {
        public StockRoomItem()
        {
            Associate<Product>("Product");
            Decimal("Amount");
            Date("Expiry date");
            String("Description");
            Bool("Is on sale");
        }
    }
}