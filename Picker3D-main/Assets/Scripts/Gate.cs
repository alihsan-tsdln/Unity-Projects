using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    bool key = true;
    public bool left;
    public bool right;
    private Bucket bucket1;

    // Start is called before the first frame update
    void Start()
    {
        bucket1 = GameObject.Find("taban1").GetComponent<Bucket>();
    }

    // Update is called once per frame
    void Update()
    {
        bool win = bucket1.win;
        
        if (win)
        {
            if (left)
            {
                if (transform.rotation.z < 0.61f)
                {
                    transform.Rotate(0, 0, 75 * Time.deltaTime * 0.5f);
                }

                if (transform.rotation.z >= 0.61f && key)
                {
                    transform.position = new Vector3(transform.position.x - 2.25f, transform.position.y + 1.8f,
                        transform.position.z);
                    key = false;
                }
            }

            if (right)
            {
                if (transform.rotation.z > -0.61f)
                {
                    transform.Rotate(0, 0, -75 * Time.deltaTime * 0.5f);
                }

                if (transform.rotation.z <= -0.61f && key)
                {
                    transform.position = new Vector3(transform.position.x + 2.1f, transform.position.y + 1.8f,
                        transform.position.z);
                    key = false;
                }
            }
        }
    }
}
