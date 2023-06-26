using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Services;
using UnityEngine;

namespace PoundSimulator.Controllers
{
    public class AnimalsPopulationController:Controller
    {
        private IAnimalService animalsService;
        private const int MinAmount = 2;
        private const int MaxAmount = 15;

        public override bool HasView => false;//fix 

        public AnimalsPopulationController(IGameService gameService) : base(gameService)
        {
        }

        protected override void OnInit()
        {
            base.OnInit();
            animalsService = ServiceHub.Get<IAnimalService>();
            var count = Random.Range(MinAmount, MaxAmount);
            for (int i = 0; i < count; i++)
            {
                GameFactory.AddController<AnimalController>();
            }
        }

        private void TryAddMoreAnimals()
        {
            var animalCount = animalsService.AnimalCount;
            if (animalCount < MaxAmount)
            {
                //spawm
            }
        }
        
        
    }
}