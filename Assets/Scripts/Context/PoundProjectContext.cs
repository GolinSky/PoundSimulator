using System.Collections.Generic;
using CodeFramework;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Scenes;
using PoundSimulator.Services;

namespace PoundSimulator.Context
{
    public class PoundProjectContext:ProjectContext
    {
        public override List<IService> Data { get; }
        private SceneService<PoundSceneName> SceneService { get; }

        public override List<IService> LoadContext()
        {
            return new List<IService>
            {
                new GameFlowService(GameService, SceneService)
            };
        }

        public PoundProjectContext(IGameService gameService, SceneService<PoundSceneName> sceneService) : base(gameService)
        {
            SceneService = sceneService;
        }
    }
}