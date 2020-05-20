using MSharp;

namespace Modules
{
    class TheClassForm : FormModule<Domain.TheClass>
    {
        public TheClassForm()
        {
            // TODO: Configure me ...!
            HeaderText("The class details");
            
            Field(x => x.Name);
            Field(x => x.Type).Mandatory()
                .AsRadioButtons(Arrange.Horizontal, imageUrl: "item.Image.Url()");

            Field(x => x.OptionsLinks)
                .AsCheckBoxes(Arrange.Horizontal, faIconName: "item.Brand.ToLower()");

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