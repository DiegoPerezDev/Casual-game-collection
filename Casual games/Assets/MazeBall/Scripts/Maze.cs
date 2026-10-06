using Unity.VisualScripting;
using UnityEngine;

namespace MazeBall
{
    public class Maze : MonoBehaviour
    {
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float maxRotation;
        private Vector2 mouseDrag, rotation;
        private bool stopped;

        private void OnEnable() => GameManager.OnGameEnds += StopMaze;
        private void OnDisable() => GameManager.OnGameEnds -= StopMaze;

        void FixedUpdate()
        {
            if (stopped)
                return;

            if (Input.GetMouseButton(0))
                RotateMaze();
        }

        private void RotateMaze()
        {
            mouseDrag = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            rotation.x -= mouseDrag.x * rotateSpeed;
            rotation.y += mouseDrag.y * rotateSpeed;

            rotation.x = Mathf.Clamp(rotation.x, -maxRotation, maxRotation);
            rotation.y = Mathf.Clamp(rotation.y, -maxRotation, maxRotation);

            transform.eulerAngles = new Vector3(rotation.y, 0, rotation.x);
        }

        private void StopMaze() => stopped = true;
    }
}