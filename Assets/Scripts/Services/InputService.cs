using System;
using CodeFramework;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.Observer;
using UnityEngine;

namespace PoundSimulator.Services
{
    public interface IInputService:IService
    {
        event Action<Vector2> OnInput;
    }
    
    public class InputService: Service, IInputService, ICustomObserver<float>
    {
        private readonly ObserverSubject<float> tickService;
        public event Action<Vector2> OnInput;

        public InputService(IGameService gameService) : base(gameService)
        {
            tickService = gameService.TickService;
        }

        protected override void OnInit()
        {
            base.OnInit();
            tickService.AddObserver(this);
        }

        protected override void OnRelease()
        {
            base.OnRelease();
            if (tickService != null)
            {
                tickService.RemoveObserver(this);
            }
        }

        public void UpdateState(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnInput?.Invoke(Input.mousePosition);
            }
        }
    }
}