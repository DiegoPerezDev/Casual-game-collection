using System;
using UnityEngine;

namespace BlockDodger
{
    public class Block : MonoBehaviour
    {
        public static Action OnBlockDestroyed;
        private BlockSpawner blockSpawner;
        private Rigidbody2D rb;
        private float fallVel = -7f; 
        private const float outOfViewHeight = -5.8f;

        public void Initialize(BlockSpawner spawner)
        {
            blockSpawner = spawner;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(0f, fallVel);
        }

        void Update()
        {
            if (transform.position.y < outOfViewHeight)
            {
                RestartBlock();
                OnBlockDestroyed?.Invoke();
            }
        }

        private void RestartBlock()
        {
            transform.position = blockSpawner.GetSpawnPosition();
        }
    }
}
