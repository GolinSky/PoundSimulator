using System.Collections.Generic;
using CodeFramework;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.View;
using PoundSimulator.Controllers;

namespace PoundSimulator.Context
{
    public class MenuSceneContext:SceneContext
    {
        public MenuSceneContext(IFactory<ViewBinding, Controller> viewFactory) : base(viewFactory)
        {
        }

        public override List<Controller> Data { get; }
        public override List<Controller> LoadContext()
        {
            return new List<Controller>
            {
                new MenuController()
            };
        }
    }
}