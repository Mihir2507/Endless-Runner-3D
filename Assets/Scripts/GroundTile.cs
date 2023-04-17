using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundSpawner groundSpawner;

    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject obstacle2Prefab;
    [SerializeField] float obstacle2Chance = 0.2f;

    [SerializeField] GameObject coinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle()
    {
        //choose which obstacle to spawn
        GameObject obstacleTospawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if(random < obstacle2Chance)
        {
            obstacleTospawn = obstacle2Prefab;
        }

        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //spawn the obstacle at the position 
        Instantiate(obstacleTospawn, spawnPoint.position, Quaternion.identity, transform);
       

    }

    public void SpawnCoin()
    {
        //choose a random point to spawn the coins
        int coinSpawnIndex = Random.Range(5, 8);
        Transform spawnCoinPoint = transform.GetChild(coinSpawnIndex).transform;

        //spawn the coin at the position 
        Instantiate(coinPrefab, spawnCoinPoint.position, Quaternion.identity, transform);
    }
}