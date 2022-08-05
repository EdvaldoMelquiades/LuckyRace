using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject Runner;
    [SerializeField] private TextMeshProUGUI RunnerLap;
    private MoveRunners MoveRunners;
    private bool isTurboActive;
    public int lapsPerformed;

    private void Start()
    {
        MoveRunners = Runner.GetComponent<MoveRunners>();
        InvokeRepeating("RunnersBoostSpeed", 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "EndLine")
        {
            lapsPerformed ++;
            RunnerLap.text = lapsPerformed.ToString();
        }
    }

    void RunnersBoostSpeed()
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