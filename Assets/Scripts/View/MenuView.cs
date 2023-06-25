using CodeFramework.Runtime.View;
using PoundSimulator.Controllers;
using UnityEngine;
using UnityEngine.UI;


namespace PoundSimulator.View
{
    public sealed class MenuView : View<IMenuViewController>
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        public override ViewType ViewType => ViewType.Ui;

        protected override void OnInit()
        {
            base.OnInit();
            startButton.onClick.AddListener(ViewController.OnStartGame);
            exitButton.onClick.AddListener(ViewController.OnExitGame);
        }

        protected override void OnBeforeDestroy()
        {
            base.OnBeforeDestroy();
            startButton.onClick.RemoveListener(ViewController.OnStartGame);
            exitButton.onClick.RemoveListener(ViewController.OnExitGame);
        }
    }
}