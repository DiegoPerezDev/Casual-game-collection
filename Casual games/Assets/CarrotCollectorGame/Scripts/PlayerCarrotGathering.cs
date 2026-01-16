using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CarrotCollector
{
    public class PlayerCarrotGathering : MonoBehaviour
    {
        public Action OnCarrotGather;
        [HideInInspector] public bool disabled;
        [SerializeField] private GameObject carrot;
        [SerializeField] private TextMeshProUGUI CarrotsHUD_TMP;
        [SerializeField] private Match match;
        private string carrotTag;
        private int carrotCount, maxCarrots;


        void Start()
        {
            if (carrot == null)
                Debug.LogWarning("No carrot assigned. No carrot gathering will happen.");
            else
                carrotTag = carrot.tag;

            maxCarrots = match?  match.carrotsMaxAmount : 10;
            CarrotsHUD_TMP.text = $"Carrots: {carrotCount:00}/{maxCarrots:00}";
            disabled = false;
        }

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            if (disabled)
                return;

            if (!otherCollider.CompareTag(carrotTag))
                return;

            otherCollider.gameObject.SetActive(false);
            AddCarrotOnHud();
            OnCarrotGather?.Invoke();
        }

        private void AddCarrotOnHud()
        {
            carrotCount++;
            CarrotsHUD_TMP.text = $"Carrots: {carrotCount:00}/{maxCarrots:00}";
        }

    }
}