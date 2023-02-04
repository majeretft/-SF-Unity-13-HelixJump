using System.Collections.Generic;
using UnityEngine;

public class GameController : BallEventHandler
{
    [SerializeField] private Progress _progress;
    [SerializeField] private LevelGenerator _levelGenerator;

    [SerializeField] private List<Color> _ballColors;
    [SerializeField] private List<Color> _axisColors;
    [SerializeField] private List<Color> _trapSegmentColors;
    [SerializeField] private List<Color> _defaultSegmentColors;
    [SerializeField] private MouseRotator _mouseRotator;

    [SerializeField] private ThemeController _themeController;

    protected override void EventHandler(SegmentTypeEnum segmentType, Transform colliderTransform)
    {
        switch (segmentType)
        {
            case SegmentTypeEnum.Trap:
                _mouseRotator.IsEnabled = false;
                break;
            case SegmentTypeEnum.Default:
                _progress.AddSegmentScore();
                break;
            case SegmentTypeEnum.Finish:
                _mouseRotator.IsEnabled = false;
                _progress.AddFloorScore();
                _progress.AddLevel();
                break;
            case SegmentTypeEnum.Empty:
                _progress.AddFloorScore();
                break;
        }

        _progress.Save();
    }

    protected override void Start()
    {
        base.Start();

        StartLevel();
    }

    private void StartLevel()
    {
        var randomColorIndex = Random.Range(0, _ballColors.Count);

        _progress.Load();
        _levelGenerator.Generate(_progress.CurrentLevel);
        _mouseRotator.IsEnabled = true;

        _themeController.SetColorScheme(
            _axisColors[randomColorIndex],
            _trapSegmentColors[randomColorIndex],
            _defaultSegmentColors[randomColorIndex],
            _ballColors[randomColorIndex]
        );
    }
}
