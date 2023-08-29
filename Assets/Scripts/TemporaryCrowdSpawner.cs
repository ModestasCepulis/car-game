using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryCrowdSpawner : MonoBehaviour
{

    public GameObject[] positions;
    public GameObject spectator;
    public int selfDestructChanceInPercnt;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject position in positions) 
        {
            Instantiate(spectator, position.transform.position, position.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
