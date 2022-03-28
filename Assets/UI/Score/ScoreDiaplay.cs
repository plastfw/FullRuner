using System;
using TMPro;
using UnityEngine;

public class ScoreDiaplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreDisplay;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreDisplay.text = score.ToString();
    }
}
