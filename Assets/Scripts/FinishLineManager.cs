using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineManager : MonoBehaviour
{

    public GameObject[] lights;

    private TimerScript tmScript;
    private CheckpointManager cpManager;
    private PrometeoCarController carController;
    private GameObject tireScreechSounds;

    // Start is called before the first frame update
    void Start()
    {
        tireScreechSounds = GameObject.Find("Tire Screech Sound");
        carController = GameObject.FindGameObjectWithTag("Player").GetComponent<PrometeoCarController>();
        tmScript = GameObject.FindGameObjectWithTag("TimerScriptManager").GetComponent<TimerScript>();
        cpManager = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();

        tireScreechSounds.SetActive(false);
        carController.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(activateFinishLineLights());
    }

    IEnumerator activateFinishLineLights()
    {
        yield return new WaitForSeconds(1.0f);
        lights[0].SetActive(true);

        yield return new WaitForSeconds(1.0f);
        lights[1].SetActive(true);

        yield return new WaitForSeconds(1.0f);
        lights[2].SetActive(true);

        tireScreechSounds.SetActive(true);
        carController.enabled = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PrometeoCarController>().gameObject.tag == "Player")
        {
            theGameFinishLine();
        }
    }

    //if the game is fully finished (all cp passed, stop the game and stop the timer)
    private void theGameFinishLine()
    {
        if(cpManager.isAllCheckpointsPassed)
        {
            tmScript.setIfTheFinishLineCrossed(true);
        }
    }
}
