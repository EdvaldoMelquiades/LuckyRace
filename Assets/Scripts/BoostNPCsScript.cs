using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostNPCsScript : MonoBehaviour
{
    [SerializeField] private GameObject Runner;
    private MoveRunners MoveRunners;

    private bool isTurboActive;

    private void Start()
    {
        MoveRunners = Runner.GetComponent<MoveRunners>();
        
        InvokeRepeating("NPCRunnersSpeed1", 1f, 1f);
    }

    void NPCRunnersSpeed1()
    {
        if (isTurboActive == false)
        {
            int rollSpeedRunners = Random.Range(1, 20);

            if ((rollSpeedRunners == 1) || (rollSpeedRunners == 2))
            {
                MoveRunners.speed = 10;
                isTurboActive = true;
            }
        }
        else{
            MoveRunners.speed = 5;
            isTurboActive = false;
        }
    }
}