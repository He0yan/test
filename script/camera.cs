using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float speed = 2f;
    public float Gate = 0.2f;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {

            transform.position = player.transform.position + new Vector3(0, 3, -8);
        transform.LookAt(player.transform.position);


        }
}
