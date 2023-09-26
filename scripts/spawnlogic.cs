using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnlogic : MonoBehaviour
{
    public Transform enermyfolder;
    public GameObject enermyprefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("enermyborn", 1, 5);
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void enermyborn()
    {
        GameObject node = Instantiate(enermyprefab, enermyfolder);
        node.transform.position = Generaterandompos();

    }
    private Vector3 Generaterandompos()
    {
        float spawnPosx = Random.Range(-20, 20);
        float spawnPosz = Random.Range(-20, 20);
        Vector3 randomPos = new Vector3(spawnPosx, 1, spawnPosz);
        return randomPos;
    }
}
