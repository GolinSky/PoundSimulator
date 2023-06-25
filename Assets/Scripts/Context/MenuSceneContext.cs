using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Controllers;

namespace PoundSimulator.Context
{
    public class MenuSceneContext:SceneContext
    {
        public override List<Controller> LoadContext()
        {
            return new List<Controller>
            {
                Construct<MenuController>()
            };
        }
        
        public MenuSceneContext(IGameService gameService) : base(gameService)
        {
        }
    }
}