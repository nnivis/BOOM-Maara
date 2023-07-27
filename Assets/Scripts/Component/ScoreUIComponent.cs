using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BOOM
{
    public class ScoreUIComponent : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _scoreCurrentText;
        [SerializeField] TextMeshProUGUI _scoreMaxText;

        int _scoreCurrent;
        int _scoreMax;

        void Start()
        {
            _scoreCurrent = 0;
            UpdateScoreUI();
        }
        public void UpdateScore(int newScore, int maxScore)
        {
            _scoreCurrent = newScore;
            _scoreMax = maxScore;

            UpdateScoreUI();
        }

        void UpdateScoreUI()
        {
            _scoreCurrentText.text = _scoreCurrent.ToString();
            _scoreMaxText.text = _scoreMax.ToString();
        }

    }
}
