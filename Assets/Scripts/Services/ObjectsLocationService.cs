using System.Collections.Generic;
using CodeFramework;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.View.Components;
using UnityEngine;

namespace PoundSimulator.Services
{
    public interface IObjectsInteractionViewService:IViewService
    {
        void Register(GameObjectType type, Interactive interactive);
        Bounds FieldBounds { get; }
    }
    public class ObjectsInteractionService:Service, IObjectsInteractionViewService
    {

        private Interactive player;
        private Interactive yard;

        private List<Interactive> animals = new List<Interactive>();
        
        public Bounds FieldBounds => yard.Bounds;

        public ObjectsInteractionService(IGameService gameService) : base(gameService)
        {
        }
        
        public void Register(GameObjectType type, Interactive interactive)
        {
            switch (type)
            {
                case GameObjectType.Yard:
                    yard = interactive;
                    break;
                case GameObjectType.Player:
                    player = interactive;
                    break;
                case GameObjectType.Animals:
                    animals.Add(interactive);
                    break;
            }
        }

        
        public bool IsPlayerInField(Vector2 targetPosition)
        {
            return player.IsIntersects(yard, targetPosition);
        }

        public bool IsAnimalInField(IViewController controller, Vector2 targetPosition)
        {
            foreach (var interactive in animals)
            {
                if (interactive.Controller == controller)
                {
                    return interactive.IsIntersects(yard, targetPosition);
                }
            }
            
            return false;
        }
    }

    public enum GameObjectType
    {
        Yard = 0,
        Player = 1,
        Animals = 2,
    }
}