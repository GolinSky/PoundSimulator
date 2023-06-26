using CodeFramework.Runtime;
using CodeFramework.Runtime.View.Component;
using PoundSimulator.Services;
using UnityEngine;

namespace PoundSimulator.View.Components
{
    public interface Interactive //refactor - not determine system here
    {
        Bounds Bounds { get; }
        bool IsIntersects(Interactive interactive, Vector3 targetPosition);
        
        IViewController Controller { get; }
    }
    
    public class InteractiveViewComponent:ViewComponent, Interactive
    {
        [SerializeField] private GameObjectType gameObjectType;
        [SerializeField] private Collider2D collider2D;
        public Bounds Bounds => collider2D.bounds;

        public IViewController Controller => ViewController;

        protected override void OnInit()
        {
            base.OnInit();
            
            ViewController.GetService<IObjectsInteractionViewService>().Register(gameObjectType, this);
        }

        public bool IsIntersects(Interactive interactive, Vector3 targetPosition)
        {
            var bounds = Bounds;
            bounds.center = targetPosition;
            return bounds.Intersects(interactive.Bounds);
        }

    }
}