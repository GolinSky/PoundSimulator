using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;

namespace PoundSimulator.Controllers
{
    public interface IGameFieldViewController:IViewController
    {
        
    }
    public class GameFieldController: Controller, IGameFieldViewController
    {
        public GameFieldController(IGameService gameService) : base(gameService)
        {
            
        }
    }
}