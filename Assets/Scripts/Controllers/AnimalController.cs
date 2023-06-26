using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Components;
using PoundSimulator.Services;

namespace PoundSimulator.Controllers
{
    public interface IAnimalViewController:IViewController
    {
        
    }
    
    public class AnimalController: Controller, IAnimalViewController
    {
        private IPositionProviderService positionProviderService;
        private IAnimalService animalService;
        private MoveComponent moveComponent;
        
        public AnimalController(IGameService gameService) : base(gameService)
        {
        }
        
        protected override List<Component<IController>> BuildsComponents()
        {
            return new List<Component<IController>>
            {
                new MoveComponent()
            };
        }

        protected override void OnInit()
        {
            base.OnInit();
            positionProviderService = ServiceHub.Get<IPositionProviderService>();
            animalService = ServiceHub.Get<IAnimalService>();
            animalService.Register(this);
            
            moveComponent = GetComponent<MoveComponent>();
            moveComponent.Move(positionProviderService.GetRandomPosition());
        }

        protected override void OnRelease()
        {
            base.OnRelease();
            if (animalService != null)
            {
                animalService.UnRegister(this);
            }
        }
    }
}