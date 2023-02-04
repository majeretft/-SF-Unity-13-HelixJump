using UnityEngine;

public static class Utilities
{
    public static float RangeWithStep(float start, float end, float step)
    {
        var random = Random.Range(start, end);

        var numSteps = Mathf.Floor(random / step);
        var result = numSteps * step;

        return result;
    }

    public static float RangeWithStep(int start, int end, int step)
    {
        var random = Random.Range(start, end);

        var numSteps = Mathf.Floor(random / step);
        var result = numSteps * step;

        return result;
    }
}
