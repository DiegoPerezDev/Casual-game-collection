using UnityEngine;

namespace BlockDodger
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private float moveSpeed = 13f;
        private Rigidbody2D rb;
        private bool canMove;
        private const string blockTag = "Block";


        void OnEnable()
        {
            gameManager.OnGameStart += EnableMovement;
            gameManager.OnGameEnd   += DisableMovement;
        }
        void OnDisable()
        {
            gameManager.OnGameStart -= EnableMovement;
            gameManager.OnGameEnd   -= DisableMovement;
        }

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate() // Just for the movement
        {
            if (!canMove)
                return;

            if (Input.GetMouseButton(0))
                FixedMovePlayer();
            else if (Input.GetMouseButtonUp(0))
                StopPlayer();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(blockTag))
                gameManager.OnGameEnd?.Invoke();
        }


        private void FixedMovePlayer()
        {
            Vector3 worldTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 newPos;

            if (worldTouchPos.x < 0)
                newPos = new(rb.position.x - (Time.fixedDeltaTime * 3f * moveSpeed), rb.position.y);
            else
                newPos = new(rb.position.x + (Time.fixedDeltaTime * 3f * moveSpeed), rb.position.y);
            rb.MovePosition(newPos);
        }
        private void StopPlayer() => rb.linearVelocity = Vector2.zero;
        private void EnableMovement()  => canMove = true;
        private void DisableMovement() => canMove = false;
    }
}