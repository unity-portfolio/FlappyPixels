using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameStartText;

    [SerializeField] private TextMeshProUGUI _scoreTextMesh;
    [SerializeField] private TextMeshProUGUI _highScoreTextMesh;

    [SerializeField] private BooleanVariable _isPlayerActive;
    [SerializeField] private IntegerVariable _score;
    [SerializeField] private IntegerVariable _highScore;

    private void Awake()
    {
        _score.value = 0;
        _highScore.value = PlayerPrefs.GetInt("highscore", _highScore.value);
        _highScoreTextMesh.text = _highScore.value.ToString();
        _gameStartText.SetActive(true);
    }

    private void Update()
    {
        if(_isPlayerActive.value)
        {
            _gameStartText.SetActive(false);
        }
    }

    public void AddScore()
    {
        _score.value++;
        _scoreTextMesh.text = _score.value.ToString();
        if(_score.value >= _highScore.value)
        {
            _highScore.value = _score.value;
            _highScoreTextMesh.text = _highScore.value.ToString();
            PlayerPrefs.SetInt("highscore", _highScore.value);
        }
    }

}
