using System;
using UnityEngine;

namespace BlockDodger
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Block : MonoBehaviour
    {
        private GameManager gameManager;
        private BlockSpawner blockSpawner;
        private Rigidbody2D rb;
        private const float fallVel = -5.2f; 
        private const float outOfViewHeight = -5.8f;
        private const float speedInc = 0.4f;


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            StartFalling();
        }

        void FixedUpdate()
        {
            if (rb.position.y < outOfViewHeight)
            {
                RespawnBlock();
                gameManager.OnScoreUp?.Invoke();
            }
        }

        public void Initialize(BlockSpawner spawner)
        {
            blockSpawner = spawner;
            gameManager  = spawner.gameManager;
        }
        public void IncreaseSpeed() => rb.linearVelocityY -= speedInc;

        private void RespawnBlock() => transform.position = blockSpawner.GetSpawnPosition();

        private void StartFalling() => rb.linearVelocity = new Vector2(0f, fallVel);
    }
}
