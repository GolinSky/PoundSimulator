using System;
using CodeFramework.Runtime;
using UnityEngine;

namespace PoundSimulator.Components
{
    public interface IMoveComponentObserver : IComponentObserver
    {
        event Action<Vector2> OnPositionChanged;
    }

    public class MoveComponent:Component<IController>, IMoveComponentObserver
    {
        private const float LerpSpeed = 0.1f;
        public event Action<Vector2> OnPositionChanged;

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
            OnPositionChanged?.Invoke(position);//todo: do lerp via update
        }

    }
}