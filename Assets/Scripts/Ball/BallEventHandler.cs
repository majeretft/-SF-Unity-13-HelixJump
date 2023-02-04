using UnityEngine;

public abstract class BallEventHandler : MonoBehaviour
{
    [SerializeField] protected Ball _ball;

    protected virtual void Start()
    {
        _ball.BallEvent.AddListener(EventHandler);
    }

    protected abstract void EventHandler(SegmentTypeEnum segmentType, Transform colliderTransform);
}
