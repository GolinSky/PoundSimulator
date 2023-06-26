using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;

namespace PoundSimulator.Controllers
{
    public interface IYardViewController:IViewController
    {
        
    }
    public class YardController:Controller, IYardViewController
    {
        public YardController(IGameService gameService) : base(gameService)
        {
        }
    }
}