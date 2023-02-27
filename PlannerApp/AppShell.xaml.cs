using PlannerApp.View;

namespace PlannerApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Orders), typeof(Orders));
            Routing.RegisterRoute(nameof(GenerateTO), typeof(GenerateTO));
        }
    }
}