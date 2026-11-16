using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BalloonPopper
{
    public class BalloonsController : MonoBehaviour
    {
        public Action OnBalloonPop, OnBalloonOut;
        [HideInInspector] public Balloon lowestBalloon;
        private AudioSource audioSource;
        private readonly float horizontalRange = 1.8f;
        public readonly float distanceBetweenBalloons = 3f;
        private List<Balloon> balloons = new();


        void OnEnable()
        {
            OnBalloonPop += PlaySfx;
        }
        void OnDisable()
        {
            OnBalloonPop -= PlaySfx;
        }
        void Awake()
        {
            GetAllBalloons();
            audioSource = GetComponent<AudioSource>();
        }

        
        public void ActivateBalloons()
        {
            foreach (var balloon in balloons)
                balloon.ActivateBalloon();
        }

        public void StopBalloons()
        {
            foreach (var balloon in balloons)
                balloon.StopBalloon();
        }

        public void IncreaseSpeed()
        {
            foreach (var balloon in balloons)
                balloon.IncreaseSpeed();
        }

        public Vector3 GetResetPos()
        {
            float yPos = GetYSpawnPos();
            float randomXpos = UnityEngine.Random.Range(-horizontalRange, horizontalRange);
            return new Vector3(randomXpos, yPos, 0);
        }

        /// <sumary>
        /// the vertical position for the next balloon is the position of the current lowest balloon + a marging.
        private float GetYSpawnPos()
        {
            Vector2 lowestBalloonPos = lowestBalloon.transform.position;
            float margin = distanceBetweenBalloons * 0.30f;
            float randomMargin = UnityEngine.Random.Range(-margin, margin);
            return lowestBalloonPos.y - distanceBetweenBalloons + randomMargin;
        }

        private void GetAllBalloons()
        {
            balloons = GetComponentsInChildren<Balloon>().ToList();
            lowestBalloon = balloons[^1];
        }

        private void PlaySfx() => audioSource.Play();
    }
}