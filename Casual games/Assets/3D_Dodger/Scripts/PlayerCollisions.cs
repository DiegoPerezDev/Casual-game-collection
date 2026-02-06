using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeD_Dodger
{
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField] private Level level;
        private const string obstacleTag = "Stone";
        private const string fallTag = "Fall";

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(obstacleTag))
            {
                level.OnLoseGame?.Invoke();
            }
            else if (collision.gameObject.CompareTag(fallTag))
            {
                level.OnLoseGame?.Invoke();
            }
        }
    }
}