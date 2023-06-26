using System;
using CodeFramework.Runtime;
using PoundSimulator.View.Components;
using UnityEngine;

namespace PoundSimulator.Components
{
    public interface IMoveComponentObserver : IComponentObserver
    {
        event Action<Vector2> OnPositionChanged;
        event Action<Vector2, float> OnMoveToPosition;
        event Action<Interactive> OnFollow; 
        event Action OnStop;
        Vector2 CurrentPosition { get; }
    }

    public class MoveComponent:Component<IController>, IMoveComponentObserver
    {
        private const float LerpSpeed = 1f;
      
        public event Action<Vector2> OnPositionChanged;
        public event Action<Vector2, float> OnMoveToPosition;
        public event Action<Interactive> OnFollow;
        public event Action OnStop;
        
        public Vector2 CurrentPosition { get; private set; }

        public override void Init(IController entity)
        {
            
        }

        public override void Release()
        {
            
        }

        public void Move(Vector2 position)
        {
            CurrentPosition = position;
            OnPositionChanged?.Invoke(position);
        }

        public void MoveTo(Vector2 position, float lerp = LerpSpeed)
        {
            OnMoveToPosition?.Invoke(position, lerp);//todo: do lerp via update
        }

        public void Follow(Interactive interactive)
        {
            OnFollow?.Invoke(interactive);
        }

        public void Stop()
        {
            OnStop?.Invoke();
        }
    }
}