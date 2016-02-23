using UnityEngine;
using System.Collections;

public class MouseAimCamera : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 5;



    void Start()
    {
        transform.parent = target.transform;

    }

    void Update(){

    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.RotateAround(target.transform.position, Vector3.up, horizontal);
    }
}