using UnityEngine;
using System.Collections;

public class PathFollow : MonoBehaviour
{
    
    public GameObject[] path;
    public int currPoint = 0;
    public Vector3 linearVelocity;
    public Vector3 linearAcceleration;
    public Vector3 angularVelocity;
    public GameObject targetPoint = null;
    public Vector3 direction;

    void Start()
    {
    }

    void Update()
    {
        if(targetPoint == null)
        {
            targetPoint = path[currPoint];
        }
        walk();
    }

    void walk()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, targetPoint.transform.position - transform.position, angularVelocity.magnitude * Time.deltaTime, 0.0f);
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.transform.position, linearVelocity.magnitude * Time.deltaTime);
        direction = targetPoint.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), angularVelocity.magnitude * Time.deltaTime);

        if (transform.position == targetPoint.transform.position)
        {
            currPoint++;
            targetPoint = path[currPoint];
        }
    }
}