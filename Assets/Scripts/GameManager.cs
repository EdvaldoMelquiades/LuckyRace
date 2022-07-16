using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour{
    // Define as variáveis TMPro
    private TextMeshProUGUI  playerDice;
    private TextMeshProUGUI  Dice1;
    private TextMeshProUGUI  Dice2;
    private TextMeshProUGUI  Dice3;
    private TextMeshProUGUI  Dice4;

    int rollPlayerDice;
    int rollDice1;
    int rollDice2;
    int rollDice3;
    int rollDice4;

    void Start(){
        // Localiza o objeto e captura o campo texto
        playerDice = GameObject.Find ("PlayerDiceText").GetComponent<TextMeshProUGUI> ();
        Dice1 = GameObject.Find ("Dice1Text").GetComponent<TextMeshProUGUI> ();
        Dice2 = GameObject.Find ("Dice2Text").GetComponent<TextMeshProUGUI> ();
        Dice3 = GameObject.Find ("Dice3Text").GetComponent<TextMeshProUGUI> ();
        Dice4 = GameObject.Find ("Dice4Text").GetComponent<TextMeshProUGUI> ();

        RollDice();
    }

    void Update(){
        if (Input.GetKeyDown("space")){
            RollDice();    
        }

        if (Input.GetKeyDown("return")){
            ChooseNumber();
        }
    }

    void RollDice(){
        Debug.Log("rolled");
        // Rola o dado dentro de um valor especificado
        rollPlayerDice = Random.Range(0, 20);
        rollDice1 = Random.Range(0, 20);
        rollDice2 = Random.Range(0, 20);
        rollDice3 = Random.Range(0, 20);
        rollDice4 = Random.Range(0, 20);

        // Atribui o valor rolado ao campo de texto do objeto
        playerDice.text = rollPlayerDice.ToString();
        Dice1.text = rollDice1.ToString();
        Dice2.text = rollDice2.ToString();
        Dice3.text = rollDice3.ToString();
        Dice4.text = rollDice4.ToString();
    }

    void ChooseNumber(){
        if ((rollPlayerDice == rollDice1) || (rollPlayerDice == rollDice2) || (rollPlayerDice == rollDice3) || (rollPlayerDice == rollDice4)){
            Debug.Log("Ok");
            RollDice();
        }
        else{
            Debug.Log("Wrong");
        }
    }
}
