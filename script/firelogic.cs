using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firelogic : MonoBehaviour
{
    public GameObject bulletprefab;
    public Transform firepoint;
    public Transform bullefolder;
    public float fireinterval = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", fireinterval, fireinterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Fire()
    {
        GameObject node = Instantiate(bulletprefab, bullefolder);
        node.transform.position = firepoint.position;
        node.transform.rotation = firepoint.rotation;
    }


}
