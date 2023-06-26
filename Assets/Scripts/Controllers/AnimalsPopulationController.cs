using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.Observer;
using PoundSimulator.Services;
using UnityEngine;

namespace PoundSimulator.Controllers
{
    public class AnimalsPopulationController: Controller, ICustomObserver<float>
    {
        private const int MaxAnimals = 15;
        
        private const int MinAmount = 2;
        private const int MaxAmount = 6;

        private const float MinInterval = 5;
        private const float MaxInterval = 15;

        private IAnimalService animalsService;
        private float timer;
        public override bool HasView => false;//fix 

        public AnimalsPopulationController(IGameService gameService) : base(gameService)
        {
            
        }

        protected override void OnInit()
        {
            base.OnInit();
            animalsService = GetService<IAnimalService>();
            SpawnAnimals();

            UpdateTimer();
            TickService.AddObserver(this);
        }

        protected override void OnRelease()
        {
            base.OnRelease();
            TickService.RemoveObserver(this);
        }

        private void SpawnAnimals()
        {
            var count = Random.Range(MinAmount, MaxAmount);
            for (int i = 0; i < count; i++)
            {
                GameFactory.AddController<AnimalController>();
            }
        }

        private void UpdateTimer()
        {
            timer = Time.time + Random.Range(MinInterval, MaxInterval);
        }

        private void TryAddMoreAnimals()
        {
            var animalCount = animalsService.AnimalCount;
            if (animalCount < MaxAnimals)
            {
                SpawnAnimals();
            }
        }

        public void UpdateState(float state)
        {
            if (timer < Time.time)
            {
                UpdateTimer();
                TryAddMoreAnimals();
            }
        }
    }
}