using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform objectToOrbit;
    public float radius = 3;
    float sensitivity = SliderMaker.sensitivity;

    // Update is called once per frame
    void Update()
    {
        sensitivity = SliderMaker.sensitivity;
        radius -= Input.mouseScrollDelta.y;
        transform.position = objectToOrbit.position - (transform.forward * radius);
        transform.RotateAround(objectToOrbit.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivity);
        transform.RotateAround(objectToOrbit.position, transform.right, -Input.GetAxis("Mouse Y") * sensitivity);
    }
}
