using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Components;
using PoundSimulator.Services;
using UnityEngine;

namespace PoundSimulator.Controllers
{
    public interface IAnimalViewController:IViewController
    {
        
    }
    
    public class AnimalController: Controller, IAnimalViewController
    {
        private ObjectsInteractionService objectsInteractionService;
        private IAnimalService animalService;
        private MoveComponent moveComponent;
        
        public AnimalController(IGameService gameService) : base(gameService)
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
            objectsInteractionService = ServiceHub.Get<ObjectsInteractionService>();
            moveComponent = GetComponent<MoveComponent>();
            animalService = ServiceHub.Get<IAnimalService>();
            animalService.Register(this);
            
            var bounds = objectsInteractionService.FieldBounds;
            Vector2 spawnPosition = Vector2.zero;
            spawnPosition.x = Random.Range(bounds.min.x, bounds.max.x);
            spawnPosition.y = Random.Range(bounds.min.y, bounds.max.y);
            moveComponent.Move(spawnPosition);
        }

        protected override void OnRelease()
        {
            base.OnRelease();
            if (animalService != null)
            {
                animalService.UnRegister(this);
            }
        }
    }
}