using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Controllers;
using PoundSimulator.View;

namespace PoundSimulator.Context
{
    public class CoreSceneContext:SceneContext
    {
        public CoreSceneContext(IGameService gameService) : base(gameService)
        {
        }
        
        public override List<Controller> LoadContext()
        {
            return new List<Controller>
            {
                Construct<PlayerController>(),
                Construct<GameFieldController>()
            };
        }
    }
}