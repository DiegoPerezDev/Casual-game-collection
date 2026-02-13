using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonPopper 
{ 
    public class Balloon : MonoBehaviour
    {
        [SerializeField] private BalloonsController controller;
        private float speed = 3f;
        private AudioSource audioSource;
        private float startHeight;
        private const string topCollTag = "TopColliderBalloon";
        private bool active = false;


        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            if(controller == null)
                controller = GetComponentInParent<BalloonsController>();
        }
        private void Start()
        {
            startHeight = controller.balloonStartHeight;
        }
        

        void FixedUpdate()
        {
            if (!active)
                return;
            FixedMoveUp();
        }

        private void FixedMoveUp() => transform.Translate(0, speed * Time.fixedDeltaTime, 0);


        // Activation
        public void ActivateBalloon() => active = true;
        public void StopBalloon()     => active = false;


        // Pop the single balloon on click
        private void OnMouseDown()
        {
            if (!active)
                return;
            controller.OnBalloonPop?.Invoke();
            audioSource.Play();
            ResetBalloon();
        }

        private void ResetBalloon()
        {
            float randomXpos = UnityEngine.Random.Range(-1.94f, 1.94f);
            transform.position = new Vector3(randomXpos, startHeight, 0);
        }


        // On Balloon goes up out of bounds
        void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag(topCollTag))
            {
                controller.OnBalloonOut?.Invoke();
            }
        }

    }
}