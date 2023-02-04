using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _trapMaterial;
    [SerializeField] private Material _emptyMaterial;
    [SerializeField] private Material _finishMaterial;

    [SerializeField] private List<Segment> _segments;

    public void MakeFinishSegments()
    {
        foreach (var s in _segments)
        {
            s.SetSegmentType(SegmentTypeEnum.Finish, _finishMaterial);
        }
    }

    public void RandomizeSegments(int emptyCount, int trapCount)
    {
        var trapAddChance = 20;
        var emptyAddChance = 20;

        foreach (var s in _segments)
        {
            if (emptyCount > 0 && (Random.Range(0, 100) + emptyAddChance) > 50)
            {
                s.SetSegmentType(SegmentTypeEnum.Empty, _emptyMaterial);
                emptyAddChance -= 20;
                emptyCount--;
                continue;
            }
            else
            {
                emptyAddChance += 20;
            }

            if (trapCount > 0 && (Random.Range(0, 100) + trapAddChance) > 50)
            {
                s.SetSegmentType(SegmentTypeEnum.Trap, _trapMaterial);
                trapAddChance -= 20;
                trapCount--;
                continue;
            }
            else
            {
                trapAddChance += 20;
            }

            s.SetSegmentType(SegmentTypeEnum.Default, _defaultMaterial);
        }

        if (!_segments.Any(x => x.Type == SegmentTypeEnum.Empty))
            _segments[Random.Range(0, _segments.Count)].SetSegmentType(SegmentTypeEnum.Empty, _emptyMaterial);
    }
}
