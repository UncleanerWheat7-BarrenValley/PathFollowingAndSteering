using UnityEngine;

public class AvoidancePath : MonoBehaviour
{
    public Path path;    
    public bool isLooping = true;
    public float waypointRadius = 1.0f;

    private float curSpeed;

    int curPathIndex = 0;
    float pathLength;
    Vector3 targetPoint;

    public float radius = 1.2f;
    public float speed = 10.0f;
    public float force = 50.0f;
    public float minimumDistToAvoid = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pathLength = path.Length;
    }

    // Update is called once per frame
    void Update()
    {   
        targetPoint = path.GetPoint(curPathIndex);

        if (Vector3.Distance(transform.position, targetPoint) < waypointRadius) 
        {
            if(curPathIndex < pathLength - 1)
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

            if (curPathIndex >= pathLength)
            {
                return;
            }
        }

        Vector3 dir = (targetPoint - transform.position);
        dir.Normalize();

        AvoidObstacles(ref dir);

        curSpeed = speed * Time.deltaTime;
        var rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 5.0f * Time.deltaTime);

        transform.position += transform.forward * curSpeed;
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }
    

    private void AvoidObstacles(ref Vector3 dir)
    {
        int layerMask = 1 << 8;
        if (Physics.SphereCast(transform.position, radius, transform.forward, out var hit, minimumDistToAvoid, layerMask))
        {
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0.0f;
            dir = transform.forward + hitNormal * force;
        }
    }
}
