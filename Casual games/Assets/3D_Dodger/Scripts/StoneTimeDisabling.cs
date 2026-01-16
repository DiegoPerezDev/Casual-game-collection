using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeD_Dodger
{
    public class StoneTimeDisabling : MonoBehaviour
    {
        float timer = 0f;
        const float disablingTime = 5f;
        
        void Update()
        {
            timer += Time.deltaTime;
            if (timer > disablingTime)
            {
                timer = 0;
                DisableStone();
            }
        }
        void DisableStone() => gameObject.SetActive(false);
    }
}