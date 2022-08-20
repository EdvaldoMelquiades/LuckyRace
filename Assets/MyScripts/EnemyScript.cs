using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public int lapsPerformed;

    [SerializeField] private GameObject Runner;

    [SerializeField] private TextMeshProUGUI RunnerLap;

    private MoveRunners MoveRunners;

    private bool isTurboActive;

    private void Start()
    {
        MoveRunners = Runner.GetComponent<MoveRunners>();

        StartCoroutine(NPCSpeedBoost());
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "EndLine")
        {
            lapsPerformed ++;
            RunnerLap.text = lapsPerformed.ToString();
        }
    }

    private IEnumerator NPCSpeedBoost()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            
            int rollSpeedRunners = Random.Range(1, 6);

            if (rollSpeedRunners == 1)
            {
                MoveRunners.speed = 10;
            }
            else
            {
                MoveRunners.speed = 5;
            }
        }
    }
}