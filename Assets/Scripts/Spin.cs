using UnityEngine;

public class Spin : MonoBehaviour
{
    [Range(-100, 100)]
    public float spinSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }
}
