using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float hoverDis = 0.002f;
    public float hoverSpeed = 0.25f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Mathf.Sin(transform.eulerAngles.y * hoverSpeed) * hoverDis, 0);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
