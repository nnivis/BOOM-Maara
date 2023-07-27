using UnityEngine;

namespace BOOM
{
    public class ScoreController : MonoBehaviour, IEnemyDeathObserver
    {

        int _currentScore;
        int _maxScore;
        [SerializeField] ScoreUIComponent _scoreUIComponent;
        void Start()
        {
            GameManager.Instance.RegisterEnemyDeathListener(this);

            _currentScore = 0;
            UpdateScoreUI();
        }

        public void OnEnemyDeath()
        {
            _currentScore++;

            UpdateScoreUI();
            UpdateMaxScoreUI();
        }

        public void UpdateScoreUI()
        {
            if (_scoreUIComponent != null)
            {
                _scoreUIComponent.UpdateScore(_currentScore,_maxScore);
                
            }
        }

        void UpdateMaxScoreUI()
        {
            if (_maxScore < _currentScore)
            {
                _maxScore = _currentScore;
            }
        }

        public void ResetCurrentPoints()
        {
            _currentScore = 0;
            UpdateScoreUI();
        }
    }
}

