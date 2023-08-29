using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public int checkPointID;
    private CheckpointManager cpManager;
    private GameObject thisCheckpoint;
    private TimerScript tmScript;

    private Text bestCpTimerText;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetFloat("bestCheckpointTimer" + checkPointID, 0);
        print("local cp timer: " + checkPointID +" "+PlayerPrefs.GetFloat("bestCheckpointTimer" + checkPointID));
        bestCpTimerText = GameObject.Find("Best Checkpoint Timer").GetComponent<Text>();
        cpManager = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();
        tmScript = GameObject.FindGameObjectWithTag("TimerScriptManager").GetComponent<TimerScript>();
        thisCheckpoint = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<PrometeoCarController>().gameObject.tag == "Player")
        {
            if (thisCheckpoint == (GameObject)cpManager.allCheckpoints.GetValue(checkPointID))
            {
                if(checkPointID == cpManager.nextCheckpoint)
                {
                    print(checkPointID + "checkpoint has been passed");

                    //updates next checkpoint
                    cpManager.UpdateNextCheckpoint();

                    //saves and shows the previous checkpoint timer.
                    registerNewBestCheckpointTime();

                    
                }

            }
            else
            {
                print("too bad");
            }
        }
    }

    private void registerNewBestCheckpointTime()
    {
        //check if the previous time is better than the new time
        float localCpTimee = PlayerPrefs.GetFloat("bestCheckpointTimer" + checkPointID);
        /*        if(checkPointID >= 1)
                {
                    if(localCpTime > 0)
                    {
                        localCpTime -= tmScript.timerTime;
                    }

                }*/

        print("localCPTIME: " + localCpTimee);
        print("timer time: " + tmScript.timerTime);
        float minutes;
        float seconds;

        if (tmScript.timerTime >= localCpTimee)
        {
            bestCpTimerText.color = Color.red;

            if(localCpTimee == 0)
            {
                minutes = Mathf.FloorToInt(tmScript.timerTime / 60);
                seconds = Mathf.FloorToInt(tmScript.timerTime % 60);
                PlayerPrefs.SetFloat("bestCheckpointTimer" + checkPointID, tmScript.timerTime);
            }
            else
            {
                minutes = Mathf.FloorToInt(PlayerPrefs.GetFloat("bestCheckpointTimer" + checkPointID) / 60);
                seconds = Mathf.FloorToInt(PlayerPrefs.GetFloat("bestCheckpointTimer" + checkPointID) % 60);
            }
            bestCpTimerText.text = "Prev. Best Time: \n" + string.Format("{0:00} : {1:00}", minutes, seconds);

        }
        else
        {
            bestCpTimerText.color = Color.green;
            PlayerPrefs.SetFloat("bestCheckpointTimer" + checkPointID, tmScript.timerTime);
            minutes = Mathf.FloorToInt(tmScript.timerTime / 60);
            seconds = Mathf.FloorToInt(tmScript.timerTime % 60);

            bestCpTimerText.text = "New Best Time: \n" + string.Format("{0:00} : {1:00}", minutes, seconds);
        }




    }
}
