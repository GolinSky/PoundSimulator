using System.Numerics;
using CodeFramework.Runtime;
using PoundSimulator.Services;

namespace PoundSimulator.Controllers
{
    public interface IPlayerViewController : IViewController
    {
        
    }
    
    public interface IPlayerController: IController, IPlayerViewController
    {
        
    }

    public class PlayerController: Controller, IPlayerController
    {
        private IInputService inputService;
//todo: find view by controller
        protected override void OnInit()
        {
            base.OnInit();
            inputService = ServiceHub.Get<IInputService>();
            inputService.OnInput += OnInput;
        }

        protected override void OnRelease()
        {
            base.OnRelease();
            inputService.OnInput -= OnInput;

        }

        private void OnInput(Vector2 vector2)
        {
            
        }
    }
}