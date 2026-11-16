using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeD_Dodger
{
    /// <summary>
    /// It spawns them in order. It does not check if they are active or not. It does not add more stones to the pool.
    /// </summary>
    public class StoneSpawner : MonoBehaviour
    {
        [SerializeField] private UpTimer timer;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject stonesParent;
        private List<Transform> stonesPool = new();
        private Vector2 spawnRandomRange = new(3.5f, 2.0f);
        private int stoneToSpawnIndex;
        private int TotalRocksInPool;
        private float spawningDelay = 1.45f;
        private bool spawning;


        private void OnEnable() => timer.OnSecond += CheckForSpeedIncrease;
        private void OnDisable() => timer.OnSecond -= CheckForSpeedIncrease;

        void Start()
        {
            SetStonesPool();
            TotalRocksInPool = stonesPool.Count;
            
        }

        private void SetStonesPool()
        {
            foreach (Transform stone in stonesParent.transform)
            {
                stonesPool.Add(stone);
                stone.gameObject.SetActive(false);
            }
        }


        // -- -- Stones spawning -- --

        public void StartSpawning()
        {
            if (spawning)
                return;
            spawning = true;

            stoneToSpawnIndex = TotalRocksInPool; //so in "SelectStoneIndexToSpawn()" it can get back to 0.
            StartCoroutine(Cor_SpawnStone());
        }

        private IEnumerator Cor_SpawnStone()
        {
            float timer = 0;
            while (timer < spawningDelay)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            SpawnStone(SelectStoneIndexToSpawn());

            yield return null;
            StartCoroutine(Cor_SpawnStone());
        }

        private int SelectStoneIndexToSpawn()
        {
            if (stoneToSpawnIndex >= TotalRocksInPool - 1)
                stoneToSpawnIndex = 0;
            else
                stoneToSpawnIndex++;

            return stoneToSpawnIndex;
        }

        void SpawnStone(int stoneIndexToSpawn)
        {
            var stoneToSpawn = stonesPool[stoneIndexToSpawn];

            Vector2 spawnRandomVariation = new(Random.Range(-spawnRandomRange.x, spawnRandomRange.x),
                                            Random.Range(-spawnRandomRange.y, spawnRandomRange.y));

            Vector3 spawnPos = new(spawnPoint.position.x + spawnRandomVariation.x,
                                    spawnPoint.position.y + spawnRandomVariation.y,
                                    spawnPoint.position.z);

            stoneToSpawn.position = spawnPos;
            stoneToSpawn.gameObject.SetActive(true);
        }


        // --- --- --- Speed Increace --- --- --- 
        private void CheckForSpeedIncrease()
        {
            if (timer.Counter != 0 && (int)timer.Counter % 5 == 0)
            {
                SpeedUpSpawning();
            }
        }

        private void SpeedUpSpawning() => spawningDelay *= 0.95f;
    }
}