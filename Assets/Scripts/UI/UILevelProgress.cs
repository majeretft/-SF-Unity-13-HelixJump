using UnityEngine;
using UnityEngine.UI;

public class UILevelProgress : BallEventHandler
{
    [SerializeField] private Text _currentLvl;
    [SerializeField] private Text _nextLvl;
    [SerializeField] private Progress _progress;
    [SerializeField] private Image _progressBar;
    [SerializeField] private LevelGenerator _levelGenerator;

    private float _fillAmountStep;

    protected override void EventHandler(SegmentTypeEnum segmentType, Transform colliderTransform)
    {
        if (segmentType == SegmentTypeEnum.Empty || segmentType == SegmentTypeEnum.Finish)
            _progressBar.fillAmount += _fillAmountStep;

        _fillAmountStep = 1 / _levelGenerator.FloorCount;

        _currentLvl.text = _progress.CurrentLevel.ToString();
        _nextLvl.text = (_progress.CurrentLevel + 1).ToString();
    }

    protected override void Start()
    {
        base.Start();

        _progressBar.fillAmount = 0;
    }
}
