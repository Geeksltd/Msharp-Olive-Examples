using MSharp;
namespace Admin.StockRoomItems
{
    class EnterPage : SubPage<Admin.StockRoomItemsPage>
    {
        public EnterPage()
        {
            Add<Modules.StockRoomItemForm>();
        }
    }
}