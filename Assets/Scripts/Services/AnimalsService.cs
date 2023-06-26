using System.Collections.Generic;
using CodeFramework;
using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Controllers;

namespace PoundSimulator.Services
{
    public interface IAnimalViewService:IViewService
    {
        int AnimalCount { get; }
    }
    public interface IAnimalService : IService, IAnimalViewService
    {
        void Register(AnimalController animalController);//use interface instead
        void UnRegister(AnimalController animalController);//use interface instead
    }
    
    public class AnimalsService:Service, IAnimalService
    {
        private List<AnimalController> animalControllers = new List<AnimalController>();

        public int AnimalCount => animalControllers.Count;

        
        public AnimalsService(IGameService gameService) : base(gameService)
        {
        }

        public void Register(AnimalController animalController)
        {
            if(animalControllers.Contains(animalController)) return;
            
            animalControllers.Add(animalController);
        }

        public void UnRegister(AnimalController animalController)
        {
            animalControllers.Remove(animalController);
        }

    }
}