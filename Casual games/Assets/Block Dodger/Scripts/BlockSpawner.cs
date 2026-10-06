using UnityEngine;

namespace BlockDodger
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] private Block blockPrefab;
        [SerializeField] private int spawnPoints = 5;
        private const float initialHeight = 5.8f;
        private const float horSpawnRange = 4.4f;
        private float[] spawnPointsX;


        void OnEnable()
        {
            GameManager.OnGameStart += StartSpawning;
        }
        void OnDisable()
        {
            GameManager.OnGameStart -= StartSpawning;
        }

        private void Start()
        {
            spawnPointsX = new float[spawnPoints];
            for (int i = 0; i < spawnPointsX.Length; i++)
            {
                // Each spawn point equally separated in all the range given
                spawnPointsX[i] = -(horSpawnRange / 2) + (horSpawnRange / (spawnPoints - 1)) * i;
            }
        }

        private void StartSpawning() => Invoke(nameof(StartFirstBlock), 1.0f);

        private void StartFirstBlock()
        {
            var initialPos = GetSpawnPosition();
            var block = Instantiate(blockPrefab, initialPos, Quaternion.identity);
            block.Initialize(this);
        }

        public Vector3 GetSpawnPosition()
        {
            var randomSpawnPointX = spawnPointsX[UnityEngine.Random.Range(0, spawnPointsX.Length)];
            Vector3 spawnPos = new(randomSpawnPointX, initialHeight);
            return spawnPos;
        }
    }
}