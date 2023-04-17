using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovements playerMovements;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE : "+score;
        //increase player speed
        if(score%10 == 0)
        {
            playerMovements.speed += playerMovements.speedIncreaser; 
        }
    }
    private void Awake()
    {
        inst = this;
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
