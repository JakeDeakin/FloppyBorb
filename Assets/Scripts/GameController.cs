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
    public GameObject player;

    public Text deathScreenScore;
    public Text deathScreenHighScore;

    private bool quitting;
    private bool paused = false;
    public GameObject deathScreen;
    private bool freezeControls = false;
    // Start is called before the first frame update
    void Start()
    {
        deathScreen.gameObject.SetActive(false);
        InstantiateWorld();
        InitiateCountdown();
        SetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (paused && Input.GetButton("Fire1") && !freezeControls)
        {
            ResetLevel();
        }
    }

    //Set up the level
    void InstantiateWorld()
    {
        SpawnObstacles(numObstacles);
    }

    void InitiateCountdown()
    {
        //Begin a countdown before game starts 3..2..1..GO!
    }

    public void UpdateScore()
    {
        playerScore++;
        playerScoreUI.text = playerScore.ToString();
        deathScreenScore.text = "Score: " + playerScore.ToString();
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
            deathScreenHighScore.text = "Highscore: " + highScore.ToString();
        }
    }

    private void ResetPlayerScore()
    {
        playerScore = 0;
        playerScoreUI.text = "0";
        deathScreenScore.text = "Score: " + playerScore.ToString();
    }

    private void ClearObstacles()
    {
        
        foreach (GameObject obj in oncomingObstacles)
        {
            Destroy(obj);
        }
        oncomingObstacles.Clear();
    }

    private void SetPlayer()
    {
        player.transform.position = new Vector3(0, 0);
        player.GetComponent<CharacterControls>().alive = true;
    }

    private void ResetLevel()
    {
        //UpdateHighScore();
        ClearObstacles();
        InstantiateWorld();
        ResetPlayerScore();
        SetPlayer();
        deathScreen.gameObject.SetActive(false);
        paused = false;
        Time.timeScale = 1;
        
        
    }

    public void PlayerDied()
    {
        //DeathWait();
        PauseGame();
        UpdateHighScore();
    }

    private void PauseGame()
    {
        deathScreen.gameObject.SetActive(true);
        paused = true;
        freezeControls = true;
        Time.timeScale = 0;
        StartCoroutine(DeathWait(0.5f));
    }

    IEnumerator DeathWait(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        freezeControls = false;
    }
}
