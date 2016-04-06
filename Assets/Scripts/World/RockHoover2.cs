using UnityEngine;
using System.Collections;

public class RockHoover2 : MonoBehaviour
{
    Vector3 startPos;

    protected void Start()
    {
        startPos = transform.position;
    }


    // Hoover in air simulation

    protected void Update()
    {
        float distance = Mathf.Sin(Time.timeSinceLevelLoad);
        transform.position = startPos + (Vector3.down/9) * (distance/2) * 2.0f;
    }
}