using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.Observer;
using PoundSimulator.Components;
using PoundSimulator.Services;
using PoundSimulator.View.Components;

namespace PoundSimulator.Controllers
{
    public interface IAnimalViewController:IViewController
    {
    }

    public enum AnimalMoveMode
    {
        Default = 0,
        FollowPlayer = 1,
        Stopped = 2,
    }
    public class AnimalController: Controller, IAnimalViewController, ICustomObserver<float>
    {
        private const float MaxDistance = 1f;
        
        private ObjectsInteractionService objectsInteractionService;
        private IPositionProviderService positionProviderService;
        private IAnimalService animalService;
        private MoveComponent moveComponent;
        private Interactive yardInteractive;
        private Interactive animalInteractive;
        
        public AnimalMoveMode AnimalMoveMode { get; private set; }


        public AnimalController(IGameService gameService) : base(gameService)
        {
            AnimalMoveMode = AnimalMoveMode.Default;
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
            animalService = GetService<IAnimalService>();
            animalService.Register(this);
            
            positionProviderService = GetService<IPositionProviderService>();
            moveComponent = GetComponent<MoveComponent>();
            moveComponent.Move(positionProviderService.GetRandomPosition());

            objectsInteractionService = GetService<ObjectsInteractionService>();

            TickService.AddObserver(this);

        }

        protected override void OnRelease()
        {
            base.OnRelease();
            if (animalService != null)
            {
                animalService.UnRegister(this);
            }

            if (TickService != null)
            {
                TickService.RemoveObserver(this);
            }
        }

        public void UpdateState(float deltaTime)
        {
            switch (AnimalMoveMode)
            {
                case AnimalMoveMode.Default:
                    var canFollowPlayer = objectsInteractionService.CheckAnimalNearPlayer(this, MaxDistance);
                    if (canFollowPlayer && animalService.CanFollowPlayer())
                    {
                        AnimalMoveMode = AnimalMoveMode.FollowPlayer;
                        moveComponent.Follow(objectsInteractionService.Player);
                        animalInteractive = objectsInteractionService.GetAnimalInteractive(this);
                        yardInteractive = objectsInteractionService.Yard;
                    }
                    break;
                case AnimalMoveMode.FollowPlayer:
                    if (yardInteractive.IsIntersects(animalInteractive))
                    {
                        OnYardArrived();
                        AnimalMoveMode = AnimalMoveMode.Stopped;
                    }
                    break;
            }
        }

        private void OnYardArrived()
        {
            if (AnimalMoveMode == AnimalMoveMode.FollowPlayer)
            {
                animalService.MoveToTheYard(this);
                GameFactory.RemoveController(this);
            }
        }
    }
}