using CodeFramework;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Scenes;
using UnityEngine;


namespace PoundSimulator.Services
{
    public interface IGameFlowService:IService
    {
        void StartCoreGame();
        void ExitApplication();
    }
    public class GameFlowService: Service, IGameFlowService
    {
        private readonly SceneService<PoundSceneName> sceneService;

        public GameFlowService(IGameService gameService, SceneService<PoundSceneName> sceneService) : base(gameService)
        {
            this.sceneService = sceneService;
        }

        public void StartCoreGame()
        {
            sceneService.LoadScene(PoundSceneName.Main);
        }

        public void ExitApplication()
        {
            //todo: need to call gameservice to dispose all entities
            Application.Quit();
        }
    }
}