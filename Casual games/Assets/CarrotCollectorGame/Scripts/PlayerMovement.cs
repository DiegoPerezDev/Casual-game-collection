using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarrotCollector
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private float moveSpeed;
        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            FixedMovePlayer();
        }

        private void FixedMovePlayer()
        {
            var translation = new Vector2(joystick.Horizontal * moveSpeed * Time.fixedDeltaTime, joystick.Vertical * moveSpeed * Time.fixedDeltaTime);
            var newPosition = rb.position + translation;
            rb.MovePosition(newPosition);
        }

    }
}