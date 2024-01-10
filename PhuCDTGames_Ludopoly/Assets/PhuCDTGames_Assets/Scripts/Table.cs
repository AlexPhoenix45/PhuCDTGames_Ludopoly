using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public UIManager _UIManager;
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
            Instance = this;
    }

    //Starting
    public void ChooseStartingPlayer()
    {
        IEnumerator chooseStarter()
        {
            int randomPlayer = Random.Range(0, numOfPlayers);
            float timeConsumed = 0;
            do
            {
                yield return new WaitForSeconds(.2f);
                SwitchPlayer(true);
                timeConsumed += .2f;
            }
            while (timeConsumed < 3f);
            SwitchPlayer(player[randomPlayer]);
        }
        StartCoroutine(chooseStarter());
    }

    //Roll
    public int[] RollDice()
    {
        int dice1, dice2;
        dice1 = Random.Range(1, 7);
        dice2 = Random.Range(1, 7);
        Move(getCurrentPlayer(), dice1 + dice2);
        return new int[] {dice1, dice2};
    }

    //Move
    private void Move(Player player, int distance)
    {
        player.Move(distance);
    }

    //Switch Player
    public void SwitchPlayer() //Switch to next player
    {
        if (currentPlayer == CurrentPlayer.player1)
        {
            currentPlayer = CurrentPlayer.player2;
            player[0].setIsMyTurn(false);
            player[1].setIsMyTurn(true);
            UIManager.Instance.setTurn(player[1].playerIndex, false);
        }
        else if (currentPlayer == CurrentPlayer.player2)
        {
            currentPlayer = CurrentPlayer.player3;
            player[1].setIsMyTurn(false);
            player[2].setIsMyTurn(true);
            UIManager.Instance.setTurn(player[2].playerIndex, false);
        }
        else if (currentPlayer == CurrentPlayer.player3)
        {
            currentPlayer = CurrentPlayer.player4;
            player[2].setIsMyTurn(false);
            player[3].setIsMyTurn(true);
            UIManager.Instance.setTurn(player[3].playerIndex, false);
        }
        else if (currentPlayer == CurrentPlayer.player4)
        {
            currentPlayer = CurrentPlayer.player1;
            player[3].setIsMyTurn(false);
            player[0].setIsMyTurn(true);
            UIManager.Instance.setTurn(player[0].playerIndex, false);
        }
    }
    public void SwitchPlayer(bool isSuffle) //Switch to next player
    {
        if (isSuffle)
        {
            if (currentPlayer == CurrentPlayer.player1)
            {
                currentPlayer = CurrentPlayer.player2;
                player[0].setIsMyTurn(false);
                player[1].setIsMyTurn(true);
                UIManager.Instance.setTurn(player[1].playerIndex, true);
            }
            else if (currentPlayer == CurrentPlayer.player2)
            {
                currentPlayer = CurrentPlayer.player3;
                player[1].setIsMyTurn(false);
                player[2].setIsMyTurn(true);
                UIManager.Instance.setTurn(player[2].playerIndex, true);
            }
            else if (currentPlayer == CurrentPlayer.player3)
            {
                currentPlayer = CurrentPlayer.player4;
                player[2].setIsMyTurn(false);
                player[3].setIsMyTurn(true);
                UIManager.Instance.setTurn(player[3].playerIndex, true);
            }
            else if (currentPlayer == CurrentPlayer.player4)
            {
                currentPlayer = CurrentPlayer.player1;
                player[3].setIsMyTurn(false);
                player[0].setIsMyTurn(true);
                UIManager.Instance.setTurn(player[0].playerIndex, true);
            }
        }
        else
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer(Player p) //Switch to specify player
    {
        if (p.playerIndex == 1)
        {
            currentPlayer = CurrentPlayer.player1;
            player[0].setIsMyTurn(true);
            player[1].setIsMyTurn(false);
            player[2].setIsMyTurn(false);
            player[3].setIsMyTurn(false);
        }
        else if (p.playerIndex == 2)
        {
            currentPlayer = CurrentPlayer.player2;
            player[0].setIsMyTurn(false);
            player[1].setIsMyTurn(true);
            player[2].setIsMyTurn(false);
            player[3].setIsMyTurn(false);
        }
        else if (p.playerIndex == 3)
        {
            currentPlayer = CurrentPlayer.player3;
            player[0].setIsMyTurn(false);
            player[1].setIsMyTurn(false);
            player[2].setIsMyTurn(true);
            player[3].setIsMyTurn(false);
        }
        else if (p.playerIndex == 4)
        {
            currentPlayer = CurrentPlayer.player4;
            player[0].setIsMyTurn(false);
            player[1].setIsMyTurn(false);
            player[2].setIsMyTurn(false);
            player[3].setIsMyTurn(true);
        }
        UIManager.Instance.setTurn(p.playerIndex, false);
    }

    //Get Current Player
    public Player getCurrentPlayer()
    {
        if (currentPlayer == CurrentPlayer.player1)
        {
            return player[0];
        }
        else if (currentPlayer == CurrentPlayer.player2)
        {
            return player[1];
        }
        else if (currentPlayer == CurrentPlayer.player3)
        {
            return player[2];
        }
        else if (currentPlayer == CurrentPlayer.player4)
        {
            return player[3];
        }
        else
        {
            return null;
        }
    }

    #region Property Information Card
    public void StandOnThisSlot(int slotNumber)
    {
        if (!slot[slotNumber].GetComponent<Slot>().getIsOwned()) //If that slot didnt have an owner
        {
            //Call Property Information Card
            _UIManager.ShowInformationCard(slotNumber);
        }
    }

    public void Buy()
    {
        slot[getCurrentPlayer().currentSlot].GetComponent<Slot>().setOwner(getCurrentPlayer());
        _UIManager.HideInformationCard();
    }

    public void Auction()
    {

    }
    #endregion
}

public enum CurrentPlayer
{
    player1,
    player2,
    player3,
    player4,
}
