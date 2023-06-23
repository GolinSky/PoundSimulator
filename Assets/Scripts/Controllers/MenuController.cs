using CodeFramework.Runtime;
using PoundSimulator.Services;

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
        private IGameFlowService gameFlowService;

        protected override void OnInit()
        {
            base.OnInit();
            gameFlowService = ServiceHub.Get<IGameFlowService>();
        }

        public void OnStartGame()
        {
            gameFlowService.StartCoreGame();
        }

        public void OnExitGame()
        {
            gameFlowService.ExitApplication();
        }
    }
}