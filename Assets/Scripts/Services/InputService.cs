using System;
using System.Numerics;
using CodeFramework;
using CodeFramework.Runtime.BaseServices;

namespace PoundSimulator.Services
{
    public interface IInputService:IService
    {
        event Action<Vector2> OnInput;
    }
    
    /// <summary>
    /// register here a location(yard)
    /// return global coord using inside a screen point
    /// </summary>
    public class InputService: Service, IInputService
    {
        public event Action<Vector2> OnInput;

        public InputService(IGameService gameService) : base(gameService)
        {
            
        }

    }
}