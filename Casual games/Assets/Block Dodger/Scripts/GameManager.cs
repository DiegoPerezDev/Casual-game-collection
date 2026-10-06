using System;
using UnityEngine;

namespace BlockDodger
{
    public class GameManager : MonoBehaviour
    {
        public static Action OnGameStart, OnGameEnd;
        private bool gameStarted;

        private void Update()
        {
            if (gameStarted)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                OnGameStart?.Invoke();
                gameStarted = true;
            }
        }
    }
}