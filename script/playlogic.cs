using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playlogic : MonoBehaviour
{
    public float speed = 0.5f;
    public float turnspeed;
    public float horizontalInput;
    public float forwardInput;
    public bool haspowerup = false;
    public GameObject powerprefab;
    public Transform powerupfolder;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical"); 
        transform.Translate(Vector3.forward * Time.deltaTime * speed* forwardInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * horizontalInput);
        power();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
            haspowerup = true;
        Destroy(other.gameObject);
        StartCoroutine(Powercountdownroutine());
        StartCoroutine(powerup());

    }
    IEnumerator Powercountdownroutine()
    {
        yield return new WaitForSeconds(8);
        haspowerup = false;

    }
    IEnumerator powerup()
    {
        yield return new WaitForSeconds(10);
       GameObject node=    Instantiate(powerprefab, powerupfolder);
        node.transform.position= Generaterandompos();
    }
    private Vector3 Generaterandompos()
    {
        float spawnPosx = Random.Range(-20, 20);
        float spawnPosz = Random.Range(-20, 20);
        Vector3 randomPos = new Vector3(spawnPosx, 1, spawnPosz);
        return randomPos;
    }
    private void power()
    {
        if(haspowerup)
        {
            speed = 30;
            turnspeed = 30;
        }
        if(!haspowerup)
        {
            speed = 5;
            turnspeed = 10;       
        }
    }

}
