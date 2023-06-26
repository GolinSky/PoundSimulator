using CodeFramework.Runtime.View;
using PoundSimulator.Controllers;

namespace PoundSimulator.View
{
    public class YardView : View<IYardViewController>
    {
        public override ViewType ViewType => ViewType.Default;

    }
}