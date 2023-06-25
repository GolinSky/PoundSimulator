using CodeFramework.Runtime.View;
using PoundSimulator.Controllers;
using PoundSimulator.Services;
using UnityEngine;

namespace PoundSimulator.View
{
    public class GameFieldView:View<IGameFieldViewController>, Interactive
    {
        [SerializeField] private SpriteRenderer mySprite;
        [SerializeField] private Collider2D collider2D;
        public override ViewType ViewType => ViewType.Default;


        protected override void OnInit()
        {
            base.OnInit();
            ViewController.GetService<IObjectsLocationViewService>().Register(GameObjectType.Yard, this);
        }

        public Bounds Bounds => collider2D.bounds;
        
        
        public bool IsIntersects(Interactive interactive, Vector3 targetPosition)
        {
            var bounds = Bounds;
            bounds.center = targetPosition;
            return bounds.Intersects(interactive.Bounds);
        }
    }
}