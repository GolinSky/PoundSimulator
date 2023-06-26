using CodeFramework.Runtime.View;
using PoundSimulator.Controllers;

namespace PoundSimulator.View
{
    public class PlayerView: View<IPlayerViewController>
    {
        public override ViewType ViewType => ViewType.Default;
    }
}