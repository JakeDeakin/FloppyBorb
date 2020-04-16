using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Transform t;
    public float speed = 1f;
    public GameController gc;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        t = this.GetComponent<Transform>();
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacle();
        ResetObstacle();
    }

    void MoveObstacle()
    {
        //Move the obstacle to the left
        t.Translate(new Vector3(-Time.deltaTime, 0f, 0f) * speed);
    }

    void ResetObstacle()
    {
        if (t.position.x <= gc.oncomingObstacles.Count * gc.obstacleDistance * -1f * 0.5f)
        {
            y = Random.Range(-2.5f, 2.5f);
            GameObject go = gc.oncomingObstacles[9];
            t.position = new Vector3(go.transform.position.x + gc.obstacleDistance, y);
            gc.oncomingObstacles.RemoveAt(0);
            gc.oncomingObstacles.Add(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        gc.UpdateScore();
    }
}
