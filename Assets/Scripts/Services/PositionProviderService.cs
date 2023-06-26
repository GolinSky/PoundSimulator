using CodeFramework;
using CodeFramework.Runtime.BaseServices;
using UnityEngine;

namespace PoundSimulator.Services
{
    public interface IPositionProviderService:IService
    {
        Vector2 GetRandomPosition();
    }
    public class PositionProviderService:Service, IPositionProviderService
    {
        private ObjectsInteractionService objectsInteractionService;

        public PositionProviderService(IGameService gameService) : base(gameService)
        {
        }

        protected override void OnInit()
        {
            base.OnInit();
            objectsInteractionService = ServiceHub.Get<ObjectsInteractionService>();
        }

        public Vector2 GetRandomPosition()
        {
            var bounds = objectsInteractionService.FieldBounds;
            Vector2 spawnPosition = Vector2.zero;
            spawnPosition.x = Random.Range(bounds.min.x, bounds.max.x);
            spawnPosition.y = Random.Range(bounds.min.y, bounds.max.y);
            return spawnPosition;
        }
    }
}