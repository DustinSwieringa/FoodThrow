using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private TMP_Text _timerText;

    [SerializeField]
    private float _defaultGameTime = 30;

    private float _timer;
    private bool _isInProgress;
    private int _currentScore;

    private int CurrentScore
    {
        get => _currentScore;
        set
        {
            _currentScore = value;
            _scoreText.text = _currentScore.ToString();
        }
    }

    public void StartGame()
    {
        _isInProgress = true;
        _timer = _defaultGameTime;
        CurrentScore = 0;
    }

    public void AddScore()
    {
        if (_isInProgress)
            CurrentScore++;
    }

    private void Update()
    {
        if (!_isInProgress)
            return;

        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _isInProgress = false;
            _timerText.text = "00.00";
        }
        else
        {
            _timerText.text = _timer.ToString("00.00");
        }
    }
}
