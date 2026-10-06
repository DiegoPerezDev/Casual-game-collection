using UnityEngine;
using System;

namespace MazeBall
{
    public class GameManager : MonoBehaviour
    {
        public static Action OnWinGame;
        public static Action OnGameEnds;

        void OnEnable() =>  OnWinGame += EndGame;
        void OnDisable() => OnWinGame -= EndGame;

        private void EndGame() => OnGameEnds?.Invoke();
    }
}