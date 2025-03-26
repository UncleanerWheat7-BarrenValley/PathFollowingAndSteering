using System;
using UnityEngine;

public class Avoidance : MonoBehaviour
{
    public float radius = 1.2f;
    public float speed = 10.0f;
    public float force = 50.0f;
    public float minimumDistToAvoid = 10.0f;
    public float targetReachedRadius = 3.0f;

    float curSpeed;
    Vector3 targetPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPoint = Vector3.zero;
    }

    private void OnGUI()
    {
        GUILayout.Label("Click to move here");
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out var hit, 100.0f))
        {
            targetPoint = hit.point + Vector3.up * 0.5f;
        }

        Vector3 dir = (targetPoint - transform.position);
        dir.Normalize();

        AvoidObstacles(ref dir);

        if (Vector3.Distance(targetPoint, transform.position) < targetReachedRadius)
        {
            return;
        }

        curSpeed = speed * Time.deltaTime;
        var rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 5.0f * Time.deltaTime);

        transform.position += transform.forward * curSpeed;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

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
