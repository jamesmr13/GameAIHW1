using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float maxLinearAcceleration;
    public float maxLinearSpeed;

    public float linearSpeed;

    public Vector3 linearVelocity;
    public Vector3 linearAcceleration;
    public Vector3 angularVelocity;
    public Vector3 angularAcceleration;

    void Start()
    {
        linearVelocity = new Vector3(0, 0, 0);
        linearAcceleration = new Vector3(0, 0, 0);
        angularVelocity = new Vector3(0, 0, 0);
        angularAcceleration = new Vector3(0, 0, 0);

    }
    void Update()
    {
        linearAcceleration = Vector3.ClampMagnitude(linearAcceleration, maxLinearAcceleration);
        linearVelocity += linearAcceleration * Time.deltaTime;

        linearVelocity = Vector3.ClampMagnitude(linearVelocity, maxLinearSpeed);
        transform.position = transform.position + linearVelocity * Time.deltaTime;

        linearSpeed = linearVelocity.magnitude;
    }
}