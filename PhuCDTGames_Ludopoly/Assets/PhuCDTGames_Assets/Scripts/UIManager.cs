using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Singleton
    public static UIManager Instance;

    [Header("Choice")]
    public Button build;
    public Button sell;
    public Button mortgage;
    public Button redeem;
    public Button trade;

    [Header("Dice")]
    public Button rollDice;
    public TextMeshProUGUI diceNumber;

    [Header("Player 1")]
    [Header("Players")]
    public GameObject player1Panel;
    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player1Money;
    public Image player1Image;

    [Header("Player 2")]
    public GameObject player2Panel;
    public TextMeshProUGUI player2Name;
    public TextMeshProUGUI player2Money;
    public Image player2Image;

    [Header("Player 3")]
    public GameObject player3Panel;
    public TextMeshProUGUI player3Name;
    public TextMeshProUGUI player3Money;
    public Image player3Image;

    [Header("Player 4")]
    public GameObject player4Panel;
    public TextMeshProUGUI player4Name;
    public TextMeshProUGUI player4Money;
    public Image player4Image;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        //setPlayerInfo();
    }

    //Dice
    public void OnClick_RollDice()
    {
        int[] dices = new int [2];
        dices = Table.Instance.RollDice();
        setDiceNumber(dices);
    }

    public void setDiceNumber(int[] dices)
    {
        diceNumber.text = dices[0].ToString() + " + " + dices[1].ToString();
    }

    //Player
    public void setPlayerInfo()
    {
        Player demoPlayer = Table.Instance.player[0];

        player1Name.text = demoPlayer.playerName;
    }
}
