using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletlogic : MonoBehaviour
{
    public float speed = 1;
    public float lifetime = 5;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("selfDestroy", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
   
    private void selfDestroy()
    {
        Object.Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enermy"))
            Destroy(other.gameObject);
        selfDestroy();
    }
}
