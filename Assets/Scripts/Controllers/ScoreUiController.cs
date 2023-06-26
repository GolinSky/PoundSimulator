using System;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Services;

namespace PoundSimulator.Controllers
{
    public interface IScoreUiViewController:IViewController
    {
        event Action<int> OnScoreUpdated;
    }
    
    public class ScoreUiController:Controller, IScoreUiViewController
    {
        public event Action<int> OnScoreUpdated;

        private IAnimalService animalService;
        private int animalCount;
        
        public ScoreUiController(IGameService gameService) : base(gameService)
        {
        }

        protected override void OnInit()
        {
            base.OnInit();
            animalService = GetService<IAnimalService>();
            animalService.OnAnimalGoToTheYard += UpdateScore;
        }

        protected override void OnRelease()
        {
            base.OnRelease();
            animalService.OnAnimalGoToTheYard -= UpdateScore;
        }

        private void UpdateScore()
        {
            animalCount++;
            OnScoreUpdated?.Invoke(animalCount);
        }
    }
}