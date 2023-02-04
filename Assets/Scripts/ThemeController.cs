using UnityEngine;

public class ThemeController : MonoBehaviour
{
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _trapMaterial;
    [SerializeField] private Material _axisMaterial;
    [SerializeField] private Material _ballMaterial;
    [SerializeField] private GameObject _spritePrefab;

    private SpriteRenderer _bloatRenderer;

    private void Awake() {
        _bloatRenderer = _spritePrefab.GetComponentInChildren<SpriteRenderer>();
    }

    public void SetColorScheme(Color axis, Color trapSeg, Color defaultSeg, Color ball)
    {
        _defaultMaterial.color = defaultSeg;
        _trapMaterial.color = trapSeg;
        _axisMaterial.color = axis;
        _ballMaterial.color = ball;
        _bloatRenderer.color = ball;
    }
}
