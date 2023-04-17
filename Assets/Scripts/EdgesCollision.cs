using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgesCollision : MonoBehaviour
{

    PlayerMovements playerMovement;
    private void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            playerMovement.Die();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovements>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
