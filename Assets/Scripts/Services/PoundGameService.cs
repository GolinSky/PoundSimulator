using CodeFramework;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.Factory;
using PoundSimulator.Scenes;

namespace PoundSimulator.Services
{
    public sealed class PoundGameService:GameService
    {
        protected override BehaviourMap SceneMap { get;  }

        public PoundGameService()
        {
            Repository = new AddressableRepository();
            ViewFactory = new ViewFactory(Repository);
            SceneMap = new PoundSceneMap(this);
        }

        protected override void OnStart()
        {
         
        }

        protected override void OnBeforeStart()
        {
        }
    }
}
