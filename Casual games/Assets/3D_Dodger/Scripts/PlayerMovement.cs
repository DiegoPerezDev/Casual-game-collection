using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeD_Dodger
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Level level;
        private Rigidbody rb;


        void OnEnable()
        {
            level.OnLoseGame += DisableMovement;
        }
        void OnDisable()
        {
            level.OnLoseGame -= DisableMovement;
        }
        

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            FixedMove();
        }

        private void FixedMove()
        {
            var translation = new Vector3(joystick.Horizontal * moveSpeed * Time.fixedDeltaTime, joystick.Vertical * moveSpeed * Time.fixedDeltaTime, 0);
            var newPosition = rb.position + translation;
            rb.MovePosition(newPosition);
        }

        private void DisableMovement() => enabled = false;

    }
}