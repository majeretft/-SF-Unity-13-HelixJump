using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : BallEventHandler
{
    [SerializeField] private Progress _progress;
    [SerializeField] private Text _scoreText;

    protected override void EventHandler(SegmentTypeEnum segmentType, Transform colliderTransform)
    {
        if (segmentType == SegmentTypeEnum.Finish || segmentType == SegmentTypeEnum.Default)
            _scoreText.text = _progress.Score.ToString();
    }
}
