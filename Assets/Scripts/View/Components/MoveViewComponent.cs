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
        private Interactive interactive;

        protected override void OnInit()
        {
            base.OnInit();
            cachedTransform = transform;
            moveComponentObserver = ViewController.GetComponentObserver<IMoveComponentObserver>();
            ChangePosition(moveComponentObserver.CurrentPosition);
            moveComponentObserver.OnMoveToPosition += MoveToPosition;
            moveComponentObserver.OnPositionChanged += ChangePosition;
            moveComponentObserver.OnFollow += FollowTarget;
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
        private void FollowTarget(Interactive interactive)
        {
            this.interactive = interactive;
            var nearPosition = Vector2.Lerp(cachedTransform.position, interactive.Position, Random.Range(0.7f,0.95f));
            nearPosition.x += Random.Range(-2f, 2f);
            MoveToPosition(nearPosition, MaxLerpClamped);
        }

        public void UpdateState(float deltaTime)
        {
            if (useLerp)
            {
                if (lerpTime < MaxLerpClamped)
                {
                    lerpTime += deltaTime * lerpSpeed;
                    if (interactive != null)
                    {
               //         ChangePosition(Vector2.Lerp(startPosition, interactive.Position, lerpTime));
                    }
             //       else
                    {
                        ChangePosition(Vector2.Lerp(startPosition, targetPosition, lerpTime));
                    }
                }
                else
                {
                    ChangePosition(targetPosition);
                    if (interactive != null)
                    {
                        var nearPosition = Vector2.Lerp(cachedTransform.position, interactive.Position, Random.Range(0.8f,0.95f));
                        nearPosition.x += Random.Range(-1f, 1f);
                        nearPosition.y += Random.Range(-1f, 1f);
                        MoveToPosition(nearPosition, MaxLerpClamped);
                        return;
                    }
                    useLerp = false;
                }
            }
        }
    }
}