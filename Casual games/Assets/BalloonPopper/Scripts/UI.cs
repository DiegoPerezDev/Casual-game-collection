using TMPro;
using UnityEngine;

namespace BalloonPopper
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Match match;
        [SerializeField] private GameObject mainMenu, Hud;
        [SerializeField] private TextMeshProUGUI scoreTMP;

        void OnEnable()
        {
            match.OnStart += StartGame;
        }
        void OnDisable()
        {
            match.OnStart -= StartGame;
        }

        public void IncreaseScore(int score) => scoreTMP.text = score.ToString();
         
        private void StartGame()
        {
            Hud.SetActive(true);
            mainMenu.SetActive(false);
        }

    }
}