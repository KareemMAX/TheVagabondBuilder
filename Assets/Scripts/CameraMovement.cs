using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 20.0f;
    public float minZoom = 2.0f;
    public float maxZoom = 8.0f;

    // Camera Object
    private new Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var newPos = Quaternion.Euler(0, 45, 0) *
            new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) +
            transform.position;

        transform.position = Vector3.Lerp(
            transform.position,
            newPos,
            Time.deltaTime * speed
            );
    }

    void FixedUpdate()
    {
        var newSize = camera.orthographicSize - Input.mouseScrollDelta.y;

        camera.orthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);
    }
}
