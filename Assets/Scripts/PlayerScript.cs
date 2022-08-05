using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject GameManager;
    [SerializeField] private TextMeshProUGUI RunnerLap;
    [SerializeField] private Image Dice1;
    [SerializeField] private Image Dice2;
    [SerializeField] private Image Dice3;
    [SerializeField] private Image Dice4;
    [SerializeField] private Image Dice5;
    [SerializeField] private Color MatchColor;
    [SerializeField] private Color NormalColor;
    private GameManagerScript GameManagerScript;
    private MoveRunners MoveRunners;
    private int rolledDice1;
    private int rolledDice2;
    private int rolledDice3;
    private int rolledDice4;
    private int rolledDice5;
    public int lapsPerformed;

    private void Start()
    {
        GameManagerScript = GameManager.GetComponent<GameManagerScript>();
        MoveRunners = this.GetComponent<MoveRunners>();
    }

    public IEnumerator RollDices()
    {
        Dice1.color = NormalColor;
        Dice2.color = NormalColor;
        Dice3.color = NormalColor;
        Dice4.color = NormalColor;
        Dice5.color = NormalColor;

        yield return new WaitForSeconds(1);

        rolledDice1 = Random.Range(1, 6);
        rolledDice2 = Random.Range(1, 6);
        rolledDice3 = Random.Range(1, 6);
        rolledDice4 = Random.Range(1, 6);
        rolledDice5 = Random.Range(1, 6);
    
        GameManagerScript.textDice1.text = rolledDice1.ToString();
        GameManagerScript.textDice2.text = rolledDice2.ToString();
        GameManagerScript.textDice3.text = rolledDice3.ToString();
        GameManagerScript.textDice4.text = rolledDice4.ToString();
        GameManagerScript.textDice5.text = rolledDice5.ToString();

        ChangeDiceColor();

        GameManagerScript.isRolling = false;
    }

    public IEnumerator PickDices()
    {
        if ((rolledDice1 == rolledDice2) || (rolledDice1 == rolledDice3) || (rolledDice1 == rolledDice4) || (rolledDice1 == rolledDice5))
        {
            MoveRunners.speed = 10;
            StartCoroutine(RollDices());
            yield return new WaitForSeconds(1);
            MoveRunners.speed = 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "EndLine")
        {
            lapsPerformed ++;
            RunnerLap.text = lapsPerformed.ToString();
        }
    }

    private void ChangeDiceColor()
    {
        if (rolledDice1 == rolledDice2){
            Dice1.color = MatchColor;
            Dice2.color = MatchColor;
        }
        if (rolledDice1 == rolledDice3){
            Dice1.color = MatchColor;
            Dice3.color = MatchColor;
        }
        if (rolledDice1 == rolledDice4){
            Dice1.color = MatchColor;
            Dice4.color = MatchColor;
        }
        if (rolledDice1 == rolledDice5){
            Dice1.color = MatchColor;
            Dice5.color = MatchColor;
        }
    }
}
