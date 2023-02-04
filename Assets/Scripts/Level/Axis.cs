using UnityEngine;

public class Axis : MonoBehaviour
{
    private float _height;

    private void Awake() {
        _height = GetComponentInChildren<MeshRenderer>().bounds.size.y;
    }

    public void SetHeight(float requiredHeight)
    {
        var factor = requiredHeight / _height;

        transform.localScale = new Vector3(transform.localScale.x, factor, transform.localScale.z);
    }
}
