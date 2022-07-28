using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  textDicePlayer;
    [SerializeField] private TextMeshProUGUI  textDice1;
    [SerializeField] private TextMeshProUGUI  textDice2;
    [SerializeField] private TextMeshProUGUI  textDice3;
    [SerializeField] private TextMeshProUGUI  textDice4;

    private int rolledDicePlayer;
    private int rolledDice1;
    private int rolledDice2;
    private int rolledDice3;
    private int rolledDice4;

    private bool isRolling;

    private MoveRunners moveRunnersPlayer;

    [SerializeField] private GameObject player;

    void Start()
    {
        moveRunnersPlayer = player.GetComponent<MoveRunners>();

        StartCoroutine(RollPlayerDice());
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && (isRolling == false))
        {
            isRolling = true;
            StartCoroutine(RollPlayerDice());   
        }

        if (Input.GetKeyDown("return"))
        {
            StartCoroutine(ChooseNumber());
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

    IEnumerator RollPlayerDice()
    {
        yield return new WaitForSeconds(1);

        rolledDicePlayer = Random.Range(1, 20);
        rolledDice1 = Random.Range(1, 20);
        rolledDice2 = Random.Range(1, 20);
        rolledDice3 = Random.Range(1, 20);
        rolledDice4 = Random.Range(1, 20);

        textDicePlayer.text = rolledDicePlayer.ToString();
        textDice1.text = rolledDice1.ToString();
        textDice2.text = rolledDice2.ToString();
        textDice3.text = rolledDice3.ToString();
        textDice4.text = rolledDice4.ToString();

        isRolling = false;
    }

    IEnumerator ChooseNumber()
    {
        if ((rolledDicePlayer == rolledDice1) || (rolledDicePlayer == rolledDice2) || (rolledDicePlayer == rolledDice3) || (rolledDicePlayer == rolledDice4))
        {
            moveRunnersPlayer.speed = 10;
            StartCoroutine(RollPlayerDice());
            yield return new WaitForSeconds(1);
            moveRunnersPlayer.speed = 5;
        }
    }
}