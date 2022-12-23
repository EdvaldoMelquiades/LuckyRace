using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Opponent1;
    [SerializeField] private GameObject Opponent2;
    [SerializeField] private GameObject Opponent3;
    [SerializeField] private GameObject Opponent4;

    [SerializeField] public TextMeshProUGUI  textDice1;
    [SerializeField] public TextMeshProUGUI  textDice2;
    [SerializeField] public TextMeshProUGUI  textDice3;
    [SerializeField] public TextMeshProUGUI  textDice4;
    [SerializeField] public TextMeshProUGUI  textDice5;

    private PlayerScript PlayerScript;
    private EnemyScript Enemy1Script;
    private EnemyScript Enemy2Script;
    private EnemyScript Enemy3Script;
    private EnemyScript Enemy4Script;

    public bool isRolling;

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
    public int totalRaceLaps = 10;

    private void Start()
    {
        PlayerScript = Player.GetComponent<PlayerScript>();
        Enemy1Script = Opponent1.GetComponent<EnemyScript>();
        Enemy2Script = Opponent2.GetComponent<EnemyScript>();
        Enemy3Script = Opponent3.GetComponent<EnemyScript>();
        Enemy4Script = Opponent4.GetComponent<EnemyScript>();
        
        StartCoroutine(PlayerScript.RollDices());
    }

    private void Update()
    {
        lapCompletedPlayer = PlayerScript.lapsPerformed;
        lapCompletedRunner1 = Enemy1Script.lapsPerformed;
        lapCompletedRunner2 = Enemy2Script.lapsPerformed;
        lapCompletedRunner3 = Enemy3Script.lapsPerformed;
        lapCompletedRunner4 = Enemy4Script.lapsPerformed;

        CheckEndRace();

        if (Input.GetKeyDown("space") && (isRolling == false))
        {
            isRolling = true;
            StartCoroutine(PlayerScript.RollDices()); 
        }

        if (Input.GetKeyDown("return"))
        {
            StartCoroutine(PlayerScript.PickDices());
        }

        if (Input.GetKeyDown("backspace") && (Time.timeScale == 0))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    private void CheckEndRace()
    {
        if (lapCompletedPlayer == totalRaceLaps)
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

        if ((lapCompletedRunner1 == totalRaceLaps) && (runner1Crossed == false))
        {
            playerPosition ++;
            runner1Crossed = true;
        }
        if ((lapCompletedRunner2 == totalRaceLaps) && (runner2Crossed == false))
        {
            playerPosition ++;
            runner2Crossed = true;
        }
        if ((lapCompletedRunner3 == totalRaceLaps) && (runner3Crossed == false))
        {
            playerPosition ++;
            runner3Crossed = true;
        }
        if ((lapCompletedRunner4 == totalRaceLaps) && (runner4Crossed == false))
        {
            playerPosition ++;
            runner4Crossed = true;
        }
    }
}