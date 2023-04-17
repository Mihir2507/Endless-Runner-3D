using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    public bool spawnTileItems;

    public void SpawnTile()
    {
        GameObject temp =  Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if(spawnTileItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoin();
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        for(int i = 0; i < 12; i++)
        {
            if(i<3)
            {
                spawnTileItems = false;
                SpawnTile();
            }
            else
            {
                spawnTileItems = true;
                SpawnTile();
            }
        }
    }
}
