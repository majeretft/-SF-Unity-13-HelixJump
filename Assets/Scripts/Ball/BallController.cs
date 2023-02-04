using UnityEngine;

[RequireComponent(typeof(BallMovement))]
public class BallController : BallEventHandler
{
    private BallMovement _ballMovement;

    private void Awake()
    {
        _ballMovement = GetComponent<BallMovement>();
    }

    protected override void EventHandler(SegmentTypeEnum segmentType, Transform colliderTransform)
    {
        switch (segmentType)
        {
            case SegmentTypeEnum.Trap:
                _ballMovement.JumpStop();
                break;
            case SegmentTypeEnum.Empty:
                _ballMovement.Fall(colliderTransform.position.y);
                break;
            case SegmentTypeEnum.Finish:
                _ballMovement.JumpStop();
                break;
            case SegmentTypeEnum.Default:
                _ballMovement.JumpStart();
                break;
        }
    }
}
