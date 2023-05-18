using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] float acceleration = 9.8f;

    Vector3 gravityOffset = Vector3.zero;

    void Start()
    {
        if (SystemInfo.supportsGyroscope)
            Input.gyro.enabled = true;

        CalibrateGravity();
    }

    void Update()
    {
        Physics.gravity = GetGravityFromSensor() + gravityOffset;
    }

    public void CalibrateGravity()
    {
        gravityOffset = Vector3.down * acceleration - GetGravityFromSensor();
    }

    public Vector3 GetGravityFromSensor()
    {
        Vector3 gravity;
        if (Input.gyro.gravity != Vector3.zero)
            gravity = Input.gyro.gravity * acceleration;
        else
            gravity = Input.gyro.gravity * acceleration;

        gravity.z = Mathf.Clamp(gravity.z,float.MinValue,1);
        return new Vector3(gravity.x,gravity.z,gravity.y);
    }
}
