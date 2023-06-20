using System.Collections.Generic;
using CodeFramework;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.View;
using ExportPackage.Runtime.Scripts.Core;
using PoundSimulator.Context;
using UnityEngine.SceneManagement;

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
        
        protected override IHub<IService> ServiceHub { get; set; }

        public PoundSceneMap(IGameService gameService) : base(gameService)
        {
            ProjectContext = new PoundProjectContext();
            ViewFactory = gameService.ViewFactory;
        }


        protected override void OnSceneUnload(PoundSceneName key)
        {
            if (contextData != null)// todo:check if need key - dict 
            {
                foreach (var controller in contextData)
                {
                    controller.Release();
                }
            }
        }

        protected override void OnLoadScene(PoundSceneName key, LoadSceneMode loadSceneMode)
        {
            if (SceneContexts.TryGetValue(key, out var context))
            {
                contextData = context.LoadContext();

                foreach (var controller in contextData)
                {
                    controller.Init(ServiceHub);
                }
            }
            
        }

        protected override void OnProjectContextLoaded(List<IService> services)
        {
            ServiceHub = new ServiceHub(services);
            
        }
    }
}