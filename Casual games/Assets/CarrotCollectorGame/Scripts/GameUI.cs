using TMPro;
using UnityEngine;

namespace CarrotCollector
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private Match match;
        [SerializeField] private Pause pause;
        [SerializeField] private DownTimer timer;

        [SerializeField] private TextMeshProUGUI carrotsTmp;
        [SerializeField] private GameObject Joystick, hud;


        void OnEnable()
        {
            match.OnStart += EnableHUD;
            pause.OnPause += Pause;
            pause.OnUnpause += Unpause;
        }
        void OnDisable()
        {
            match.OnStart -= EnableHUD;
            pause.OnPause -= Pause;
            pause.OnUnpause -= Unpause;
        }

        public void UpdateCarrotsInHud(int collected, int max) => carrotsTmp.text = $"Carrots: {collected:00}/{max:00}";

        private void EnableHUD() => hud.SetActive(true);

        private void Pause()
        {
            timer.Stop();
            Joystick.SetActive(false);
        }
        private void Unpause()
        {
            timer.Continue();
            Joystick.SetActive(true);
        }

    }
}