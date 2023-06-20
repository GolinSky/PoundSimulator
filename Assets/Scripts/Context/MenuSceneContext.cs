using System.Collections.Generic;
using CodeFramework;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.View;

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
            throw new System.NotImplementedException();
        }
    }
}