using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    int test_dice1, test_dice2;
    [SerializeField]
    bool opentest = false;

    //Roll
    //
    public int[] RollDice() //The return just for UI
    {
        int dice1, dice2;
        dice1 = Random.Range(1, 7);
        dice2 = Random.Range(1, 7);

        if (opentest)
        {
            dice1 = test_dice1;
            dice2 = test_dice2;
        }

        getCurrentPlayer().currentDices = dice1 + dice2;

        _UIManager.DicesActive(false);

        if (!getCurrentPlayer().rollForJail)
        {
            if (dice1 == dice2)
            {
                if (getCurrentPlayer().timesGetDoubles != 2)
                {
                    getCurrentPlayer().Move(dice2 + dice1, false);
                }
                getCurrentPlayer().setTimesGetDoubles(true, false);
            }
            else
            {
                getCurrentPlayer().setTimesGetDoubles(false, false);
                getCurrentPlayer().Move(dice1 + dice2, false);
            }
        }
        else
        {
            if (dice1 == dice2)
            {
                getCurrentPlayer().setTimesGetDoubles(true, true);

                if (!getCurrentPlayer().isInJail)
                {
                    getCurrentPlayer().Move(dice1 + dice2, false);
                }
            }
            else
            {
                getCurrentPlayer().setTimesGetDoubles(false, true);

                if (!getCurrentPlayer().isInJail)
                {
                    getCurrentPlayer().Move(dice1 + dice2, false);
                }
            }
            getCurrentPlayer().rollForJail = false;
        }

        return new int[] { dice1, dice2 };
    }

    //Get Slot script
    //

    public Slot getSlot(int slotNumber)
    {
        return slot[slotNumber].GetComponent<Slot>();
    }

    #region Player Switching and Getter
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

    public Player[] getRemainingPlayer()
    {
        if (getCurrentPlayer() == player[0])
        {
            return new Player[] { player[1], player[2], player[3] };
        }
        else if (getCurrentPlayer() == player[1])
        {
            return new Player[] { player[0], player[2], player[3] };
        }
        else if (getCurrentPlayer() == player[2])
        {
            return new Player[] { player[0], player[1], player[3] };
        }
        else if (getCurrentPlayer() == player[3])
        {
            return new Player[] { player[0], player[1], player[2] };
        }
        else
        {
            return null;
        }
    }

    #endregion

    #region Property Information Card Action And Show
    public void StandOnThisSlot(int slotNumber)
    {
        if (!getSlot(slotNumber).isOwned) //If that slot didnt have an owner
        {
            //Call Property Information Card
            _UIManager.ShowInformationCard(slotNumber);

            if (getSlot(slotNumber).slotType == Slot_Type.SupriseSlot) //Suprise slot
            {
                if (getSlot(slotNumber).supriseSlot.slotType == SupriseSlot_Type.Chance)
                {
                    ChanceCards chanceCardsType = getSlot(slotNumber).supriseSlot.chanceCards;
                    getCurrentPlayer().hasSecondTurn = false; //no second turn after executing cards
                    //Process Chance Card in here

                    switch (chanceCardsType)
                    {
                        case ChanceCards.AdvanceToBoardwalk:
                            getCurrentPlayer().setLateMove(39, true);
                            _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                            break;
                        case ChanceCards.AdvanceToGo:
                            getCurrentPlayer().setLateMove(0, true);
                            _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                            break;
                        case ChanceCards.AdvanceToIllinois:
                            getCurrentPlayer().setLateMove(24, true);
                            _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                            break;
                        case ChanceCards.AdvanceToStCharles:
                            getCurrentPlayer().setLateMove(11, true);
                            _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                            break;
                        case ChanceCards.AdvanceToRailroad1:
                            if (getCurrentPlayer().currentSlot == 7)
                            {
                                getCurrentPlayer().setLateMove(15, true);
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else if (getCurrentPlayer().currentSlot == 22)
                            {
                                getCurrentPlayer().setLateMove(25, true);
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else if (getCurrentPlayer().currentSlot == 36)
                            {
                                getCurrentPlayer().setLateMove(5, true);
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case ChanceCards.AdvanceToRailroad2:
                            if (getCurrentPlayer().currentSlot == 7)
                            {
                                getCurrentPlayer().setLateMove(15, true);
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else if (getCurrentPlayer().currentSlot == 22)
                            {
                                getCurrentPlayer().setLateMove(25, true);
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else if (getCurrentPlayer().currentSlot == 36)
                            {
                                getCurrentPlayer().setLateMove(5, true);
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case ChanceCards.AdvanceToUtility:
                            if (getCurrentPlayer().currentSlot == 7)
                            {
                                getCurrentPlayer().setLateMove(12, true);
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else if (getCurrentPlayer().currentSlot == 22)
                            {
                                getCurrentPlayer().setLateMove(28, true);
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else if (getCurrentPlayer().currentSlot == 36)
                            {
                                getCurrentPlayer().setLateMove(28, false);
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case ChanceCards.Earn50:
                            print(getCurrentPlayer() + " collects 50$");
                            CurrentPlayerReceiveBank(50);
                            break;
                        case ChanceCards.JailFree:
                            print(getCurrentPlayer() + " Get Out of Jail Free Card");
                            getCurrentPlayer().AddJailFreeCard();
                            break;
                        case ChanceCards.Back3:
                            if (getCurrentPlayer().currentSlot == 7)
                            {
                                getCurrentPlayer().setLateMove(7 - 3, false);
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else if (getCurrentPlayer().currentSlot == 22)
                            {
                                getCurrentPlayer().setLateMove(22 - 3, false);
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else if (getCurrentPlayer().currentSlot == 36)
                            {
                                getCurrentPlayer().setLateMove(36 - 3, false);
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case ChanceCards.GoToJail:
                            if (getCurrentPlayer().currentSlot == 7)
                            {
                                getCurrentPlayer().setLateMove(10, true);
                                getCurrentPlayer().isInJail = true;
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else if (getCurrentPlayer().currentSlot == 22)
                            {
                                getCurrentPlayer().setLateMove(10, false);
                                getCurrentPlayer().isInJail = true;
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else if (getCurrentPlayer().currentSlot == 36)
                            {
                                getCurrentPlayer().setLateMove(10, false);
                                getCurrentPlayer().isInJail = true;
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
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
                            CurrentPlayerPayBank(15);
                            break;
                        case ChanceCards.ReadingRailroad:
                            getCurrentPlayer().setLateMove(5, true);
                            _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                            break;
                        case ChanceCards.Chairman:
                            print(getCurrentPlayer() + " Pays each player 50$");
                            CurrentPlayerPayFor(getRemainingPlayer(), 50);
                            break;
                        case ChanceCards.Earn150:
                            print(getCurrentPlayer() + " Collect 150$");
                            CurrentPlayerReceiveBank(150);
                            break;
                    }
                }
                else if (getSlot(slotNumber).supriseSlot.slotType == SupriseSlot_Type.CommunityChest)
                {
                    //Process Community Chest Card in here
                    CommunityChestCards communityChestCardsType = getSlot(slotNumber).supriseSlot.communityChestCards;
                    getCurrentPlayer().hasSecondTurn = false; //no second turn after executing cards

                    switch (communityChestCardsType)
                    {
                        case CommunityChestCards.AdvanceToGo:
                            getCurrentPlayer().setLateMove(0, true);
                            _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                            break;
                        case CommunityChestCards.BankError:
                            print(getCurrentPlayer().ToString() + " Collect 200$");
                            CurrentPlayerReceiveBank(200);
                            break;
                        case CommunityChestCards.Doctor:
                            print(getCurrentPlayer().ToString() + " Pays 50$");
                            CurrentPlayerPayBank(50);
                            break;
                        case CommunityChestCards.Stock:
                            print(getCurrentPlayer().ToString() + " Collect 50$");
                            CurrentPlayerReceiveBank(50);
                            break;
                        case CommunityChestCards.JailFree:
                            print(getCurrentPlayer().ToString() + " Get Out of Jaili Free Card");
                            getCurrentPlayer().AddJailFreeCard();
                            break;
                        case CommunityChestCards.GoToJail:
                            if (getCurrentPlayer().currentSlot == 2)
                            {
                                getCurrentPlayer().setLateMove(10, true);
                                getCurrentPlayer().isInJail = true;
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else if (getCurrentPlayer().currentSlot == 17)
                            {
                                getCurrentPlayer().setLateMove(10, false);
                                getCurrentPlayer().isInJail = true;
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else if (getCurrentPlayer().currentSlot == 33)
                            {
                                getCurrentPlayer().setLateMove(10, false);
                                getCurrentPlayer().isInJail = true;
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                            else
                            {
                                _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                break;
                            }
                        case CommunityChestCards.Holiday:
                            print(getCurrentPlayer().ToString() + " Collect 100$");
                            CurrentPlayerReceiveBank(100);
                            break;
                        case CommunityChestCards.Income:
                            print(getCurrentPlayer().ToString() + " Collect 20$");
                            CurrentPlayerReceiveBank(20);
                            break;
                        case CommunityChestCards.Birthday:
                            print(getCurrentPlayer().ToString() + " Collect 10$ from each player");
                            CurrentPlayerReceiveFrom(getRemainingPlayer(), 10);
                            break;
                        case CommunityChestCards.Insurance:
                            print(getCurrentPlayer().ToString() + " Collect 100$");
                            CurrentPlayerReceiveBank(100);
                            break;
                        case CommunityChestCards.Hospital:
                            print(getCurrentPlayer().ToString() + " Pays 100$"); 
                            CurrentPlayerPayBank(100);
                            break;
                        case CommunityChestCards.School:
                            print(getCurrentPlayer().ToString() + " Pays 50$");
                            CurrentPlayerPayBank(50);
                            break;
                        case CommunityChestCards.Consultancy:
                            print(getCurrentPlayer().ToString() + " Collect 25$");
                            CurrentPlayerReceiveBank(25);
                            break;
                        case CommunityChestCards.StreetRepair:
                            print(getCurrentPlayer().ToString() + " Pay 40$ per house, 115$ per hotel"); break;
                        case CommunityChestCards.Beauty:
                            print(getCurrentPlayer().ToString() + " Collect 10$");
                            CurrentPlayerReceiveBank(10);
                            break;
                        case CommunityChestCards.Inherit:
                            print(getCurrentPlayer().ToString() + " Collect 100$");
                            CurrentPlayerReceiveBank(100);
                            break;
                    }
                }
                else if (getSlot(slotNumber).supriseSlot.slotType == SupriseSlot_Type.Tax)
                {
                    //Process Tax Card in here
                    print("Paid " + getSlot(slotNumber).supriseSlot.taxPrice);
                    CurrentPlayerPayBank(getSlot(slotNumber).supriseSlot.taxPrice);
                }
            }
        }
        else //has to paid slot
        {
            if ((getSlot(slotNumber).slotType == Slot_Type.ColorProperty || getSlot(slotNumber).slotType == Slot_Type.SpecialProperty) && getSlot(slotNumber).getOwner() != getCurrentPlayer())
            {
                print("Player " + getCurrentPlayer().playerName + " has to pay" + getSlot(slotNumber).getOwner().playerName + " amount of " + getSlot(slotNumber).getPropertyRent() + "$");
                CurrentPlayerPayFor(getSlot(slotNumber).getOwner(), getSlot(slotNumber).getPropertyRent());
                _UIManager.ShowRentPaidUI(getCurrentPlayer(), getSlot(slotNumber).getOwner(), getSlot(slotNumber).getPropertyRent());
            }
        }
    }

    public void Buy()
    {
        slot[getCurrentPlayer().currentSlot].GetComponent<Slot>().setOwner(getCurrentPlayer()); //set owner to slot
        CurrentPlayerPayBank(slot[getCurrentPlayer().currentSlot].GetComponent<Slot>().getSlotPrice()); //pay bank

        if (getSlot(getCurrentPlayer().currentSlot).slotType == Slot_Type.SpecialProperty)
        {
            if (getSlot(getCurrentPlayer().currentSlot).specialProperty.propertyType == SpecialProperty_Type.RailRoad)
            {
                getCurrentPlayer().railroadOwned++;
            }
            else if (getSlot(getCurrentPlayer().currentSlot).specialProperty.propertyType == SpecialProperty_Type.Utility)
            {
                getCurrentPlayer().utilityOwned++;
            }
        }

        _UIManager.HideInformationCard();
    }

    public void Auction()
    {

    }

    public void JailPay()
    {
        print(getCurrentPlayer().ToString() + " Pays 100$ to get out of Jail!");
        CurrentPlayerPayBank(100);
        getCurrentPlayer().JailPay();
    }

    public void JailUseCard()
    {
        print(getCurrentPlayer().ToString() + " Use card to get out of Jail!");
        getCurrentPlayer().JailUseCard();
    }

    public void JailRollDouble()
    {
        _UIManager.HideInformationCard();
        getCurrentPlayer().rollForJail = true;
    }

    public void Build()
    {

    }

    public void Sell()
    {

    }

    public void Mortgage()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (getSlot(i).isOwned)
            {
                if (getSlot(i).getOwner() == getCurrentPlayer())
                {

                }
                else
                {
                    slot[i].GetComponent<SpriteRenderer>().color = new Vector4(0, 0, 0, .3f);
                }
            }
            else
            {
                slot[i].GetComponent<SpriteRenderer>().color = new Vector4(0, 0, 0, .3f);
            }
        }
    }
    
    public void Redeem()
    {

    }

    #endregion

    //After player's move
    //
    public void AfterPlayerMove(Player player)
    {
        if (getCurrentPlayer().isInJail) //in jail: dice off, options on, endturn on
        {
            print("in jail: dice off, options on, endturn on");
            _UIManager.DicesActive(false);
            _UIManager.DicesFacesActive();

            _UIManager.OptionsActive(true);
            _UIManager.EndTurnActive(true);

            StandOnThisSlot(player.currentSlot);
        }
        else if (!getCurrentPlayer().isInJail)
        {
            if (getCurrentPlayer().hasSecondTurn) //second turn on: dice on, options on, endturn off
            {
                print("second turn on: dice on, options on, endturn off");
                _UIManager.DicesActive(true);
                _UIManager.DicesFacesActive();

                _UIManager.OptionsActive(true);
                _UIManager.EndTurnActive(false);

                StandOnThisSlot(player.currentSlot);
            }
            else if (!getCurrentPlayer().hasSecondTurn) //second turn off: dice off, options on, endturn on
            {
                print("second turn off: dice off, options on, endturn on");
                _UIManager.DicesActive(false);
                _UIManager.DicesFacesActive();

                _UIManager.OptionsActive(true);
                _UIManager.EndTurnActive(true);

                StandOnThisSlot(player.currentSlot); 
            }
        }
    }

    #region Money
    public void CurrentPlayerPayFor(Player player, int amount)
    {
        getCurrentPlayer().PayMoney(amount);
        player.ReceiveMoney(amount);
        _UIManager.MoneyUpdate();
    }

    public void CurrentPlayerPayFor(Player[] player, int amountEach)
    {
        foreach (Player playerItem in player)
        {
            playerItem.ReceiveMoney(amountEach);
            getCurrentPlayer().PayMoney(amountEach);
        }
        _UIManager.MoneyUpdate();
    }

    public void CurrentPlayerReceiveFrom(Player player, int amount)
    {
        getCurrentPlayer().ReceiveMoney(amount);
        player.PayMoney(amount);
        _UIManager.MoneyUpdate();
    }

    public void CurrentPlayerReceiveFrom(Player[] player, int amountEach)
    {
        foreach (Player playerItem in player)
        {
            playerItem.PayMoney(amountEach);
            getCurrentPlayer().ReceiveMoney(amountEach);
        }
        _UIManager.MoneyUpdate();
    }

    public void CurrentPlayerPayBank(int amount)
    {
        getCurrentPlayer().PayMoney(amount);
        //_UIManager.MoneyUpdate();
    }

    public void CurrentPlayerReceiveBank(int amount)
    {
        getCurrentPlayer().ReceiveMoney(amount);
        //_UIManager.MoneyUpdate();
    }

    public void CurrentPlayerInstantPayBank(int amount)
    {
        getCurrentPlayer().PayMoney(amount);
        _UIManager.MoneyUpdate();
    }
    public void CurrentPlayerInstantReceiveBank(int amount)
    {
        getCurrentPlayer().ReceiveMoney(amount);
        _UIManager.MoneyUpdate();
    }

    #endregion
}
