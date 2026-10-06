
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MazeBall
{
    public class UI : MonoBehaviour
    {
        
        [SerializeField] private GameObject winText, loseText, pauseMenu;
        [SerializeField] private TextMeshProUGUI timeText;
        private const string timeConstText = "TIME LEFT: ";
        private const int maxTime = 60;
        private int timeLeft, secondsPassed;
        private float timePassed;
        private bool timerEnded;

        private void OnEnable()
        {
            GameManager.OnWinGame += GameWon;
        }
        private void OnDisable()
        {
            GameManager.OnWinGame -= GameWon;
        }

        private void Start()
        {
            timePassed = 0;
            UpdateTimer(maxTime);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Button_Pause();


            if (timerEnded)
                return;

            timePassed += Time.deltaTime;
            if(timePassed >= secondsPassed + 1)
            {
                secondsPassed++;
                UpdateTimer(secondsPassed);
                if (timePassed >= maxTime)
                    GameLost();
            }
        }

        private void UpdateTimer(int time)
        {
            timeLeft = maxTime - secondsPassed;
            timeText.text = $"{timeConstText}{timeLeft}";
        }

        private void GameWon()
        {
            winText.SetActive(true);
            timerEnded = true;
        }

        private void GameLost()
        {
            loseText.SetActive(true);
            timerEnded = true;
            GameManager.OnGameEnds?.Invoke();
        }

        public void Button_Reset()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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