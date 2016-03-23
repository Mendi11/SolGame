using UnityEngine;
using System.Collections;

public class RockHoover3 : MonoBehaviour
{
    Vector3 startPos;

    protected void Start()
    {
        startPos = transform.position;
    }

    protected void Update()
    {
        float distance = Mathf.Cos(Time.timeSinceLevelLoad);
        transform.position = startPos + (Vector3.up/4.5f) * (distance/5) * 2.0f;
    }
}