using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Controllers;

namespace PoundSimulator.Context
{
    public class CoreSceneContext:SceneContext
    {
        public override List<Controller> LoadContext()
        {
            return new List<Controller>
            {
                Construct<PlayerController>()
            };
        }
        
        private Controller Construct<TController>() where TController:Controller, new() //duplicate
        {
            return new TController();
        }
    }
}