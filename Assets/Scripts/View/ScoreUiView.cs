using CodeFramework.Runtime.View;
using PoundSimulator.Controllers;
using TMPro;
using UnityEngine;

namespace PoundSimulator.View
{
    public class ScoreUiView:View<IScoreUiViewController>
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private string originScoreLabelText;
        
        public override ViewType ViewType => ViewType.Ui;

        protected override void OnInit()
        {
            base.OnInit();
            originScoreLabelText = scoreText.text;
            ViewController.OnScoreUpdated += UpdateScore;
        }

        private void UpdateScore(int score)
        {
            scoreText.text = $"{originScoreLabelText}: {score}";
        }
    }
}