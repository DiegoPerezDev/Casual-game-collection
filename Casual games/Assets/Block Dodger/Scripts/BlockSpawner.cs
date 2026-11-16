using UnityEngine;
using System.Collections.Generic;

namespace BlockDodger
{
    public class BlockSpawner : MonoBehaviour
    {
        public List<Block> Blocks { get; private set; }
        public GameManager gameManager;
        [SerializeField] private Block blockPrefab;
        [SerializeField] private int spawnPoints = 5;

        private const float initialHeight = 5.8f;
        private const float horizontalRange = 3.7f;
        private Vector2[] spawnPointsPos;


        void OnEnable()
        {
            gameManager.OnGameStart += StartSpawning;
        }
        void OnDisable()
        {
            gameManager.OnGameStart -= StartSpawning;
        }

        void Start()
        {
            SetSpawnPositions();
        }


        public Vector3 GetSpawnPosition()
        {
            return spawnPointsPos[UnityEngine.Random.Range(0, spawnPointsPos.Length)];
        }

        public void IncreaseBlocksSpeed()
        {
            foreach (var block in Blocks)
                block.IncreaseSpeed();
        }


        private void SetSpawnPositions()
        {
            spawnPointsPos = new Vector2[spawnPoints];
            for (int i = 0; i < spawnPoints; i++)
            {
                // Each spawn point equally separated in all the range given
                var spawnPosX = -(horizontalRange / 2) + (horizontalRange / (spawnPoints - 1)) * i;
                spawnPointsPos[i] = new Vector3(spawnPosX, initialHeight);
            }
        }

        private void StartSpawning()
        {
            Blocks = new List<Block>();
            Invoke(nameof(SpawnNewBlock), 1.0f);
            Invoke(nameof(SpawnNewBlock), 2.1f);
        }

        private void SpawnNewBlock()
        {
            var initialPos = GetSpawnPosition();
            var block = Instantiate(blockPrefab, initialPos, Quaternion.identity);
            block.Initialize(this);
            Blocks.Add(block);
        }
    }
}