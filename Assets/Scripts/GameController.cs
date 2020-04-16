using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int playerScore = 0;
    public List<GameObject> oncomingObstacles = new List<GameObject>() ;
    public GameObject obstacle;
    public float obstacleDistance = 5f;
    private int numObstacles = 10;
    private int firstObstaclePositon = 10;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateWorld();
        InitiateCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateWorld()
    {
        //Set up the level
        spawnObstacles(numObstacles);
    }

    void InitiateCountdown()
    {
        //Begin a countdown before game starts 3..2..1..GO!
    }

    public void UpdateScore()
    {
        playerScore++;
        print(playerScore);
    }

    void spawnObstacles(int numObs)
    {
        float xPos = firstObstaclePositon;
        for (int i = 0; i < numObs; i++)
        {
            GameObject ob = Instantiate(obstacle);
            oncomingObstacles.Add(ob);
            float y = Random.Range(-2.5f, 2.5f);
            ob.transform.position = new Vector3(xPos, y);
            xPos = xPos + obstacleDistance;
        }
    }
}
