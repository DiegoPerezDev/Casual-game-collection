using UnityEngine;

namespace BlockDodger 
{ 
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 12f;
        private Rigidbody2D rb;
        private bool canMove = true;

        private void OnEnable() =>  GameManager.OnGameEnd += DisableMovement;
        private void OnDisable() => GameManager.OnGameEnd -= DisableMovement;
        private void DisableMovement() => canMove = false;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>(); 
        }

        // Update is called once per frame
        void Update()
        {
            if (!canMove)
                return;

            if(Input.GetMouseButton(0))
            {
                Vector3 worldTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 newPos; 

                if (worldTouchPos.x < 0)
                    newPos = new(rb.position.x - (Time.timeScale * 0.01f * moveSpeed), rb.position.y);
                else
                    newPos = new(rb.position.x + (Time.timeScale * 0.01f * moveSpeed), rb.position.y);
                rb.MovePosition(newPos);
            }
            if(Input.GetMouseButtonUp(0))
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
}