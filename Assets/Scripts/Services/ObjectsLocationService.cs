using System.Collections.Generic;
using CodeFramework;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.View.Components;
using UnityEngine;

namespace PoundSimulator.Services
{
    public interface IObjectsInteractionViewService:IViewService
    {
        void Register(GameObjectType type, Interactive interactive);
        void UnRegister(GameObjectType type);
    }
    public class ObjectsInteractionService:Service, IObjectsInteractionViewService
    {
        private Dictionary<GameObjectType, Interactive> dictionary = new Dictionary<GameObjectType, Interactive>();

        public ObjectsInteractionService(IGameService gameService) : base(gameService)
        {
        }
        
        public void Register(GameObjectType type, Interactive interactive)
        {
            dictionary[type] = interactive;
        }

        public void UnRegister(GameObjectType type)
        {
            throw new System.NotImplementedException();
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