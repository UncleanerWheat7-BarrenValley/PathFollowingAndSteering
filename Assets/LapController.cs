using System;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class LapController : MonoBehaviour
{
    int lapCount = 0;
    int checkpointCount = 6;
    public GameObject[] CheckPoints;
    public GameObject Flag;
    public RaceController raceController;

    private void OnEnable()
    {
        RaceController.onRaceEnd += EndRace;
    }


    private void OnDisable()
    {
        RaceController.onRaceEnd -= EndRace;
    }

    private void EndRace()
    {
        if (gameObject.name.Contains("Player"))
        {
            Flag.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Lap") && checkpointCount == 6)
        {
            lapCount++;
            checkpointCount = 0;

            if (lapCount > 3)
            {
                raceController.EndRace();
            }
        }
        else if (other.name.Contains("Checkpoint") && other.gameObject == CheckPoints[checkpointCount])
        {
            checkpointCount++;
        }
    }
}
