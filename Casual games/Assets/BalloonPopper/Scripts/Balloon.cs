using UnityEngine;

namespace BalloonPopper 
{ 
    public class Balloon : MonoBehaviour
    {
        [SerializeField] private BalloonsController controller;
        private float speed = 2.8f;
        private bool active;
        private const float speedIncrease = 0.4f;
        private const string topCollTag = "TopColliderBalloon";
        

        void Awake()
        {
            controller = Match.Instance.balloonsController;
        }

        void Update()
        {
            if (!active)
                return;

            MoveUp();
            if (IsClicked())
                PopBalloon();
        }

        // Check if the balloon goes out of bounds upwards
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(topCollTag))
                controller.OnBalloonOut?.Invoke();
        }


        public void ActivateBalloon() => active = true;
        public void StopBalloon()     => active = false;
        public void IncreaseSpeed() => speed += speedIncrease;


        private void MoveUp() => transform.Translate(0, speed * Time.deltaTime, 0);

        private bool IsClicked()
        {
            if (Input.GetMouseButtonDown(0)) // Click
            {
                // Convert screen mouse position to world space
                Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Check if the click position overlaps this specific 2D collider
                Collider2D hitCollider = Physics2D.OverlapPoint(mouseWorldPos);
                if (hitCollider != null && hitCollider.transform == transform)
                    return true;
            }
            return false;
        }

        private void PopBalloon()
        {
            controller.OnBalloonPop?.Invoke();
            ResetBalloonPos();
            controller.lowestBalloon = this;
        }

        private void ResetBalloonPos() => transform.position = controller.GetResetPos();

    }
}