using CodeFramework.Runtime;



namespace Controllers
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