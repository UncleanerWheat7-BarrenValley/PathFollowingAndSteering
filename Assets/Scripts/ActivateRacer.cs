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
    }

    private void OnDisable()
    {
        RaceController.onRaceStart -= StartRace;
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
}
