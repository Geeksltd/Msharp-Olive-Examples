using MSharp;

namespace Modules
{
    class StockRoomItemForm : FormModule<Domain.StockRoomItem>
    {
        public StockRoomItemForm()
        {
            HeaderText("Stock room item details");

            Field(x => x.Amount);
            Field(x => x.Product);
            Field(x => x.ExpiryDate);
            Field(x => x.Description);

            Button("Cancel").OnClick(x => x.ReturnToPreviousPage());

            Button("Save").IsDefault().Icon(FA.Check)
            .OnClick(x =>
            {
                x.SaveInDatabase();
                x.GentleMessage("Saved successfully.");
                x.ReturnToPreviousPage();
            });
        }
    }
}