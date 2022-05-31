using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectRotation : MonoBehaviour
{
    public float localRotateSpeed;
    public float orbitSpeed;

    // Update is called once per frame
    void Update()
    {
        Motion();
    }

    void Motion()
    {
        transform.Rotate(new Vector3(0f, localRotateSpeed, 0f) * Time.deltaTime);
        transform.RotateAround(transform.parent.position, new Vector3(0, 1, 0), orbitSpeed * Time.deltaTime);
    }
}
