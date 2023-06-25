using System.Collections.Generic;
using CodeFramework.Runtime;
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
            inputService = ServiceHub.Get<IInputService>();
            inputService.OnInput += OnInput;
            moveComponent = GetComponent<MoveComponent>();
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
                moveComponent.Move(worldPosition);// use move to instead
            }
        }
    }
}