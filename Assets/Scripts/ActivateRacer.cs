using System.Diagnostics;
using System.IO;
using UnityEngine;

public class ActivateRacer : MonoBehaviour
{
    AvoidancePath avoidancePathScript;
    PlayerController playerController;
    private void OnEnable()
    {
        RaceController.onRaceStart += StartRace;
        RaceController.onRaceEnd += EndRace;
    }

    private void OnDisable()
    {
        RaceController.onRaceStart -= StartRace;
        RaceController.onRaceEnd -= EndRace;
    }

    private void Start()
    {
        avoidancePathScript = GetComponent<AvoidancePath>();
        playerController = GetComponent<PlayerController>();
    }
    void StartRace()
    {
        if (avoidancePathScript != null)
        {
            avoidancePathScript.enabled = true;            
        }
        if (playerController != null) 
        {
            playerController.enabled = true;            
        }
    }

    void EndRace() 
    {  
        if (playerController != null)
        {            
            playerController.maxSpeed = 0;
        }
    }
}
