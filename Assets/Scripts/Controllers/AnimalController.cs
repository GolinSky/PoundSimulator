using System;
using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.Observer;
using PoundSimulator.Components;
using PoundSimulator.Services;
using PoundSimulator.View.Components;
using UnityEngine;

namespace PoundSimulator.Controllers
{
    public interface IAnimalViewController:IViewController
    {
        
    }

    public enum AnimalMoveMode
    {
        Default = 0,
        FollowPlayer = 1,
    }
    public class AnimalController: Controller, IAnimalViewController, ICustomObserver<float>
    {
        private const float MaxDistance = 1f;
        
        private ObjectsInteractionService objectsInteractionService;
        private IPositionProviderService positionProviderService;
        private IAnimalService animalService;
        private MoveComponent moveComponent;
        private AnimalMoveMode animalMoveMode;

        public AnimalController(IGameService gameService) : base(gameService)
        {
            animalMoveMode = AnimalMoveMode.Default;
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
            switch (animalMoveMode)
            {
                case AnimalMoveMode.Default:
                    var canFollowPlayer = objectsInteractionService.CheckAnimalNearPlayer(this, MaxDistance);
                    if (canFollowPlayer)
                    {
                        animalMoveMode = AnimalMoveMode.FollowPlayer;
                        moveComponent.Follow(objectsInteractionService.Player);
                    }
                    break;
                case AnimalMoveMode.FollowPlayer:

                        
            
                    break;
                
            }
           
        }
    }
}