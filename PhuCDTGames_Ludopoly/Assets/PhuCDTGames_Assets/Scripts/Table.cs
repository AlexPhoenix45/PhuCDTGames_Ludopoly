using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public static Table Instance;
    public GameObject[] slot;
    public Player[] player;

    [Header("Game Parameters")]
    public short numOfPlayers;

    //[HideInInspector]
    public CurrentPlayer currentPlayer;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        ChooseStartingPlayer();
    }

    //Starting
    public void ChooseStartingPlayer()
    {
        int randomPlayer = Random.Range(0, numOfPlayers);
        if (randomPlayer == 0)
        {
            currentPlayer = CurrentPlayer.player1;
        }
        else if (randomPlayer == 1)
        {
            currentPlayer = CurrentPlayer.player2;
        }
        else if (randomPlayer == 2)
        {
            currentPlayer = CurrentPlayer.player3;
        }
        else
        {
            currentPlayer = CurrentPlayer.player4;
        }
    }

    //Player's turn



    //Roll
    public int[] RollDice()
    {
        int dice1, dice2;
        dice1 = Random.Range(1, 7);
        dice2 = Random.Range(1, 7);

        return new int[] {dice1, dice2};
    }

    private void Move()
    {

    }

    //Move

    //Choices
    
    //Others Methods
    public void SwitchPlayer() //Switch to next player
    {
        if (currentPlayer == CurrentPlayer.player1)
        {
            currentPlayer = CurrentPlayer.player2;
        }
        else if (currentPlayer == CurrentPlayer.player2)
        {
            currentPlayer = CurrentPlayer.player3;
        }
        else if (currentPlayer == CurrentPlayer.player3)
        {
            currentPlayer = CurrentPlayer.player4;
        }
        else if (currentPlayer == CurrentPlayer.player4)
        {
            currentPlayer = CurrentPlayer.player1;
        }
    }

    public void SwitchPlayer(Player player) //Switch to specify player
    {
        if (player.playerIndex == 1)
        {
            currentPlayer = CurrentPlayer.player1;
        }
        else if (player.playerIndex == 2)
        {
            currentPlayer = CurrentPlayer.player2;
        }
        else if (player.playerIndex == 3)
        {
            currentPlayer = CurrentPlayer.player3;   
        }
        else if (player.playerIndex == 4)
        {
            currentPlayer = CurrentPlayer.player4;
        }
    }
    public string getPlayerName(int index)
    {
        return player[index].playerName;
    }
}

public enum CurrentPlayer
{
    player1,
    player2,
    player3,
    player4,
}
