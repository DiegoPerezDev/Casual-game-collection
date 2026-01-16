using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarrotCollector
{ 
    public class CarrotGenerator : MonoBehaviour
    {
        public int carrotsAmount;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject carrotPrefab;
        [SerializeField] private Vector2 squarePosMin, squarePosMax;
        private Vector2 spawnablePosMin, spawnablePosMax;
        private Vector2 playerPos;
        private Vector2 carrotSize;
        private const float playerCarrotColRange = 1f;


        public void SpawnCarrots()
        {
            if(carrotPrefab == null)
            {
                Debug.LogWarning("Cannot spawn carrots, because the prefab cannot be found.");
                return;
            }
            GetInvolvedObjectsData();
            SpawnCarrotsAtRandomPos(carrotsAmount);
        }

        private void GetInvolvedObjectsData()
        {
            GetCarrotSize();
            GetLevelSpawnablePos();
            GetPlayerToCarrotColRange();
        }

        private void GetCarrotSize()
        {
            var carrotSpriteRenderer = carrotPrefab.GetComponent<SpriteRenderer>();
            carrotSize = carrotSpriteRenderer.bounds.size;
        }

        private void GetLevelSpawnablePos()
        {
            spawnablePosMin = new Vector2(squarePosMin.x + (carrotSize.x / 2), squarePosMin.y + (carrotSize.y / 2));
            spawnablePosMax = new Vector2(squarePosMax.x - (carrotSize.x / 2), squarePosMax.y - (carrotSize.y / 2));
        }

        private void GetPlayerToCarrotColRange()
        {
            if (player == null)
                return;
            playerPos = player.transform.position;
        }

        private void SpawnCarrotsAtRandomPos(int carrotsAmount)
        {
            for (int carrotsSpawned = 0; carrotsSpawned < carrotsAmount; carrotsSpawned++)
            {
                //Get random pos for spawning within the level bounds
                Vector2 spawnPos = new()
                {
                    x = UnityEngine.Random.Range(spawnablePosMin.x, spawnablePosMax.x),
                    y = UnityEngine.Random.Range(spawnablePosMin.y, spawnablePosMax.y)
                };

                //Avoid spawning near the player
                while (Vector2.Distance(spawnPos, playerPos) <= playerCarrotColRange)
                {
                    spawnPos.x = UnityEngine.Random.Range(spawnablePosMin.x, spawnablePosMax.x);
                    spawnPos.y = UnityEngine.Random.Range(spawnablePosMin.y, spawnablePosMax.y);
                }

                //Spawn carrot
                Instantiate(carrotPrefab, spawnPos, Quaternion.identity, transform);
            }
        }
    }
}