using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camswitch : MonoBehaviour
{
    public GameObject P1;
    public GameObject P3;
    private bool camerastatus = true;
    // Start is called before the first frame update
    void Start()
    {
        P1.SetActive(false);
        P3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            if (camerastatus == true)
            {
                P1.SetActive(false);
                P3.SetActive(true);
                camerastatus = false;
            }
            else
            {
                P1.SetActive(true);
                P3.SetActive(false);
                camerastatus = true;
            }
        }


    }
}
