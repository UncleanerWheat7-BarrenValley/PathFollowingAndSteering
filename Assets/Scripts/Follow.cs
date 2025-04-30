using UnityEngine;

public class Follow : MonoBehaviour
{
    public Path path;
    public float speed = 5f;
    [Range(1.0f, 1000.0f)]
    public float steeringInertia = 10.0f;
    public bool isLooping = true;
    public float waypointRadius = 1.0f;

    private float curSpeed;

    int curPathIndex = 0;
    float pathLength;
    Vector3 targetPoint;

    Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pathLength = path.Length;
        velocity = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        curSpeed = speed * Time.deltaTime;
        targetPoint = path.GetPoint(curPathIndex);

        if (Vector3.Distance(transform.position, targetPoint) < waypointRadius)
        {
            if (curPathIndex < pathLength - 1)
            {
                curPathIndex++;
            }
            else if (isLooping)
            {
                curPathIndex = 0;
            }
            else
            {
                return;
            }
        }

        if(curPathIndex >= pathLength)
        {
            return;
        }

        if(curPathIndex >= pathLength - 1 && !isLooping)
        {
            velocity += Steer(targetPoint, true);
        }
        else
        {
            velocity += Steer(targetPoint);
        }

        transform.position += velocity;
        transform.rotation = Quaternion.LookRotation(velocity);
    }

    public Vector3 Steer(Vector3 target, bool bFinalPoint = false) 
    {
        Vector3 desiredVelocity = (target - transform.position);
        float dist = desiredVelocity.magnitude;
        desiredVelocity.Normalize();
        if (bFinalPoint && dist < waypointRadius)
        {
            desiredVelocity *= curSpeed * (dist / waypointRadius);
        }
        else 
        {
            desiredVelocity *= curSpeed;
        }

        Vector3 steeringForce = desiredVelocity - velocity;

        return steeringForce / steeringInertia;
    }
}
