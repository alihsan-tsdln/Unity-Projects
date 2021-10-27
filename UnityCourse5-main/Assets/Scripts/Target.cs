using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody targetRb;
    GameManager gameManager;
    public ParticleSystem explosionParticle;

    private float maxForce = 12;
    private float minForce = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    public int pointValue;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(randomForce() , ForceMode.Impulse);
        targetRb.AddTorque(randomTorque(), randomTorque(), randomTorque());

        transform.position = randomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }

        Destroy(gameObject);
    }

    private Vector3 randomForce()
    {
        return Random.Range(minForce, maxForce) * Vector3.up;
    }

    private float randomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 randomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }





}
