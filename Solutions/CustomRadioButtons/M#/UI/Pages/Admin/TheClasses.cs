using MSharp;
namespace Admin
{
    class TheClassesPage : SubPage<AdminPage>
    {
        public TheClassesPage()
        {
            Add<Modules.TheClassList>();
        }
    }
}