using System.Collections.Generic;
using CodeFramework;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Scenes;
using PoundSimulator.Services;

namespace PoundSimulator.Context
{
    public class PoundProjectContext:ProjectContext
    {
        private SceneService<PoundSceneName> SceneService { get; }

        public override List<IService> LoadContext()
        {
            return new List<IService>
            {
                new GameFlowService(GameService, SceneService),
                new InputService(GameService),
                new ObjectsInteractionService(GameService)
            };
        }

        public PoundProjectContext(IGameService gameService, SceneService<PoundSceneName> sceneService) : base(gameService)
        {
            SceneService = sceneService;
        }
    }
}