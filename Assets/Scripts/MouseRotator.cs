using UnityEngine;

public class MouseRotator : MonoBehaviour
{
    [SerializeField] private string _axisName;
    [SerializeField] private float _sensifity;

    public bool IsEnabled { get; set; }

    private void Awake()
    {
        IsEnabled = true;
    }

    private void Update()
    {
        if (!IsEnabled)
            return;

        if (Input.GetMouseButton(0))
            transform.Rotate(0, Input.GetAxis(_axisName) * -_sensifity, 0);
    }
}
