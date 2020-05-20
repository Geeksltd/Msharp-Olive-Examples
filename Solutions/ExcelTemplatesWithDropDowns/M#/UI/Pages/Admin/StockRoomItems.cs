using MSharp;
namespace Admin
{
    class StockRoomItemsPage : SubPage<AdminPage>
    {
        public StockRoomItemsPage()
        {
            Add<Modules.StockRoomItemList>();
        }
    }
}