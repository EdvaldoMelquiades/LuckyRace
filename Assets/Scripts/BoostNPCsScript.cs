using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoostNPCsScript : MonoBehaviour
{
    [SerializeField] private GameObject Runner;
    [SerializeField] private TextMeshProUGUI RunnerLap;

    private MoveRunners MoveRunners;

    private bool isTurboActive;
    private int lapsPerformed;

    private void Start()
    {
        MoveRunners = Runner.GetComponent<MoveRunners>();
        
        InvokeRepeating("NPCRunnersSpeed1", 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "EndLine")
        {
            Debug.Log("Collided");
            lapsPerformed ++;
            RunnerLap.text = lapsPerformed.ToString();
        }
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