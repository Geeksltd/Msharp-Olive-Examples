using MSharp;

namespace Modules
{
    class TheClassList : ListModule<Domain.TheClass>
    {
        public TheClassList()
        {
            // TODO: Configure me ...!
            HeaderText("The classes");
            
            Search(GeneralSearch.AllFields).Label("Find:");
            // ...
            
            Column(x => x.Name);
            Column(x => x.Type);
            
            ButtonColumn("Edit").HeaderText("Actions").GridColumnCssClass("actions").Icon(FA.Edit)
                .OnClick(x => x.Go<Admin.TheClasses.EnterPage>().Send("item", "item.ID"));
            
            Button("New The class").Icon(FA.Plus)
                .OnClick(x => x.Go<Admin.TheClasses.EnterPage>());
        }
    }
}