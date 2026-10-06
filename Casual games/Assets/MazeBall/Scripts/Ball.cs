using UnityEngine;

namespace MazeBall
{
    public class Ball : MonoBehaviour
    {
        private bool gameWon;
        private readonly string finishTag = "Finish", outbound = "OutBound";

        private void OnTriggerEnter(Collider other)
        {
            if (gameWon)
                return;

            if (other.CompareTag(finishTag))
            {
                gameWon = true;
                GameManager.OnWinGame?.Invoke();
            }
            else if (other.CompareTag(outbound))
            {
                GameManager.OnGameEnds?.Invoke();
            }
        }

    }
}