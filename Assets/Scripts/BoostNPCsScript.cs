using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostNPCsScript : MonoBehaviour
{
    private bool isNPCsBoosting;

    private MoveRunners moveRunnersRunner1;
    private MoveRunners moveRunnersRunner2;
    private MoveRunners moveRunnersRunner3;
    private MoveRunners moveRunnersRunner4;

    [SerializeField] private GameObject runner1;
    [SerializeField] private GameObject runner2;
    [SerializeField] private GameObject runner3;
    [SerializeField] private GameObject runner4;

    private void Start()
    {
        moveRunnersRunner1 = runner1.GetComponent<MoveRunners>();
        moveRunnersRunner2 = runner2.GetComponent<MoveRunners>();
        moveRunnersRunner3 = runner3.GetComponent<MoveRunners>();
        moveRunnersRunner4 = runner4.GetComponent<MoveRunners>();
        
        InvokeRepeating("NPCRunnersSpeed1", 1f, 1f);
        InvokeRepeating("NPCRunnersSpeed2", 1f, 1f);
        InvokeRepeating("NPCRunnersSpeed3", 1f, 1f);
        InvokeRepeating("NPCRunnersSpeed4", 1f, 1f);
    }

    void NPCRunnersSpeed1()
    {
        if (isNPCsBoosting == false)
        {
            int rollSpeedRunners = Random.Range(1, 20);

            if ((rollSpeedRunners == 1) || (rollSpeedRunners == 2))
            {
                moveRunnersRunner1.speed = 10;
                isNPCsBoosting = true;
            }
        }
        else{
            moveRunnersRunner1.speed = 5;
            isNPCsBoosting = false;
        }
    }
    void NPCRunnersSpeed2(){
        if (isNPCsBoosting == false){
            int rollSpeedRunners = Random.Range(1, 20);

            if ((rollSpeedRunners == 1) || (rollSpeedRunners == 2))
            {
                moveRunnersRunner2.speed = 10;
                isNPCsBoosting = true;
            }
        }
        else{
            moveRunnersRunner2.speed = 5;
            isNPCsBoosting = false;
        }
    }
    void NPCRunnersSpeed3(){
        if (isNPCsBoosting == false){
            int rollSpeedRunners = Random.Range(1, 20);

            if ((rollSpeedRunners == 1) || (rollSpeedRunners == 2))
            {
                moveRunnersRunner3.speed = 10;
                isNPCsBoosting = true;
            }
        }
        else{
            moveRunnersRunner3.speed = 5;
            isNPCsBoosting = false;
        }
    }
    void NPCRunnersSpeed4(){
        if (isNPCsBoosting == false){
            int rollSpeedRunners = Random.Range(1, 20);

            if ((rollSpeedRunners == 1) || (rollSpeedRunners == 2))
            {
                moveRunnersRunner4.speed = 10;
                isNPCsBoosting = true;
            }
        }
        else{
            moveRunnersRunner4.speed = 5;
            isNPCsBoosting = false;
        }
    }
}