using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody enermyrb;
    private GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        enermyrb = GetComponent<Rigidbody>();
        point = GameObject.Find("focalpoint");
    }

    // Update is called once per frame
    void Update()
    {

        enermyrb.AddForce((point.transform.position - transform.position) * speed);
    }
}
