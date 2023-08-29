using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSpectator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] differentSkins;
    private TemporaryCrowdSpawner crowdSpawner;

    private int randomSpawnNumber;
    private int randomSelfDestructNo;

    private Animator animator;

    void Start()
    {
        crowdSpawner = GameObject.FindGameObjectWithTag("CrowdSpawner").GetComponent<TemporaryCrowdSpawner>();
        animator = GetComponent<Animator>();

        activateDifferentSkin();
        randomlySelfDestruct();


        //InvokeRepeating("setRandomAnimation", 0, Random.Range(4, 8));

        setRandomAnimation();

    }

    private void setRandomAnimation()
    {
        float randomFloatForAnimator = Random.Range(0f, 1f);
        animator.SetFloat("AnimationState", randomFloatForAnimator);
        //float velocity = 0.0f;
        //animator.SetFloat("AnimationState", Mathf.SmoothDamp(animator.GetFloat("AnimationState"), randomFloatForAnimator, ref velocity, 0.5f));
    }

    private void randomlySelfDestruct()
    {
        randomSelfDestructNo = Random.RandomRange(1, 100);
        if(randomSelfDestructNo <= crowdSpawner.selfDestructChanceInPercnt)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void activateDifferentSkin()
    {
        randomSpawnNumber = Random.Range(1, 9);
        GameObject skin = differentSkins[randomSpawnNumber].gameObject;
        skin.SetActive(true);
    }    
}
