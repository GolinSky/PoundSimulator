using System;
using System.Collections.Generic;
using CodeFramework;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Controllers;

namespace PoundSimulator.Services
{
    public interface IAnimalViewService : IViewService
    {
        int AnimalCount { get; }
    }

    public interface IAnimalService : IService, IAnimalViewService
    {
        event Action OnAnimalGoToTheYard;
        bool CanFollowPlayer();

        void Register(AnimalController animalController); //use interface instead
        void UnRegister(AnimalController animalController); //use interface instead
        void MoveToTheYard(AnimalController animalController);
    }

    public class AnimalsService : Service, IAnimalService
    {
        private const int MaxGroupAmount = 5;
        private List<AnimalController> animalControllers = new List<AnimalController>();

        public event Action OnAnimalGoToTheYard;
        public int AnimalCount => animalControllers.Count;


        public AnimalsService(IGameService gameService) : base(gameService)
        {
        }

        public void Register(AnimalController animalController)
        {
            if (animalControllers.Contains(animalController)) return;

            animalControllers.Add(animalController);
        }

        public void UnRegister(AnimalController animalController)
        {
            animalControllers.Remove(animalController);
        }

        public void MoveToTheYard(AnimalController animalController)
        {
            OnAnimalGoToTheYard?.Invoke();
            UnRegister(animalController);
        }

        public bool CanFollowPlayer()
        {
            int count = 0;
            foreach (var animalController in animalControllers)
            {
                if (animalController.AnimalMoveMode == AnimalMoveMode.FollowPlayer)
                {
                    count++;
                }
            }

            return MaxGroupAmount > count;
        }
    }
}