using UnityEngine;

public enum SegmentTypeEnum
{
    Default,
    Trap,
    Empty,
    Finish,
}

[RequireComponent( typeof(MeshRenderer) )]
public class Segment : MonoBehaviour
{
    [SerializeField] private SegmentTypeEnum _type;
    public SegmentTypeEnum Type => _type;

    private MeshRenderer _meshRenderer;

    public void SetSegmentType(SegmentTypeEnum type, Material material)
    {
        _type = type;
        _meshRenderer.material = material;
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
}
