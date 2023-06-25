using System;
using CodeFramework.Runtime;
using UnityEngine;

namespace PoundSimulator.Components
{
    public interface IMoveComponentObserver : IComponentObserver
    {
        event Action<Vector2> OnPositionChanged;
        event Action<Vector2, float> OnMoveToPosition;
        event Action OnStop;
    }

    public class MoveComponent:Component<IController>, IMoveComponentObserver
    {
        private const float LerpSpeed = 1f;
        public event Action<Vector2> OnPositionChanged;
        public event Action<Vector2, float> OnMoveToPosition;
        public event Action OnStop;

        public override void Init(IController entity)
        {
            
        }

        public override void Release()
        {
            
        }

        public void Move(Vector2 position)
        {
            OnPositionChanged?.Invoke(position);
        }

        public void MoveTo(Vector2 position, float lerp = LerpSpeed)
        {
            OnMoveToPosition?.Invoke(position, lerp);//todo: do lerp via update
        }

        public void Stop()
        {
            OnStop?.Invoke();
        }
    }
}