using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlayerScript : MonoBehaviour
{
    private int rolledDicePlayer;
    private int rolledDice1;
    private int rolledDice2;
    private int rolledDice3;
    private int rolledDice4;

    public IEnumerator RollPlayerDice()
    {
        Debug.Log("Clicked");
        yield return new WaitForSeconds(1);

        rolledDicePlayer = Random.Range(1, 20);
        rolledDice1 = Random.Range(1, 20);
        rolledDice2 = Random.Range(1, 20);
        rolledDice3 = Random.Range(1, 20);
        rolledDice4 = Random.Range(1, 20);
    
        GameManager.Instance.textDicePlayer.text = rolledDicePlayer.ToString();
        GameManager.Instance.textDice1.text = rolledDice1.ToString();
        GameManager.Instance.textDice2.text = rolledDice2.ToString();
        GameManager.Instance.textDice3.text = rolledDice3.ToString();
        GameManager.Instance.textDice4.text = rolledDice4.ToString();

        GameManager.Instance.isRolling = false;
        Debug.Log("Rolled");
    }

    public IEnumerator ChooseNumber()
    {
        if ((rolledDicePlayer == rolledDice1) || (rolledDicePlayer == rolledDice2) || (rolledDicePlayer == rolledDice3) || (rolledDicePlayer == rolledDice4))
        {
            GameManager.Instance.moveRunnersPlayer.speed = 10;
            StartCoroutine(RollPlayerDice());
            yield return new WaitForSeconds(1);
            GameManager.Instance.moveRunnersPlayer.speed = 5;
        }
    }
}
