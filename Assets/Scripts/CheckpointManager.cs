using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    public GameObject[] allCheckpoints;
    public int nextCheckpoint;

    public bool isAllCheckpointsPassed;

    // Start is called before the first frame update
    void Start()
    {
        isAllCheckpointsPassed = false;
        nextCheckpoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkIfAllCheckpointsPassed();

        
    }

    private void checkIfAllCheckpointsPassed()
    {
        if (nextCheckpoint == allCheckpoints.Length)
        {
            isAllCheckpointsPassed = true;
        }
    }

    public void UpdateNextCheckpoint()
    {
        nextCheckpoint++;
    }


}
