using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatlogic : MonoBehaviour
{
    public GameObject Maincamera;

    public GameObject Base;

    private Camera camera;

    public float maxlenth;

    private Ray raymouse;

    private Vector3 position;

    private Vector3 direction;

    private Quaternion rotation;

    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        camera = Maincamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var mouseposition = Input.mousePosition;
        raymouse = camera.ScreenPointToRay(mouseposition);
        if (Physics.Raycast(raymouse, out hit, maxlenth))
        {
            RotateToMouseposition(gameObject, hit.point);
        }
        else
        {
            var pos = raymouse.GetPoint(maxlenth);
            RotateToMouseposition(gameObject, pos);
        }
    }
    void RotateToMouseposition(GameObject obj,Vector3 destination)
    {
        destination.y = transform.position.y;
        destination.z = Base.transform.localPosition.z;
        destination.z = destination.z + 5;

        transform.LookAt(destination);
    }
}
