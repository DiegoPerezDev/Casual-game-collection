using System;
using UnityEngine;

namespace CarrotCollector
{
    public class PlayerCarrotGathering : MonoBehaviour
    {
        public event Action OnCarrotGather;
        [SerializeField] private GameObject carrot;
        private string carrotTag;
        

        void Start()
        {
            carrotTag = carrot.tag;
        }

        void OnTriggerEnter2D(Collider2D otherCollider)
        {
            if (!otherCollider.CompareTag(carrotTag))
                return;

            otherCollider.gameObject.SetActive(false);
            OnCarrotGather?.Invoke();
        }
    }
}