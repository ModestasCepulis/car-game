using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    public Text timerText;


    private bool isTheFinishLineCrossed;
    public float timerTime;
    private CheckpointManager cpManager;




    // Start is called before the first frame update
    void Start()
    {
        isTheFinishLineCrossed = false;
        cpManager = new CheckpointManager();
    }

    // Update is called once per frame
    void Update()
    {
        print("is the line crossed: " + isTheFinishLineCrossed);
        StartCoroutine(makeTheTimerWork());
    }

    IEnumerator makeTheTimerWork()
    {
        if (!isTheFinishLineCrossed)
        {
            float minutes = Mathf.FloorToInt(timerTime / 60);
            float seconds = Mathf.FloorToInt(timerTime % 60);

            timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

            yield return new WaitForSeconds(3.0f);
            timerTime += Time.deltaTime;


        }
    }

    public void setIfTheFinishLineCrossed(bool value)
    {
        isTheFinishLineCrossed = value;
    }

}
