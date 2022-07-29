using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] public TextMeshProUGUI  textDicePlayer;
    [SerializeField] public TextMeshProUGUI  textDice1;
    [SerializeField] public TextMeshProUGUI  textDice2;
    [SerializeField] public TextMeshProUGUI  textDice3;
    [SerializeField] public TextMeshProUGUI  textDice4;

    public bool isRolling;

    public MoveRunners moveRunnersPlayer;
    private BoostPlayerScript boostPlayerScript;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        moveRunnersPlayer = player.GetComponent<MoveRunners>();
        boostPlayerScript = this.GetComponent<BoostPlayerScript>();

        StartCoroutine(boostPlayerScript.RollPlayerDice());
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && (isRolling == false))
        {
            isRolling = true;
            StartCoroutine(boostPlayerScript.RollPlayerDice());   
        }

        if (Input.GetKeyDown("return"))
        {
            StartCoroutine(boostPlayerScript.ChooseNumber());
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