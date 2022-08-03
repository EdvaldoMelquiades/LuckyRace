using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountLaps : MonoBehaviour
{
    public int lapCompletedPlayer;
    public int lapCompletedRunner1;
    public int lapCompletedRunner2;
    public int lapCompletedRunner3;
    public int lapCompletedRunner4;

    public GameObject endRacePanel;
    public GameObject endRace1st;
    public GameObject endRace2nd;
    public GameObject endRace3rd;
    public GameObject endRaceGameOver;

    private bool runner1Crossed = false;
    private bool runner2Crossed = false;
    private bool runner3Crossed = false;
    private bool runner4Crossed = false;

    private int playerPosition = 1;

    private void Update()
    {
        CheckEndRace();
    }

    private void CheckEndRace()
    {
        if (lapCompletedPlayer == 10)
        {
            Time.timeScale = 0;
            endRacePanel.SetActive(true);
            if (playerPosition == 1)
            {
                endRace1st.SetActive(true);
            }
            if (playerPosition == 2)
            {
                endRace2nd.SetActive(true);
            }
            if (playerPosition == 3)
            {
                endRace3rd.SetActive(true);
            }
            if ((playerPosition == 4) || (playerPosition == 5))
            {
                endRaceGameOver.SetActive(true);
            }
        }

        if ((lapCompletedRunner1 == 10) && (runner1Crossed == false))
        {
            playerPosition ++;
            runner1Crossed = true;
            //Debug.Log(playerPosition);
        }
        if ((lapCompletedRunner2 == 10) && (runner2Crossed == false))
        {
            playerPosition ++;
            runner2Crossed = true;
            //Debug.Log(playerPosition);
        }
        if ((lapCompletedRunner3 == 10) && (runner3Crossed == false))
        {
            playerPosition ++;
            runner3Crossed = true;
            //Debug.Log(playerPosition);
        }
        if ((lapCompletedRunner4 == 10) && (runner4Crossed == false))
        {
            playerPosition ++;
            runner4Crossed = true;
            //Debug.Log(playerPosition);
        }
    }
}
