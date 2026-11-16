using UnityEngine;

namespace MazeBall
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        private readonly string finishTag = "Finish", outbound = "OutBound";
        private Rigidbody rb;

        void OnEnable()  => gameManager.OnGameEnds += StopBall;
        void OnDisable() => gameManager.OnGameEnds -= StopBall;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (gameManager.IsGameEnded)
                return;

            if (other.CompareTag(finishTag))
                gameManager.OnWinGame?.Invoke();
            else if (other.CompareTag(outbound))
                gameManager.OnRestart?.Invoke();
        }

        private void StopBall()
        {
            rb.useGravity = false;
            rb.Sleep();
        }

    }
}