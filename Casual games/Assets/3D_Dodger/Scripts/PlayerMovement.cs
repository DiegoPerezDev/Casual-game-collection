using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeD_Dodger
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private float moveSpeed;
        private Rigidbody rb;

        void Start()
        {
            CheckComponentsAndValues();
        }

        void FixedUpdate()
        {
            FixedMovePlayer();
        }

        private void CheckComponentsAndValues()
        {
            rb = GetComponent<Rigidbody>();
            if (joystick == null)
                enabled = false;
            if (moveSpeed == 0)
                Debug.LogWarning("Player movement value is set at 0, it won't move");
        }

        private void FixedMovePlayer()
        {
            var translation = new Vector3(joystick.Horizontal * moveSpeed * Time.fixedDeltaTime, joystick.Vertical * moveSpeed * Time.fixedDeltaTime, 0);
            var newPosition = rb.position + translation;
            rb.MovePosition(newPosition);
        }

    }
}