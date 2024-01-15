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
    public int[] RollDice() //The return just for UI
    {
        int dice1, dice2;
        dice1 = Random.Range(1, 7);
        dice2 = Random.Range(1, 7);

        dice1 = dice2 = 1;

        _UIManager.DicesActive(false);

        if (dice1 == dice2)
        {
            if (getCurrentPlayer().timesGetDoubles != 2)
            { 
                getCurrentPlayer().Move(dice2 + dice1, false);
            }
            getCurrentPlayer().setTimesGetDoubles(true);
        }
        else
        {
            getCurrentPlayer().setTimesGetDoubles(false);
            getCurrentPlayer().Move(dice1 + dice2, false);
        }
        return new int[] { dice1, dice2 };
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

    #region Property Information Card Action And Show
    public void StandOnThisSlot(int slotNumber)
    {
        if (!slot[slotNumber].GetComponent<Slot>().getIsOwned()) //If that slot didnt have an owner
        {
            //Call Property Information Card
            _UIManager.ShowInformationCard(slotNumber);

            if (slot[slotNumber].GetComponent<Slot>().slotType == Slot_Type.SupriseSlot)
            {
                if (slot[slotNumber].GetComponent<Slot>().supriseSlot.slotType == SupriseSlot_Type.Chance)
                {
                    ChanceCards chanceCardsType = slot[slotNumber].GetComponent<Slot>().supriseSlot.chanceCards;
                    //Process Chance Card in here

                    switch (chanceCardsType)
                    {
                        case ChanceCards.AdvanceToBoardwalk:
                            getCurrentPlayer().setLateMove(39, true); break;
                        case ChanceCards.AdvanceToGo:
                            getCurrentPlayer().setLateMove(0, true); break;
                        case ChanceCards.AdvanceToIllinois:
                            getCurrentPlayer().setLateMove(24, true); break;
                        case ChanceCards.AdvanceToStCharles:
                            getCurrentPlayer().setLateMove(11, true); break;
                        case ChanceCards.AdvanceToRailroad1:
                            if (getCurrentPlayer().currentSlot == 7)
                            {
                                getCurrentPlayer().setLateMove(15, true); break;
                            }
                            else if (getCurrentPlayer().currentSlot == 22)
                            {
                                getCurrentPlayer().setLateMove(25, true); break;
                            }
                            else if (getCurrentPlayer().currentSlot == 36)
                            {
                                getCurrentPlayer().setLateMove(5, true); break;
                            }
                            else
                            {
                                break;
                            }
                        case ChanceCards.AdvanceToRailroad2:
                            if (getCurrentPlayer().currentSlot == 7)
                            {
                                getCurrentPlayer().setLateMove(15, true); break;
                            }
                            else if (getCurrentPlayer().currentSlot == 22)
                            {
                                getCurrentPlayer().setLateMove(25, true); break;
                            }
                            else if (getCurrentPlayer().currentSlot == 36)
                            {
                                getCurrentPlayer().setLateMove(5, true); break;
                            }
                            else
                            {
                                break;
                            }
                        case ChanceCards.AdvanceToUtility:
                            if (getCurrentPlayer().currentSlot == 7)
                            {
                                getCurrentPlayer().setLateMove(12, true); break;
                            }
                            else if (getCurrentPlayer().currentSlot == 22)
                            {
                                getCurrentPlayer().setLateMove(28, true); break;
                            }
                            else if (getCurrentPlayer().currentSlot == 36)
                            {
                                getCurrentPlayer().setLateMove(28, false); break;
                            }
                            else
                            {
                                break;
                            }
                        case ChanceCards.Earn50:
                            print(getCurrentPlayer() + " collects 50$");
                            break;
                        case ChanceCards.JailFree:
                            print(getCurrentPlayer() + " Get Out of Jail Free Card");
                            break;
                        case ChanceCards.Back3:
                            if (getCurrentPlayer().currentSlot == 7)
                            {
                                getCurrentPlayer().setLateMove(7 - 3, false); break;
                            }
                            else if (getCurrentPlayer().currentSlot == 22)
                            {
                                getCurrentPlayer().setLateMove(22 - 3, false); break;
                            }
                            else if (getCurrentPlayer().currentSlot == 36)
                            {
                                getCurrentPlayer().setLateMove(36 - 3, false); break;
                            }
                            else
                            {
                                break;
                            }
                        case ChanceCards.GoToJail:
                            if (getCurrentPlayer().currentSlot == 7)
                            {
                                getCurrentPlayer().setLateMove(10, true); break;
                            }
                            else if (getCurrentPlayer().currentSlot == 22)
                            {
                                getCurrentPlayer().setLateMove(10, false); break;
                            }
                            else if (getCurrentPlayer().currentSlot == 36)
                            {
                                getCurrentPlayer().setLateMove(10, false); break;
                            }
                            else
                            {
                                break;
                            }
                        case ChanceCards.Repair:
                            print("not yet");
                            break;
                        case ChanceCards.Speeding:
                            print(getCurrentPlayer() + " Pays 15$");
                            break;
                        case ChanceCards.ReadingRailroad:
                            getCurrentPlayer().setLateMove(5, true);
                            break;
                        case ChanceCards.Chairman:
                            print(getCurrentPlayer() + " Pays each player 50$");
                            break;
                        case ChanceCards.Earn150:
                            print(getCurrentPlayer() + " Collect 150$");
                            break;
                    }
                }
                else if (slot[slotNumber].GetComponent<Slot>().supriseSlot.slotType == SupriseSlot_Type.CommunityChest)
                {
                    //Process Community Chest Card in here
                    CommunityChestCards communityChestCardsType = slot[slotNumber].GetComponent<Slot>().supriseSlot.communityChestCards;

                    switch (communityChestCardsType) 
                    {
                        case CommunityChestCards.AdvanceToGo:
                            getCurrentPlayer().setLateMove(0, true); break;
                        case CommunityChestCards.BankError:
                            print(getCurrentPlayer().ToString() + " Collect 200$"); break;
                        case CommunityChestCards.Doctor:
                            print(getCurrentPlayer().ToString() + " Pays 50$"); break;
                        case CommunityChestCards.Stock:
                            print(getCurrentPlayer().ToString() + " Collect 50$"); break;
                        case CommunityChestCards.JailFree:
                            print(getCurrentPlayer().ToString() + " Get Out of Jaili Free Card"); break;
                        case CommunityChestCards.GoToJail:
                            getCurrentPlayer().setLateMove(10, true); break;
                        case CommunityChestCards.Holiday:
                            print(getCurrentPlayer().ToString() + " Collect 100"); break;
                        case CommunityChestCards.Income:
                            print(getCurrentPlayer().ToString() + " Collect 20$"); break;
                        case CommunityChestCards.Birthday:
                            print(getCurrentPlayer().ToString() + " Collect 10$ from each player"); break;
                        case CommunityChestCards.Insurance:
                            print(getCurrentPlayer().ToString() + " Collect 100$"); break;
                        case CommunityChestCards.Hospital:
                            print(getCurrentPlayer().ToString() + " Pays 100$"); break;
                        case CommunityChestCards.School:
                            print(getCurrentPlayer().ToString() + " Pays 50$"); break;
                        case CommunityChestCards.Consultancy:
                            print(getCurrentPlayer().ToString() + " Collect 25$"); break;
                        case CommunityChestCards.StreetRepair:
                            print(getCurrentPlayer().ToString() + " Pay 40$ per house, 115$ per hotel"); break;
                        case CommunityChestCards.Beauty:
                            print(getCurrentPlayer().ToString() + " Collect 10$"); break;
                        case CommunityChestCards.Inherit:
                            print(getCurrentPlayer().ToString() + " Collect 100$"); break;
                    }
                }
                else if (slot[slotNumber].GetComponent<Slot>().supriseSlot.slotType == SupriseSlot_Type.Tax)
                {
                    //Process Tax Card in here
                }
            }
        }
        else
        {
            if (slot[slotNumber].GetComponent<Slot>().slotType == Slot_Type.ColorProperty || slot[slotNumber].GetComponent<Slot>().slotType == Slot_Type.SpecialProperty)
            {
                print("Player " + getCurrentPlayer().playerName + " has to pay" + slot[slotNumber].GetComponent<Slot>().getOwner().playerName + " amount of " + slot[slotNumber].GetComponent<Slot>().getPropertyRent(slot[slotNumber].GetComponent<Slot>().slotType) + "$");
            }
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

    public void JailPay()
    {
        print(getCurrentPlayer().ToString() + " Pays 100$ to get out of Jail!");

    }

    public void JailUseCard()
    {
        print(getCurrentPlayer().ToString() + " Use card to get out of Jail!");

    }

    public void JailRollDouble()
    {
        _UIManager.HideInformationCard();
        getCurrentPlayer().rollForJail = true;
    }
    #endregion

    //After player's move
    //
    public void AfterPlayerMove(Player player)
    {
        if (getCurrentPlayer().isInJail)
        {
            _UIManager.DicesActive(false);
        }

        if (getCurrentPlayer().timesGetDoubles > 0)
        {
            _UIManager.DicesActive(true);
        }
        UIManager.Instance.DicesFacesActive();
        UIManager.Instance.OptionsActive(true);
        if (player.timesGetDoubles != 0)
        {
            UIManager.Instance.EndTurnActive(false);
        }
        else
        {
            UIManager.Instance.EndTurnActive(true);
        }
        StandOnThisSlot(player.currentSlot);
    }
}

public enum CurrentPlayer
{
    player1,
    player2,
    player3,
    player4,
}
