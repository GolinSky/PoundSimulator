using System.Collections.Generic;
using CodeFramework;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.View;
using PoundSimulator.Context;

namespace PoundSimulator.Scenes
{
    public class PoundSceneMap : SceneMap<PoundSceneName>
    {
        private List<Controller> contextData;

        protected override PoundSceneName DefaultSceneKey => PoundSceneName.Menu;
        protected override string ModelPath => "PoundSceneModel";
        protected override ProjectContext ProjectContext { get; }
        protected IFactory<ViewBinding, Controller> ViewFactory { get; private set; }

        protected override Dictionary<PoundSceneName, SceneContext> SceneContexts =>
            new()
            {
                { PoundSceneName.Menu, new MenuSceneContext(ViewFactory) }
            };
        

        public PoundSceneMap(IGameService gameService) : base(gameService)
        {
            ProjectContext = new PoundProjectContext();
            ViewFactory = gameService.ViewFactory;
        }


        protected override void OnProjectContextLoaded(List<IService> services)
        {
            ServiceHub = new ServiceHub(services);
        }
    }
}