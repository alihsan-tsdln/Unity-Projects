using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRb;
    private float forcePower = 0.3f;
    private GameObject magnet;
    public bool chapter1;
    public bool chapter2;
    public bool chapter3;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = gameObject.GetComponent<Rigidbody>();
        magnet = GameObject.Find("Magnet");
    }

    // Update is called once per frame
    void Update()
    {
        bool stopped = magnet.GetComponent<Magnet>().isStopped;

        Vector3 offset1 = (GameObject.Find("taban1").transform.position
            - transform.position).normalized;
        Vector3 offset2 = (GameObject.Find("taban2").transform.position
            - transform.position).normalized;
        Vector3 offset3 = (GameObject.Find("taban3").transform.position
            - transform.position).normalized;

        if(chapter1)
        {
            if (stopped && transform.position.z < magnet.transform.position.z + 2.5f &&
            magnet.transform.position.z + 0.5f < transform.position.z &&
            transform.position.x < magnet.transform.position.x + 1 &&
            transform.position.x > magnet.transform.position.x - 1)
            {
                ballRb.AddForce(offset1 * forcePower, ForceMode.Impulse);
            }
        }

        if(chapter2)
        {
            if (stopped && transform.position.z < magnet.transform.position.z + 2.5f &&
            magnet.transform.position.z + 0.5f < transform.position.z &&
            transform.position.x < magnet.transform.position.x + 1 &&
            transform.position.x > magnet.transform.position.x - 1)
            {
                ballRb.AddForce(offset2 * forcePower, ForceMode.Impulse);
            }
        }

        if (chapter3)
        {
            if (stopped && transform.position.z < magnet.transform.position.z + 2.5f &&
            magnet.transform.position.z + 0.5f < transform.position.z &&
            transform.position.x < magnet.transform.position.x + 1 &&
            transform.position.x > magnet.transform.position.x - 1)
            {
                ballRb.AddForce(offset3 * forcePower, ForceMode.Impulse);
            }
        }

    }
}
