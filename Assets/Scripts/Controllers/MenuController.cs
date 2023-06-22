using CodeFramework.Runtime;

namespace PoundSimulator.Controllers
{
    public interface IMenuViewController : IViewController
    {
    }

    public interface IMenuController : IController, IMenuViewController
    {
    }

    public class MenuController : Controller, IMenuController
    {
    }
}