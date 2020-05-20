using MSharp;
namespace Admin.TheClasses
{
    class EnterPage : SubPage<Admin.TheClassesPage>
    {
        public EnterPage()
        {
            Add<Modules.TheClassForm>();
        }
    }
}