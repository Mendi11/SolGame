using UnityEngine;
using System.Collections;

public class RockHoover : MonoBehaviour
{
    Vector3 startPos;

    protected void Start()
    {
        startPos = transform.position;
    }

    protected void Update()
    {
        float distance = Mathf.Cos(Time.timeSinceLevelLoad);
        transform.position = startPos + Vector3.up * (distance/7) * 1.0f;
    }
}