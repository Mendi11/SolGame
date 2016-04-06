using UnityEngine;
using System.Collections;

public class BreatheSimple : MonoBehaviour
{
    Vector3 startPos;

    // Set start position

    protected void Start()
    {
        startPos = transform.position;
    }


    // Hoover simulation, interpolating between 2 values

    protected void Update()
    {
        float distance = Mathf.Sin(Time.timeSinceLevelLoad);
        transform.position = startPos + Vector3.up * (distance/10) * 0.5f;
    }
}