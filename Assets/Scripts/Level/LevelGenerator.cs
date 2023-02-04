using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int _defaultFloorCount;
    [SerializeField] private Axis _axis;
    [SerializeField] private Ball _ball;
    [SerializeField] private Floor _floorPrefab;
    [SerializeField] private float _floorHeight;
    [SerializeField] private int _floorEmptyMin;
    [SerializeField] private int _floorEmptyMax;
    [SerializeField] private int _floorTrapMin;
    [SerializeField] private int _floorTrapMax;

    private float _floorCount;
    public float FloorCount => _floorCount;

    public void Generate(int levelNumber)
    {
        _floorCount = levelNumber + _defaultFloorCount;

        var height = (_floorCount - 1) * _floorHeight;
        _axis.SetHeight(height);
        _ball.SetVerticalPosition(height);

        for (var i = 0; i < _floorCount; i++)
        {
            var emptyCount = Random.Range(_floorEmptyMin, _floorEmptyMax + 1);
            var trapCount = Random.Range(_floorTrapMin, _floorTrapMax + 1);

            var tempFloor = Instantiate<Floor>(_floorPrefab, transform);

            if (i == 0)
                tempFloor.MakeFinishSegments();

            if (i != 0 && i != _floorCount - 1)
            {
                tempFloor.RandomizeSegments(emptyCount, trapCount);
                tempFloor.transform.eulerAngles = new Vector3(0, Utilities.RangeWithStep(0, 360, 30), 0);
            }

            tempFloor.transform.position = new Vector3(0, i * _floorHeight, 0);
            tempFloor.name = $"Floor_{i}";
        }
    }
}
