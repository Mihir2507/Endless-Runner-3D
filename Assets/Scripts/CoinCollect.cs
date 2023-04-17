using UnityEngine;

public class CoinCollect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //check if the object we collided with is player or not
        if(other.gameObject.name != "Player")
        {
            return;
        }
        Destroy(gameObject);
        // Add to the player score
        GameManager.inst.IncrementScore();
        //destroy the coin
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
