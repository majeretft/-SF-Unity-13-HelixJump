using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _fallHeight;
    [SerializeField] private Animator _animator;

    private float _fallTargetY;
    private float _fallSpeedCurrent;
    [SerializeField] private float _fallSpeedDefault;
    [SerializeField] private float _fallSpeedMax;
    [SerializeField] private float _fallSpeedIncrement;

    public void Fall(float initialPos)
    {
        _animator.speed = 0;
        _fallTargetY = initialPos - _fallHeight;
        enabled = true;
    }

    public void JumpStart()
    {
        _animator.speed = 1;
        enabled = false;
    }

    public void JumpStop()
    {
        _animator.speed = 0;
    }

    private void Awake()
    {
        enabled = false;
    }

    private void Update()
    {
        if (_fallSpeedCurrent < _fallSpeedMax)
            _fallSpeedCurrent += _fallSpeedIncrement;

        transform.Translate(new Vector3(transform.position.x, _fallSpeedCurrent * Time.deltaTime * -1, transform.position.z));

        if (transform.position.y <= _fallTargetY)
        {
            transform.position = new Vector3(transform.position.x, _fallTargetY, transform.position.z);
            enabled = false;
        }
    }
}
