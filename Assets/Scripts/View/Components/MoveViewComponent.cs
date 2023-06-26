using CodeFramework.Runtime.Observer;
using CodeFramework.Runtime.View.Component;
using PoundSimulator.Components;
using UnityEngine;

namespace PoundSimulator.View.Components
{
    public class MoveViewComponent:ViewComponent, ICustomObserver<float>
    {
        private const float OffsetX = 1f;
        private const float OffsetY = 1f;
        private const float MinTargetLerpTime = 0.8f;
        private const float MaxTargetLerpTime = 0.95f;
        private const float MaxLerpClamped = 1;

        private IMoveComponentObserver moveComponentObserver;
        private Interactive interactive;
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
                moveComponentObserver.OnFollow -= FollowTarget;
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
            FollowTargetInternal();
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
                    ChangePosition(targetPosition);
                    if (interactive != null)
                    {
                        FollowTargetInternal();
                        return;
                    }
                    useLerp = false;
                }
            }
        }

        private void FollowTargetInternal()
        {
            var nearPosition = Vector2.Lerp(cachedTransform.position, interactive.Position, Random.Range(MinTargetLerpTime, MaxTargetLerpTime));
            nearPosition.x += Random.Range(-OffsetX, OffsetX);
            nearPosition.y += Random.Range(-OffsetY, OffsetY);
            MoveToPosition(nearPosition, MaxLerpClamped);
        }
    }
}