using CodeFramework.Runtime.View;
using PoundSimulator.Controllers;
using PoundSimulator.Services;
using UnityEngine;

namespace PoundSimulator.View
{
    public class PlayerView: View<IPlayerViewController>, Interactive
    {
        [SerializeField] private Collider2D collider2D;
        public override ViewType ViewType => ViewType.Default;

        protected override void OnInit()
        {
            base.OnInit();
            ViewController.GetService<IObjectsLocationViewService>().Register(GameObjectType.Player, this);
        }
        
        protected override void OnBeforeDestroy()
        {
            base.OnBeforeDestroy();
        }

        public Bounds Bounds => collider2D.bounds;
        
        
        public bool IsIntersects(Interactive interactive, Vector3 targetPosition)
        {
            var bounds = Bounds;
            bounds.center = targetPosition;
            return bounds.Intersects(interactive.Bounds);
        }
    }

    public interface Interactive
    {
        Bounds Bounds { get; }
        bool IsIntersects(Interactive interactive, Vector3 targetPosition);
    }
}