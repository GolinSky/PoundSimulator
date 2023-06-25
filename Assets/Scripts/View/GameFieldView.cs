using System;
using CodeFramework.Runtime.View;
using PoundSimulator.Controllers;
using PoundSimulator.Services;
using UnityEngine;

namespace PoundSimulator.View
{
    public class GameFieldView:View<IGameFieldViewController>
    {
        [SerializeField] private SpriteRenderer mySprite;
        public override ViewType ViewType => ViewType.Default;


        protected override void OnInit()
        {
            base.OnInit();
            ViewController.GetService<IObjectsLocationViewService>().UpdatePosition(GameObjectType.Yard, transform.position, mySprite.bounds.size);
        }
    }
}