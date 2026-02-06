using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ThreeD_Dodger
{
    /// <summary>
    /// It spawns them in order, so it does not check if they are active or not.
    /// It does not add more stones to the pool if they are all in use at the same time.
    /// </summary>
    public class StoneSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject stoneGOContainer;
        private List<Rigidbody> stonesPool = new();
        Vector2 spawnRandomRange = new(3.5f, 2.0f);
        private int stoneSpawnedNumber;
        private int TotalRocksInPool;
        private const float spawningDelay = 1.4f;


        void Start()
        {
            SetStonesPool();
            TotalRocksInPool = stonesPool.Count;
        }

        private void SetStonesPool()
        {
            stonesPool = stoneGOContainer.GetComponentsInChildren<Rigidbody>().ToList();
            foreach (var stone in stonesPool)
                stone.gameObject.SetActive(false);
        }

        public IEnumerator Cor_SpawnStone()
        {
            float timer = 0;
            while (timer < spawningDelay)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            var stoneToSpawn = SelectStoneToSpawn();
            SpawnStone(stoneToSpawn);

            yield return null;
            StartCoroutine(Cor_SpawnStone());
        }

        // Selects the next stone available in the pool of stones.
        private Rigidbody SelectStoneToSpawn()
        {
            if (stoneSpawnedNumber >= TotalRocksInPool)
                stoneSpawnedNumber = 0;
            return stonesPool[stoneSpawnedNumber++];
        }

        void SpawnStone(Rigidbody stoneToSpawn)
        {
            Vector2 spawnRandomVariation = new(Random.Range(-spawnRandomRange.x, spawnRandomRange.x),
                                            Random.Range(-spawnRandomRange.y, spawnRandomRange.y));

            Vector3 spawnPos = new(spawnPoint.position.x + spawnRandomVariation.x,
                                    spawnPoint.position.y + spawnRandomVariation.y,
                                    spawnPoint.position.z);

            stoneToSpawn.gameObject.SetActive(true);
            stoneToSpawn.velocity = Vector3.zero;
            stoneToSpawn.position = spawnPos;
        }
    }
}