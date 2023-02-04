using UnityEngine;

public class BallBlot : BallEventHandler
{
    [SerializeField] private GameObject _bloatSprite;
    [SerializeField] private GameObject _axis;

    private Transform _internalBallTransform;

    private void Awake()
    {
        _internalBallTransform = GetComponentInChildren<MeshRenderer>().transform;
    }

    protected override void EventHandler(SegmentTypeEnum segmentType, Transform colliderTransform)
    {
        if (segmentType == SegmentTypeEnum.Finish || segmentType == SegmentTypeEnum.Empty)
            return;

        var obj = Instantiate<GameObject>(_bloatSprite, colliderTransform);
        var bloatPosY = GetColliderHeight(colliderTransform) + transform.position.y + 0.01f;

        obj.transform.position = new Vector3(_internalBallTransform.position.x, bloatPosY, _internalBallTransform.position.z);
        obj.transform.eulerAngles = new Vector3(0, Utilities.RangeWithStep(0, 360, 30), 0);
    }

    protected float GetColliderHeight(Transform colliderTransform)
    {
        return colliderTransform.GetComponent<MeshRenderer>().bounds.size.y;
    }
}
