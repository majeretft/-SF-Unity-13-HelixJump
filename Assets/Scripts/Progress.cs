using UnityEngine;

public class Progress : MonoBehaviour
{
    public int CurrentLevel { get; protected set; }
    [field: SerializeField] public int StartLevel { get; set; }

    private int _score;
    public int Score
    {
        get
        {
            return _score;
        }
        protected set
        {
            if (_score <= 0 && value < 0)
                return;

            _score = value;

            if (Score > ScoreMax)
                ScoreMax = Score;
        }
    }
    public int ScoreMax { get; protected set; }

    private const string LEVEL = "Progress:CurrentLevel";
    private const string SCORE = "Progress:Score";
    private const string SCORE_MAX = "Progress:ScoreMax";

    [SerializeField] private int _scoreSegmentEmpty;
    [SerializeField] private int _scoreSegmentDefault;

    public void Save()
    {
        PlayerPrefs.SetInt(LEVEL, CurrentLevel);
        PlayerPrefs.SetInt(SCORE, Score);
        PlayerPrefs.SetInt(SCORE_MAX, ScoreMax);
    }

    public void Load()
    {
        CurrentLevel = PlayerPrefs.GetInt(LEVEL, StartLevel);
        Score = PlayerPrefs.GetInt(SCORE, 0);
        ScoreMax = PlayerPrefs.GetInt(SCORE_MAX, 0);
    }

    public void AddFloorScore()
    {
        Score += _scoreSegmentEmpty;
    }
    public void AddSegmentScore()
    {
        Score += _scoreSegmentDefault;
    }

    public void AddLevel()
    {
        CurrentLevel++;
    }
}
