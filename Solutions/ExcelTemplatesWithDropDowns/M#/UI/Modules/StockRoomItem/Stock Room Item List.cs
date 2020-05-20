using Domain.Services;
using MSharp;

namespace Modules
{
    class StockRoomItemList : ListModule<Domain.StockRoomItem>
    {
        public StockRoomItemList()
        {
            HeaderText("Stock room items");

            Inject<ImportTemplateGenerator>().Name("TemplateGenerator");

            Search(GeneralSearch.AllFields).Label("Find:");
            
            Column(x => x.Amount);
            Column(x => x.Product);
            Column(x => x.ExpiryDate);
            Column(x => x.Description);
            
            ButtonColumn("Edit").HeaderText("Actions").GridColumnCssClass("actions").Icon(FA.Edit)
                .OnClick(x => x.Go<Admin.StockRoomItems.EnterPage>().Send("item", "item.ID"));
            
            Button("New Stock room item").Icon(FA.Plus)
                .OnClick(x => x.Go<Admin.StockRoomItems.EnterPage>());

            Button("Download import template")
                .OnClick(x =>
                {
                    x.CSharp("return File(await TemplateGenerator.Generate(), TemplateGenerator.ContentType, \"Template.xlsx\");");
                });
        }
    }
}