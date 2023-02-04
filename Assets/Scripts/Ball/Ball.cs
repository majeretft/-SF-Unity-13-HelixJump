using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public UnityEvent<SegmentTypeEnum, Transform> BallEvent;

    private Collider _collider;

    public void SetVerticalPosition(float y)
    {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_collider != null && _collider != other)
            return;

        var segment = other.GetComponent<Segment>();

        if (segment == null)
            return;

        BallEvent.Invoke(segment.Type, other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (_collider == other)
            _collider = null;
    }
}
