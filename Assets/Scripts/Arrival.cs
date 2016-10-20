using UnityEngine;
using System.Collections;

public class Arrival : MonoBehaviour
{

    public GameObject destination;
    public float speed = .1f;
    public float acceleration = .1f;
    public float maxAcceleration = 2f;
    public float maxSpeed = 2f;
    public float slowRadius = 3f;
    public float targetRadius = 0.01f;
    public float targetSpeed = 0f;
    public float timetoTarget = 0.1f;

    public Vector3 linearVelocity;
    public Vector3 linearAcceleration;
    public Vector3 angularVelocity;
    public Vector3 angularAcceleration;

    public Vector3 direction;

    // Use this for initialization
    void Start()
    {
        linearVelocity = new Vector3(1f, 0f);
        linearAcceleration = new Vector3(0.2f, 0f);
        angularVelocity = new Vector3(1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        direction = destination.transform.position - transform.position;
        float distance = direction.magnitude;
        float tempTarget;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), angularVelocity.magnitude * Time.deltaTime);


        Vector3 targetVelocity = direction;

        if (distance < targetRadius)
        {
            linearVelocity = Vector3.zero;
        }

        if(distance < slowRadius)
        {
            tempTarget = maxSpeed * (distance / slowRadius);
        }
        else
        {
            tempTarget = maxSpeed;
        }

        targetVelocity = targetVelocity.normalized;
        targetVelocity *= tempTarget;

        linearAcceleration = targetVelocity - linearVelocity;
        linearAcceleration /= timetoTarget;
        linearAcceleration = Vector3.ClampMagnitude(linearAcceleration, maxAcceleration);

        linearVelocity += linearAcceleration * Time.deltaTime;

        linearVelocity = Vector3.ClampMagnitude(linearVelocity, maxSpeed);
        transform.position = transform.position + linearVelocity * Time.deltaTime;

        speed = linearVelocity.magnitude;
    }
}
