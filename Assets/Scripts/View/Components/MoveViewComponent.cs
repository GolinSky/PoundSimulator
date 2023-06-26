using CodeFramework.Runtime.Observer;
using CodeFramework.Runtime.View.Component;
using PoundSimulator.Components;
using UnityEngine;

namespace PoundSimulator.View.Components
{
    public class MoveViewComponent:ViewComponent, ICustomObserver<float>
    {
        private const float MaxLerpClamped = 1;
        private IMoveComponentObserver moveComponentObserver;
        private ObserverSubject<float> tickService;
        private Transform cachedTransform;
        private Vector2 targetPosition;
        private Vector2 startPosition;
        private float lerpTime;
        private float lerpSpeed;
        private bool useLerp;

        protected override void OnInit()
        {
            base.OnInit();
            cachedTransform = transform;
            moveComponentObserver = ViewController.GetComponentObserver<IMoveComponentObserver>();
            ChangePosition(moveComponentObserver.CurrentPosition);
            moveComponentObserver.OnMoveToPosition += MoveToPosition;
            moveComponentObserver.OnPositionChanged += ChangePosition;
            tickService = ViewController.TickService;
            tickService.AddObserver(this);
        }

        protected override void OnRelease()
        {
            base.OnRelease();
            if(moveComponentObserver!= null)
            {
                moveComponentObserver.OnMoveToPosition -= MoveToPosition;
                moveComponentObserver.OnPositionChanged -= ChangePosition;
            }

            if (tickService != null)
            {
                tickService.RemoveObserver(this);
            }
        }

        private void ChangePosition(Vector2 position)
        {
            cachedTransform.position = position;
        }

        private void MoveToPosition(Vector2 position, float lerpSpeed)
        {
            targetPosition = position;
            startPosition = cachedTransform.position;
            this.lerpSpeed = lerpSpeed;
            lerpTime = 0;
            useLerp = true;
        }

        public void UpdateState(float deltaTime)
        {
            if (useLerp)
            {
                if (lerpTime < MaxLerpClamped)
                {
                    lerpTime += deltaTime * lerpSpeed;
                    ChangePosition(Vector2.Lerp(startPosition, targetPosition, lerpTime));
                }
                else
                {
                    useLerp = false;
                    ChangePosition(targetPosition);
                }
            }
        }
    }
}