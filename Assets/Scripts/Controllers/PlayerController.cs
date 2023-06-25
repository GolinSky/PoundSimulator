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
    
    public interface IPlayerController: IController, IPlayerViewController
    {
        
    }

    public class PlayerController: Controller, IPlayerController
    {
        private IInputService inputService;
        private MoveComponent moveComponent;

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
            moveComponent = GetComponent<MoveComponent>();
            inputService = ServiceHub.Get<IInputService>();
            inputService.OnInput += OnInput;
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
                moveComponent.MoveTo(worldPosition);// use move to instead
            }
        }
    }
}