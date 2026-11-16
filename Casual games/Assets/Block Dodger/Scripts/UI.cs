using UnityEngine;
using TMPro;

namespace BlockDodger
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GameObject initialPanel;
        private int score = 0;

        void OnEnable()
        {
            gameManager.OnScoreUp   += IncrementScore;
            gameManager.OnGameStart += StartUI;
        }
        void OnDisable()
        {
            gameManager.OnScoreUp   -= IncrementScore;
            gameManager.OnGameStart -= StartUI;
        }

        void Awake()
        {
            scoreText.gameObject.SetActive(false);
        }


        private void StartUI()
        {
            initialPanel.SetActive(false);
            scoreText.gameObject.SetActive(true);
        }

        private void IncrementScore() => scoreText.text = $"{++score}";
    }
}