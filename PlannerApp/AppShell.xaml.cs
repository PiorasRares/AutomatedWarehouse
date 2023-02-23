using PlannerApp.View;

namespace PlannerApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Orders", typeof(Orders));
        }
    }
}