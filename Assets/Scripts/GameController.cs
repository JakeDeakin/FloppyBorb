using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int playerScore = 0;
    public int highScore = 0;
    public List<GameObject> oncomingObstacles = new List<GameObject>() ;
    public GameObject obstacle;
    public float obstacleDistance = 5f;
    private int numObstacles = 10;
    private int firstObstaclePositon = 10;
    public Text playerScoreUI;
    public Text highScoreUI;

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
        SpawnObstacles(numObstacles);
    }

    void InitiateCountdown()
    {
        //Begin a countdown before game starts 3..2..1..GO!
    }

    public void UpdateScore()
    {
        playerScore++;
        print(playerScore);
        playerScoreUI.text = playerScore.ToString();
    }

    void SpawnObstacles(int numObs)
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

    private void UpdateHighScore()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreUI.text = highScore.ToString();
        }
    }

    private void ResetPlayerScore()
    {
        playerScore = 0;
        playerScoreUI.text = "0";
    }

    private void ClearObstacles()
    {
        
        foreach (GameObject obj in oncomingObstacles)
        {
            Destroy(obj);
        }
        oncomingObstacles.Clear();
    }

    public void ResetLevel()
    {
        ClearObstacles();
        InstantiateWorld();
        UpdateHighScore();
        ResetPlayerScore();
    }
}
