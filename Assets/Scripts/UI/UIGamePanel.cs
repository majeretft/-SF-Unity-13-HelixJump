using UnityEngine;

public class UIGamePanel : BallEventHandler
{
    [SerializeField] private GameObject _passedPanel;
    [SerializeField] private GameObject _defeatPanel;

    protected override void Start()
    {
        base.Start();

        _passedPanel.SetActive(false);
        _defeatPanel.SetActive(false);
    }

    protected override void EventHandler(SegmentTypeEnum segmentType, Transform colliderTransform)
    {
        switch (segmentType)
        {
            case SegmentTypeEnum.Trap:
                _defeatPanel.SetActive(true);
                break;
            case SegmentTypeEnum.Finish:
                _passedPanel.SetActive(true);
                break;
        }
    }
}
