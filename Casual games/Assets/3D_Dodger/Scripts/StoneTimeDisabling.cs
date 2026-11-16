using UnityEngine;

namespace ThreeD_Dodger
{
    [RequireComponent (typeof(Rigidbody))]
    public class StoneTimeDisabling : MonoBehaviour
    {
        private Rigidbody rb;
        float timer = 0f;
        const float disablingTime = 5f;

        void OnDisable() => timer = 0;

        void Start() => rb = GetComponent<Rigidbody>();

        void Update()
        {
            timer += Time.deltaTime;
            if (timer > disablingTime)
                DisableStone();
        }
        void DisableStone()
        {
            rb.linearVelocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}