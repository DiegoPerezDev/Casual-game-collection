using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BalloonPopper
{
    public class BalloonsController : MonoBehaviour
    {
        public Action OnBalloonPop, OnBalloonOut;
        [HideInInspector] public float balloonStartHeight = -4.0f;
        private List<Balloon> balloons = new();

        void Awake()
        {
            GetAllBalloons();
        }

        private void GetAllBalloons()
        {
            balloons = GetComponentsInChildren<Balloon>().ToList();
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
    }
}