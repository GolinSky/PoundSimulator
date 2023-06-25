using System.Collections.Generic;
using CodeFramework;
using CodeFramework.Runtime.BaseServices;
using UnityEngine;

namespace PoundSimulator.Services
{
    public interface IObjectsLocationViewService:IViewService
    {
        void UpdatePosition(GameObjectType type, Vector2 position, Vector2 size);
    }
    public class ObjectsLocationService:Service, IObjectsLocationViewService
    {
        private Dictionary<GameObjectType, Vector2> objectsLocationDictionary = new Dictionary<GameObjectType, Vector2>();


        public ObjectsLocationService(IGameService gameService) : base(gameService)
        {
        }

        public void UpdatePosition(GameObjectType type, Vector2 worldPosition, Vector2 size)
        {
            objectsLocationDictionary[type] = worldPosition;
        }
    }

    public enum GameObjectType
    {
        Yard = 0
    }
}