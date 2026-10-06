using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlockDodger
{
    public class PlayerCollision : MonoBehaviour
    {
        private Rigidbody2D rb;
        private const string blockTag = "Block";

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(blockTag))
            {
                GameManager.OnGameEnd?.Invoke();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

    }
}