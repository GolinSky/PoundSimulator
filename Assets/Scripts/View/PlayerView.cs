using CodeFramework.Runtime.View;
using PoundSimulator.Components;
using PoundSimulator.Controllers;
using UnityEngine;

namespace PoundSimulator.View
{
    public class PlayerView: View<IPlayerViewController>
    {
        private IMoveComponentObserver moveComponent;
        public override ViewType ViewType => ViewType.Default;

        protected override void OnInit()
        {
            base.OnInit();
            moveComponent = ViewController.GetComponentObserver<IMoveComponentObserver>();
            moveComponent.OnPositionChanged += Move;
        }
        
        protected override void OnBeforeDestroy()
        {
            base.OnBeforeDestroy();
            moveComponent.OnPositionChanged -= Move;
        }
        
        private void Move(Vector2 vector2)
        {
            Transform.position = vector2;
        }
    }
}