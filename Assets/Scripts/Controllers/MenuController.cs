using CodeFramework.Runtime;

namespace PoundSimulator.Controllers
{
    public interface IMenuViewController : IViewController
    {
        void OnStartGame();
        void OnExitGame();
    }

    public interface IMenuController : IController, IMenuViewController
    {
    }

    public class MenuController : Controller, IMenuController
    {
        public void OnStartGame()
        {
            
        }

        public void OnExitGame()
        {
        }
    }
}