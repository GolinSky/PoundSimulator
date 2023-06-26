using CodeFramework.Runtime.View;
using PoundSimulator.Controllers;

namespace PoundSimulator.View
{
    public class AnimalView:View<IAnimalViewController>
    {
        public override ViewType ViewType => ViewType.Default;
        
        
    }
}