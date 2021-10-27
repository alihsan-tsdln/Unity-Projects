using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float speedYatay;
    public float speedDikey;
    Transform cam;
    float offset;
    private Rigidbody magnetRb;
    private GameManager gameManager;
    private Bucket bucket1;
    private Bucket bucket2;
    private Bucket bucket3;
    public bool isStopped = false;
    private float stop1 = 40f;
    private float stop2 = 100f;
    private float stop3 = 180f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").transform;
        offset = Camera.main.transform.position.z - transform.position.z;
        magnetRb = gameObject.GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        bucket1 = GameObject.Find("taban1").GetComponent<Bucket>();
        bucket2 = GameObject.Find("taban2").GetComponent<Bucket>();
        bucket3 = GameObject.Find("taban3").GetComponent<Bucket>();
    }

    // Update is called once per frame
    void Update()
    {
        Stopper();
        MagnetMovement();
        CameraMovement();
    }
    
    void MagnetMovement()
    {
        float x = Mathf.Clamp(magnetRb.position.x +
            Input.GetAxis("Horizontal") * speedYatay * Time.deltaTime, -3, 3);
        float y = magnetRb.position.y;
        float z = magnetRb.position.z + speedDikey * Time.deltaTime;

        if (isStopped)
        {
            z = magnetRb.position.z;
        }

        magnetRb.MovePosition(new Vector3(x,y,z));
    }

    void CameraMovement()
    {

        cam.position = new Vector3(cam.position.x,
            cam.position.y, transform.position.z + offset);
    }

    void Stopper()
    {
        if (transform.position.z >= stop1 && !bucket1.win)
        {
            isStopped = true;
        }

        else if (transform.position.z >= stop2 && !bucket2.win)
        {
            isStopped = true;
        }

        else if (transform.position.z >= stop3 && !bucket3.win)
        {
            isStopped = true;
        }

        else
        {
            isStopped = false;
        }
    }

}
