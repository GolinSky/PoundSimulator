using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Components;
using PoundSimulator.Services;
using UnityEngine;

namespace PoundSimulator.Controllers
{
    public interface IPlayerViewController : IViewController
    {
        
    }

    public class PlayerController: Controller, IPlayerViewController
    {
        private IInputService inputService;
        private MoveComponent moveComponent;
        private ObjectsInteractionService objectsInteractionService;
        private IPositionProviderService positionProviderService;

        public PlayerController(IGameService gameService) : base(gameService)
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

            moveComponent = GetComponent<MoveComponent>();
            inputService = ServiceHub.Get<IInputService>();
            objectsInteractionService = ServiceHub.Get<ObjectsInteractionService>();
            inputService.OnInput += OnInput;
            moveComponent.Move(positionProviderService.GetRandomPosition());
        }

        protected override void OnRelease()
        {
            base.OnRelease();
            inputService.OnInput -= OnInput;
        }

        private void OnInput(Vector2 screenPosition)
        {
            //todo: check yard via service
            if (Camera.main != null) //move camera to service
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
                var canMove = objectsInteractionService.IsPlayerInField(worldPosition);
                if (canMove)
                {
                    moveComponent.MoveTo(worldPosition);// use move to instead
                }
            }
        }
    }
}