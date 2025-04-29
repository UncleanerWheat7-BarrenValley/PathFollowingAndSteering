using Unity.VisualScripting;
using UnityEngine;

public class LapController : MonoBehaviour
{
    int lapCount = 0;
    int checkpointCount = 6;
    public GameObject[] CheckPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created   

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Lap") && checkpointCount == 6)
        {
            lapCount++;
            checkpointCount = 0;
        }
        else if (other.name.Contains("Checkpoint") && other.gameObject == CheckPoints[checkpointCount]) 
        {
            checkpointCount++;
        }
    }
}
