using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BalloonPopper
{
    public class UI_Buttons : MonoBehaviour
    {
        [SerializeField] private Pause pause;
        [SerializeField] private Match match;
        
        public void ButtonStartGame() => match.OnStart?.Invoke();

        public void ButtonHUDPause() => pause.OnPause?.Invoke();

        public void ButtonResumeGame() => pause.OnUnpause?.Invoke();

        public void ButtonRestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public void ButtonGameSelection() => SceneManager.LoadScene(0);

    }
}