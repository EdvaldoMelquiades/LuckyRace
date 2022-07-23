using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    // Variáveis para o texto dos dados
    private TextMeshProUGUI  textDicePlayer;
    private TextMeshProUGUI  textDice1;
    private TextMeshProUGUI  textDice2;
    private TextMeshProUGUI  textDice3;
    private TextMeshProUGUI  textDice4;

    // Variáveis para os números sorteados em cada dado
    int rolledDicePlayer;
    int rolledDice1;
    int rolledDice2;
    int rolledDice3;
    int rolledDice4;

    bool isBoosting;

    // Define a variável para acessar o script do player
    MoveRunners moveRunnersPlayer;

    // Define a variável para acessar o script dos NPCs
    MoveRunners moveRunnersRunner1;
    MoveRunners moveRunnersRunner2;
    MoveRunners moveRunnersRunner3;
    MoveRunners moveRunnersRunner4;

    [SerializeField] GameObject player;
    [SerializeField] GameObject runner1;
    [SerializeField] GameObject runner2;
    [SerializeField] GameObject runner3;
    [SerializeField] GameObject runner4;

    void Start(){
        // Captura o campo texto dos dados
        textDicePlayer = GameObject.Find ("PlayerDiceText").GetComponent<TextMeshProUGUI> ();
        textDice1 = GameObject.Find ("Dice1Text").GetComponent<TextMeshProUGUI> ();
        textDice2 = GameObject.Find ("Dice2Text").GetComponent<TextMeshProUGUI> ();
        textDice3 = GameObject.Find ("Dice3Text").GetComponent<TextMeshProUGUI> ();
        textDice4 = GameObject.Find ("Dice4Text").GetComponent<TextMeshProUGUI> ();

        // Captura o script do player
        moveRunnersPlayer = player.GetComponent<MoveRunners>();

        // Captura o script do NPC
        moveRunnersRunner1 = runner1.GetComponent<MoveRunners>();
        moveRunnersRunner2 = runner2.GetComponent<MoveRunners>();
        moveRunnersRunner3 = runner3.GetComponent<MoveRunners>();
        moveRunnersRunner4 = runner4.GetComponent<MoveRunners>();

        RollDice();

        //InvokeRepeating("NPCRunnersSpeed1", 1f, 1f);
        //InvokeRepeating("NPCRunnersSpeed2", 1f, 1f);
        //InvokeRepeating("NPCRunnersSpeed3", 1f, 1f);
        InvokeRepeating("NPCRunnersSpeed4", 1f, 1f);
    }

    void Update(){
        if (Input.GetKeyDown("space")){
            RollDice();    
        }

        if (Input.GetKeyDown("return")){
            ChooseNumber();
        }
        if (Input.GetKeyDown("backspace")){
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown("escape")){
            Application.Quit();
        }
    }

    // Somente para rolagem do player
    void RollDice(){
        Debug.Log("Rolled");
        // Rola o dado dentro de um valor especificado
        rolledDicePlayer = Random.Range(1, 20);
        rolledDice1 = Random.Range(1, 20);
        rolledDice2 = Random.Range(1, 20);
        rolledDice3 = Random.Range(1, 20);
        rolledDice4 = Random.Range(1, 20);

        // Atribui o valor rolado ao campo de texto do objeto
        textDicePlayer.text = rolledDicePlayer.ToString();
        textDice1.text = rolledDice1.ToString();
        textDice2.text = rolledDice2.ToString();
        textDice3.text = rolledDice3.ToString();
        textDice4.text = rolledDice4.ToString();
    }

    // Somente para escolha dos dados do player
    void ChooseNumber(){
        if ((rolledDicePlayer == rolledDice1) || (rolledDicePlayer == rolledDice2) || (rolledDicePlayer == rolledDice3) || (rolledDicePlayer == rolledDice4)){
            Debug.Log("Right");
            moveRunnersPlayer.speed += 1;
            RollDice();
        }
        else{
            Debug.Log("Wrong");
            if (moveRunnersPlayer.speed <= 3){
                moveRunnersPlayer.speed = 0;
            }
            else{
                moveRunnersPlayer.speed -= 3;
            }
        }
    }

    // Aumenta a velocidade dos NPCs caso tire de 1 a 3 no D20
    void NPCRunnersSpeed1(){
        if (isBoosting == false){
            int rollSpeedRunners = Random.Range(1, 20);
            Debug.Log(rollSpeedRunners);

            if ((rollSpeedRunners == 1) || (rollSpeedRunners == 2) || (rollSpeedRunners == 3)){
                moveRunnersRunner1.speed = 10;
                isBoosting = true;
            }
        }
        else{
            moveRunnersRunner1.speed = 5;
            isBoosting = false;
        }
    }
    void NPCRunnersSpeed2(){
        if (isBoosting == false){
            int rollSpeedRunners = Random.Range(1, 20);
            Debug.Log(rollSpeedRunners);

            if ((rollSpeedRunners == 1) || (rollSpeedRunners == 2) || (rollSpeedRunners == 3)){
                moveRunnersRunner2.speed = 10;
                isBoosting = true;
            }
        }
        else{
            moveRunnersRunner2.speed = 5;
            isBoosting = false;
        }
    }
    void NPCRunnersSpeed3(){
        if (isBoosting == false){
            int rollSpeedRunners = Random.Range(1, 20);
            Debug.Log(rollSpeedRunners);

            if ((rollSpeedRunners == 1) || (rollSpeedRunners == 2) || (rollSpeedRunners == 3)){
                moveRunnersRunner3.speed = 10;
                isBoosting = true;
            }
        }
        else{
            moveRunnersRunner3.speed = 5;
            isBoosting = false;
        }
    }
    void NPCRunnersSpeed4(){
        if (isBoosting == false){
            int rollSpeedRunners = Random.Range(1, 20);
            Debug.Log(rollSpeedRunners);

            if ((rollSpeedRunners == 1) || (rollSpeedRunners == 2) || (rollSpeedRunners == 3)){
                moveRunnersRunner4.speed = 10;
                isBoosting = true;
            }
        }
        else{
            moveRunnersRunner4.speed = 5;
            isBoosting = false;
        }
    }
}