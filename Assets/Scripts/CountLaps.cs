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

    [SerializeField] private TextMeshProUGUI  textPlayerLaps;
    [SerializeField] private TextMeshProUGUI  textRunner1Laps;
    [SerializeField] private TextMeshProUGUI  textRunner2Laps;
    [SerializeField] private TextMeshProUGUI  textRunner3Laps;
    [SerializeField] private TextMeshProUGUI  textRunner4Laps;

    private bool runner1Crossed = false;
    private bool runner2Crossed = false;
    private bool runner3Crossed = false;
    private bool runner4Crossed = false;

    private int playerPosition = 1;

    private void Start()
    {
        // Desnecessário
        
        /*textPlayerLaps = GameObject.Find ("PlayerLapsText").GetComponent<TextMeshProUGUI> ();
        textRunner1Laps = GameObject.Find ("Runner1LapsText").GetComponent<TextMeshProUGUI> ();
        textRunner2Laps = GameObject.Find ("Runner2LapsText").GetComponent<TextMeshProUGUI> ();
        textRunner3Laps = GameObject.Find ("Runner3LapsText").GetComponent<TextMeshProUGUI> ();
        textRunner4Laps = GameObject.Find ("Runner4LapsText").GetComponent<TextMeshProUGUI> ();*/
    }

    private void Update()
    {
        CheckEndRace();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lapCompletedPlayer ++;
            textPlayerLaps.text = lapCompletedPlayer.ToString();
        }
        if (collision.gameObject.tag == "Runner1")
        {
            lapCompletedRunner1 ++;
            textRunner1Laps.text = lapCompletedRunner1.ToString();
        }
        if (collision.gameObject.tag == "Runner2")
        {
            lapCompletedRunner2 ++;
            textRunner2Laps.text = lapCompletedRunner2.ToString();
        }
        if (collision.gameObject.tag == "Runner3")
        {
            lapCompletedRunner3 ++;
            textRunner3Laps.text = lapCompletedRunner3.ToString();
        }
        if (collision.gameObject.tag == "Runner4")
        {
            lapCompletedRunner4 ++;
            textRunner4Laps.text = lapCompletedRunner4.ToString();
        }
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
