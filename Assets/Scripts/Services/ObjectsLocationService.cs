using System.Collections.Generic;
using CodeFramework;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.View;
using UnityEngine;

namespace PoundSimulator.Services
{
    public interface IObjectsLocationViewService:IViewService
    {
        void Register(GameObjectType type, Interactive interactive);
    }
    public class ObjectsInteractionService:Service, IObjectsLocationViewService
    {
        private Dictionary<GameObjectType, Interactive> dictionary = new Dictionary<GameObjectType, Interactive>();

        public ObjectsInteractionService(IGameService gameService) : base(gameService)
        {
        }
        
        public void Register(GameObjectType type, Interactive interactive)
        {
            dictionary[type] = interactive;
        }

        public bool IsIntersects(GameObjectType left, GameObjectType right, Vector2 targetPosition)
        {
            return dictionary[left].IsIntersects(dictionary[right], targetPosition);//not fast&secure access via key
        }
    }

    public enum GameObjectType
    {
        Yard = 0,
        Player = 1,
    }
}