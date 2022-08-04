using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI  textDice1;
    [SerializeField] public TextMeshProUGUI  textDice2;
    [SerializeField] public TextMeshProUGUI  textDice3;
    [SerializeField] public TextMeshProUGUI  textDice4;
    [SerializeField] public TextMeshProUGUI  textDice5;

    public bool isRolling;

    public MoveRunners moveRunnersPlayer;
    private BoostPlayerScript boostPlayerScript;
    [SerializeField] private GameObject player;

    private void Start()
    {
        moveRunnersPlayer = player.GetComponent<MoveRunners>();
        boostPlayerScript = player.GetComponent<BoostPlayerScript>();

        StartCoroutine(boostPlayerScript.RollDices());
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && (isRolling == false))
        {
            isRolling = true;
            StartCoroutine(boostPlayerScript.RollDices());   
        }

        if (Input.GetKeyDown("return"))
        {
            StartCoroutine(boostPlayerScript.PickDices());
        }

        if (Input.GetKeyDown("backspace"))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}