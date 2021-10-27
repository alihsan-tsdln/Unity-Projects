using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bucket : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject winnerGround;
    public TextMeshPro score;
    public int capacity;
    public bool win = false;
    private int balls = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Score(balls, capacity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Score(int ball, int goal)
    {
        score.text = ball + "/" + goal;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            balls++;
            Score(balls, capacity);
        }

        if(balls >= capacity)
        {
            win = true;
            winnerGround.SetActive(true);
        }
    }
}
