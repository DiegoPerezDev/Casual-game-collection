using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace BlockDodger
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject tapText, titleText, pauseMenu, pauseButton;
        int score = 0;

        void OnEnable()
        {
            Block.OnBlockDestroyed += IncrementScore;
            GameManager.OnGameStart += StartUI;
        }
        void OnDisable()
        {
            Block.OnBlockDestroyed -= IncrementScore;
            GameManager.OnGameStart -= StartUI;
            Time.timeScale = 1;
        }

        void Awake()
        {
            scoreText.gameObject.SetActive(false);
            pauseMenu.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Button_Pause();
            }
        }

        void StartUI()
        {
            tapText.SetActive(false);
            titleText.SetActive(false);
            scoreText.gameObject.SetActive(true);
            pauseButton.SetActive(true);
        }

        void IncrementScore()
        {
            scoreText.text = $"{++score}";
        }

        public void Button_Pause()
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        public void Button_ResumePause()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        public void Button_GameSelection()
        {
            SceneManager.LoadScene(0);
        }
    }
}