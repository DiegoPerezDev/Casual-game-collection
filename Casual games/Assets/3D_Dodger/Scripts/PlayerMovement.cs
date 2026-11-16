using UnityEngine;

namespace ThreeD_Dodger
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick joystick;
        [SerializeField] private Level level;
        [SerializeField] private float moveSpeed;
        private Rigidbody rb;


        void OnEnable()  => level.OnLoseGame += DisableMovement;
        void OnDisable() => level.OnLoseGame -= DisableMovement;
        private void DisableMovement() => enabled = false;

        void Start() => rb = GetComponent<Rigidbody>();
        void FixedUpdate() => FixedMove();

        private void FixedMove()
        {
            var translation = new Vector3(joystick.Horizontal * moveSpeed * Time.fixedDeltaTime, joystick.Vertical * moveSpeed * Time.fixedDeltaTime, 0);
            var newPosition = rb.position + translation;
            rb.MovePosition(newPosition);
        }

    }
}