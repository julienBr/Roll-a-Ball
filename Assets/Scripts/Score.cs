using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int _scoreValue;
    public Text scoreText;
    public GameObject winMessage;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.UpdateScore.AddListener(UpdateScoreValue);
    }

    private void OnDisable()
    {
        _player.UpdateScore.RemoveListener(UpdateScoreValue);
    }

    private void Start()
    {
        UpdateScoreValue(0);
    }

    private void UpdateScoreValue(int score)
    {
        _scoreValue += score;
        scoreText.text = "Score : " + _scoreValue;
        if (_scoreValue >= 50)
        {
            winMessage.SetActive(true);
        }
    }

    
}
