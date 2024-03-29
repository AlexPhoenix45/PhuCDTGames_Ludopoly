using JetBrains.Annotations;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace GameAdd_Ludopoly
{
    public class Table : MonoBehaviour
    {
        public UIManager _UIManager;
        public static Table Instance;
        [HideInInspector]
        public GameObject[] slot;
        [HideInInspector]
        public Player[] player;

        [Header("Game Parameters")]
        public short numOfPlayers;

        [HideInInspector]
        public CurrentPlayer currentPlayer;

        //Auction Parameter
        //

        [HideInInspector]
        public int auc_currentPrice;
        Player auc_currentPlayer;
        Player auc_startingPlayer;
        [HideInInspector]
        public Player auc_playerWithHighestBid;
        int auc_playerInAuction;
        [HideInInspector]
        public int auc_slotNumber;

        //Pawns
        //
        [HideInInspector]
        public GameObject p1Pawn;
        [HideInInspector]
        public GameObject p2Pawn;
        [HideInInspector]
        public GameObject p3Pawn;
        [HideInInspector]
        public GameObject p4Pawn;

        [Header("Dice Tester")]
        public int test_dice1;
        public int test_dice2;
        public bool dice_openTest = false;

        [HideInInspector]
        public int remainingPlayer;
        public int RemainingPlayer
        {
            get { return remainingPlayer; }
            set 
            { 
                remainingPlayer = value; 
                if (remainingPlayer == 1)
                {
                    _UIManager.ShowScoreboard();
                }
            }
        }
    

        [HideInInspector]
        public int playerRank = 4;

        [Tooltip("Check this if you want to see which button was clicked")]
        public bool buttonToLog = true;

        private void Start()
        {
            if (Instance == null)
                Instance = this;
            SetPawn();
            SetPlayerOnSlot(0);
            remainingPlayer = numOfPlayers;
            playerRank = numOfPlayers;
        }

        //Starting
        //
        public void SetPawn()
        {
            if (numOfPlayers == 2)
            {
                p1Pawn.SetActive(true);
                p2Pawn.SetActive(true);
                p3Pawn.SetActive(false);
                p4Pawn.SetActive(false);
            }
            else if (numOfPlayers == 3)
            {
                p1Pawn.SetActive(true);
                p2Pawn.SetActive(true);
                p3Pawn.SetActive(true);
                p4Pawn.SetActive(false);
            }
            else if (numOfPlayers == 4)
            {
                p1Pawn.SetActive(true);
                p2Pawn.SetActive(true);
                p3Pawn.SetActive(true);
                p4Pawn.SetActive(true);
            }
        }

        public void ChooseStartingPlayer()
        {
            IEnumerator chooseStarter()
            {
                int randomPlayer = Random.Range(0, numOfPlayers);
                float timeConsumed = 0;
                do
                {
                    yield return new WaitForSeconds(.1f);
                    SwitchPlayer(true);
                    timeConsumed += .1f;
                }
                while (timeConsumed < 1.5f);
                SwitchPlayer(player[randomPlayer]);
                yield return new WaitForSeconds(1f);
                if (player[randomPlayer].isBotPlaying)
                {
                    _UIManager._LiveUpdate.OptionsUpdate();
                }
            }
            StartCoroutine(chooseStarter());
        }

        //Roll
        //
        public int[] RollDice() //The return just for UI
        {
            int dice1, dice2;
            dice1 = Random.Range(1, 7);
            dice2 = Random.Range(1, 7);

            if (dice_openTest)
            {
                dice1 = test_dice1;
                dice2 = test_dice2;
            }

            getCurrentPlayer().currentDices = dice1 + dice2; //get dice number

            _UIManager.DicesActive(false); //turn off dice when rolling

            for (int i = 0; i < slot.Length; i++) //Not allow to view slot information when click
            {
                getSlot(i).slotAction = SlotAction.None;
            }

            if (!getCurrentPlayer().rollForJail && !getCurrentPlayer().isRolltoPay) //if this roll is not for jail nor to pay. then do the move and animation
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
                if (getCurrentPlayer().rollForJail) //if this is roll for jail
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
                        LiveUpdate.Instance.CallBot();
                        if (!getCurrentPlayer().isInJail)
                        {
                            getCurrentPlayer().Move(dice1 + dice2, false);
                        }
                    }
                    getCurrentPlayer().rollForJail = false;
                }
                else if (getCurrentPlayer().isRolltoPay)
                {
                    CurrentPlayerPayFor(getSlot(getCurrentPlayer().currentSlot).owner, (dice1 + dice2) * 10);
                    _UIManager.ShowRentPaidUI(getCurrentPlayer(), getSlot(getCurrentPlayer().currentSlot).owner, (dice1 + dice2) * 10);
                    getCurrentPlayer().isRolltoPay = false;
                    getCurrentPlayer().exeUtilities = false;
                    _UIManager.EndTurnActive(true);
                    _UIManager.DicesActive(false);
                    _UIManager.DicesFacesActive();
                }
            }

            return new int[] { dice1, dice2 };
        }

        //Get Slot script
        //

        public Slot getSlot(int slotNumber)
        {
            //print(slotNumber);
            return slot[slotNumber].GetComponent<Slot>();
        }

        #region Player Switching and Getter
        public void SwitchPlayer() //Switch to next player
        {
            if (numOfPlayers == 2)
            {
                if (currentPlayer == CurrentPlayer.player1)
                {
                    currentPlayer = CurrentPlayer.player2;
                    player[0].setIsMyTurn(false);
                    player[1].setIsMyTurn(true);
                    _UIManager.setTurn(player[1].playerIndex, false);

                    if (player[1].isBankrupt)
                    {
                        SwitchPlayer();
                    }
                }
                else if (currentPlayer == CurrentPlayer.player2)
                {
                    currentPlayer = CurrentPlayer.player1;
                    player[1].setIsMyTurn(false);
                    player[0].setIsMyTurn(true);
                    _UIManager.setTurn(player[0].playerIndex, false);

                    if (player[0].isBankrupt)
                    {
                        SwitchPlayer();
                    }
                }
            }
            else if (numOfPlayers == 3)
            {
                if (currentPlayer == CurrentPlayer.player1)
                {
                    currentPlayer = CurrentPlayer.player2;
                    player[0].setIsMyTurn(false);
                    player[1].setIsMyTurn(true);
                    _UIManager.setTurn(player[1].playerIndex, false);

                    if (player[1].isBankrupt)
                    {
                        SwitchPlayer();
                    }
                }
                else if (currentPlayer == CurrentPlayer.player2)
                {
                    currentPlayer = CurrentPlayer.player3;
                    player[1].setIsMyTurn(false);
                    player[2].setIsMyTurn(true);
                    _UIManager.setTurn(player[2].playerIndex, false);

                    if (player[2].isBankrupt)
                    {
                        SwitchPlayer();
                    }
                }
                else if (currentPlayer == CurrentPlayer.player3)
                {
                    currentPlayer = CurrentPlayer.player1;
                    player[2].setIsMyTurn(false);
                    player[0].setIsMyTurn(true);
                    _UIManager.setTurn(player[0].playerIndex, false);

                    if (player[0].isBankrupt)
                    {
                        SwitchPlayer();
                    }
                }
            }
            else if (numOfPlayers == 4)
            {
                if (currentPlayer == CurrentPlayer.player1)
                {
                    currentPlayer = CurrentPlayer.player2;
                    player[0].setIsMyTurn(false);
                    player[1].setIsMyTurn(true);
                    _UIManager.setTurn(player[1].playerIndex, false);

                    if (player[1].isBankrupt)
                    {
                        SwitchPlayer();
                    }
                }
                else if (currentPlayer == CurrentPlayer.player2)
                {
                    currentPlayer = CurrentPlayer.player3;
                    player[1].setIsMyTurn(false);
                    player[2].setIsMyTurn(true);
                    _UIManager.setTurn(player[2].playerIndex, false);

                    if (player[2].isBankrupt)
                    {
                        SwitchPlayer();
                    }
                }
                else if (currentPlayer == CurrentPlayer.player3)
                {
                    currentPlayer = CurrentPlayer.player4;
                    player[2].setIsMyTurn(false);
                    player[3].setIsMyTurn(true);
                    _UIManager.setTurn(player[3].playerIndex, false);

                    if (player[3].isBankrupt)
                    {
                        SwitchPlayer();
                    }
                }
                else if (currentPlayer == CurrentPlayer.player4)
                {
                    currentPlayer = CurrentPlayer.player1;
                    player[3].setIsMyTurn(false);
                    player[0].setIsMyTurn(true);
                    _UIManager.setTurn(player[0].playerIndex, false);

                    if (player[0].isBankrupt)
                    {
                        SwitchPlayer();
                    }
                }
            }
        }

        public void SwitchPlayer(bool isSuffle) //Switch to next player
        {
            if (isSuffle)
            {
                if (numOfPlayers == 2)
                {
                    if (currentPlayer == CurrentPlayer.player1)
                    {
                        currentPlayer = CurrentPlayer.player2;
                        player[0].setIsMyTurn(false);
                        player[1].setIsMyTurn(true);
                        UIManager.Instance.setTurn(player[1].playerIndex, true);

                        if (player[1].isBankrupt)
                        {
                            SwitchPlayer(true);
                        }
                    }
                    else if (currentPlayer == CurrentPlayer.player2)
                    {
                        currentPlayer = CurrentPlayer.player1;
                        player[1].setIsMyTurn(false);
                        player[0].setIsMyTurn(true);
                        UIManager.Instance.setTurn(player[0].playerIndex, true);

                        if (player[0].isBankrupt)
                        {
                            SwitchPlayer(true);
                        }
                    }
                }
                else if (numOfPlayers == 3)
                {
                    if(currentPlayer == CurrentPlayer.player1)
                    {
                        currentPlayer = CurrentPlayer.player2;
                        player[0].setIsMyTurn(false);
                        player[1].setIsMyTurn(true);
                        UIManager.Instance.setTurn(player[1].playerIndex, true);

                        if (player[1].isBankrupt)
                        {
                            SwitchPlayer(true);
                        }
                    }
                    else if (currentPlayer == CurrentPlayer.player2)
                    {
                        currentPlayer = CurrentPlayer.player3;
                        player[1].setIsMyTurn(false);
                        player[2].setIsMyTurn(true);
                        UIManager.Instance.setTurn(player[2].playerIndex, true);

                        if (player[2].isBankrupt)
                        {
                            SwitchPlayer(true);
                        }
                    }
                    else if (currentPlayer == CurrentPlayer.player3)
                    {
                        currentPlayer = CurrentPlayer.player1;
                        player[2].setIsMyTurn(false);
                        player[0].setIsMyTurn(true);
                        UIManager.Instance.setTurn(player[0].playerIndex, true);

                        if (player[0].isBankrupt)
                        {
                            SwitchPlayer(true);
                        }
                    }
                }
                else if (numOfPlayers == 4)
                {
                    if (currentPlayer == CurrentPlayer.player1)
                    {
                        currentPlayer = CurrentPlayer.player2;
                        player[0].setIsMyTurn(false);
                        player[1].setIsMyTurn(true);
                        UIManager.Instance.setTurn(player[1].playerIndex, true);

                        if (player[1].isBankrupt)
                        {
                            SwitchPlayer(true);
                        }
                    }
                    else if (currentPlayer == CurrentPlayer.player2)
                    {
                        currentPlayer = CurrentPlayer.player3;
                        player[1].setIsMyTurn(false);
                        player[2].setIsMyTurn(true);
                        UIManager.Instance.setTurn(player[2].playerIndex, true);

                        if (player[2].isBankrupt)
                        {
                            SwitchPlayer(true);
                        }
                    }
                    else if (currentPlayer == CurrentPlayer.player3)
                    {
                        currentPlayer = CurrentPlayer.player4;
                        player[2].setIsMyTurn(false);
                        player[3].setIsMyTurn(true);
                        UIManager.Instance.setTurn(player[3].playerIndex, true);

                        if (player[3].isBankrupt)
                        {
                            SwitchPlayer(true);
                        }
                    }
                    else if (currentPlayer == CurrentPlayer.player4)
                    {
                        currentPlayer = CurrentPlayer.player1;
                        player[3].setIsMyTurn(false);
                        player[0].setIsMyTurn(true);
                        UIManager.Instance.setTurn(player[0].playerIndex, true);

                        if (player[0].isBankrupt)
                        {
                            SwitchPlayer(true);
                        }
                    }
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

        public Player SwitchWithoutPlayer(Player currentOpponent, Player currentMyPlayer, bool isNext)
        {
            if (isNext)
            {
                if (numOfPlayers == 4)
                {
                    if (currentOpponent == player[0])
                    {
                        if (currentMyPlayer == player[1])
                        {
                            return player[2];
                        }
                        else
                        {
                            return player[1];
                        }
                    }
                    else if (currentOpponent == player[1])
                    {
                        if (currentMyPlayer == player[2])
                        {
                            return player[3];
                        }
                        else
                        {
                            return player[2];
                        }
                    }
                    else if (currentOpponent == player[2])
                    {
                        if (currentMyPlayer == player[3])
                        {
                            return player[0];
                        }
                        else
                        {
                            return player[3];
                        }
                    }
                    else if (currentOpponent == player[3])
                    {
                        if (currentMyPlayer == player[0])
                        {
                            return player[1];
                        }
                        else
                        {
                            return player[0];
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (numOfPlayers == 3)
                {
                    if (currentOpponent == player[0])
                    {
                        if (currentMyPlayer == player[1])
                        {
                            return player[2];
                        }
                        else
                        {
                            return player[1];
                        }
                    }
                    else if (currentOpponent == player[1])
                    {
                        if (currentMyPlayer == player[2])
                        {
                            return player[0];
                        }
                        else
                        {
                            return player[2];
                        }
                    }
                    else if (currentOpponent == player[2])
                    {
                        if (currentMyPlayer == player[0])
                        {
                            return player[1];
                        }
                        else
                        {
                            return player[0];
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (numOfPlayers == 2)
                {
                    if (currentOpponent == player[0])
                    {
                        if (currentMyPlayer == player[1])
                        {
                            return player[0];
                        }
                        else
                        {
                            return player[1];
                        }
                    }
                    else if (currentOpponent == player[1])
                    {
                        if (currentMyPlayer == player[0])
                        {
                            return player[1];
                        }
                        else
                        {
                            return player[0];
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (numOfPlayers == 4)
                {
                    if (currentOpponent == player[0])
                    {
                        if (currentMyPlayer == player[3])
                        {
                            return player[2];
                        }
                        else
                        {
                            return player[3];
                        }
                    }
                    else if (currentOpponent == player[1])
                    {
                        if (currentMyPlayer == player[0])
                        {
                            return player[3];
                        }
                        else
                        {
                            return player[0];
                        }
                    }
                    else if (currentOpponent == player[2])
                    {
                        if (currentMyPlayer == player[1])
                        {
                            return player[0];
                        }
                        else
                        {
                            return player[1];
                        }
                    }
                    else if (currentOpponent == player[3])
                    {
                        if (currentMyPlayer == player[2])
                        {
                            return player[1];
                        }
                        else
                        {
                            return player[2];
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (numOfPlayers == 3)
                {
                    if (currentOpponent == player[0])
                    {
                        if (currentMyPlayer == player[2])
                        {
                            return player[1];
                        }
                        else
                        {
                            return player[2];
                        }
                    }
                    else if (currentOpponent == player[1])
                    {
                        if (currentMyPlayer == player[0])
                        {
                            return player[2];
                        }
                        else
                        {
                            return player[0];
                        }
                    }
                    else if (currentOpponent == player[2])
                    {
                        if (currentMyPlayer == player[1])
                        {
                            return player[0];
                        }
                        else
                        {
                            return player[1];
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (numOfPlayers == 2)
                {
                    if (currentOpponent == player[0])
                    {
                        if (currentMyPlayer == player[1])
                        {
                            return player[0];
                        }
                        else
                        {
                            return player[1];
                        }
                    }
                    else if (currentOpponent == player[1])
                    {
                        if (currentMyPlayer == player[0])
                        {
                            return player[1];
                        }
                        else
                        {
                            return player[0];
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
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
            if (numOfPlayers == 2)
            {
                if (getCurrentPlayer() == player[0])
                {
                    return new Player[] { player[1] };
                }
                else if (getCurrentPlayer() == player[1])
                {
                    return new Player[] { player[0] };
                }
                else
                {
                    return null;
                }
            }
            else if (numOfPlayers == 3)
            {
                if (getCurrentPlayer() == player[0])
                {
                    return new Player[] { player[1], player[2] };
                }
                else if (getCurrentPlayer() == player[1])
                {
                    return new Player[] { player[0], player[2] };
                }
                else if (getCurrentPlayer() == player[2])
                {
                    return new Player[] { player[0], player[1] };
                }
                else
                {
                    return null;
                }
            }
            else if (numOfPlayers == 4)
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
            else
            {
                return null;
            }
        }

        #endregion

        #region Property Information Card Action And Show
        public void StandOnThisSlot(int slotNumber)
        {
            if (getCurrentPlayer().inAuction == false) //fix bug when changing player while auctioning, jail panel is open when switch to a player in jail
            {
                for (int i = 0; i < slot.Length; i++) //Allow to view slot information when click
                {
                    getSlot(i).slotAction = SlotAction.Idle;
                }

                if (slotNumber == 20 || slotNumber == 0 || slotNumber == 10 || slotNumber == 30 || getSlot(slotNumber).isOwned)
                {
                    LiveUpdate.Instance.OptionsUpdate();
                }

                if (!getSlot(slotNumber).isOwned) //If that slot didnt have an owner
                {
                    //Call Property Information Card
                    _UIManager.ShowInformationCard(slotNumber);
                    //If the slot is unowned, turn off executing Utilities and Railroad of the currentPlayer
                    getCurrentPlayer().exeRailroads = false;
                    getCurrentPlayer().exeUtilities = false;

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
                                    getCurrentPlayer().exeRailroads = true;

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
                                    getCurrentPlayer().exeRailroads = true;

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
                                    getCurrentPlayer().exeUtilities = true;

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
                                    //print(getCurrentPlayer() + " collects 50$");
                                    CurrentPlayerInstantReceiveBank(50);
                                    break;
                                case ChanceCards.JailFree:
                                    //print(getCurrentPlayer() + " Get Out of Jail Free Card");
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
                                    CurrentPlayerInstantPayBank(getCurrentPlayer().houseOwned * 25 + getCurrentPlayer().hotelOwned * 100);
                                    break;
                                case ChanceCards.Speeding:
                                    //print(getCurrentPlayer() + " Pays 15$");
                                    CurrentPlayerInstantPayBank(15);
                                    break;
                                case ChanceCards.ReadingRailroad:
                                    getCurrentPlayer().setLateMove(5, true);
                                    _UIManager.EndTurnActive(false); //Turn off the endturn UI when executing cards
                                    break;
                                case ChanceCards.Chairman:
                                    //print(getCurrentPlayer() + " Pays each player 50$");
                                    CurrentPlayerPayFor(getRemainingPlayer(), 50);
                                    break;
                                case ChanceCards.Earn150:
                                    //print(getCurrentPlayer() + " Collect 150$");
                                    CurrentPlayerInstantReceiveBank(150);
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
                                    //print(getCurrentPlayer().ToString() + " Collect 200$");
                                    CurrentPlayerInstantReceiveBank(200);
                                    break;
                                case CommunityChestCards.Doctor:
                                    //print(getCurrentPlayer().ToString() + " Pays 50$");
                                    CurrentPlayerInstantPayBank(50);
                                    break;
                                case CommunityChestCards.Stock:
                                    //print(getCurrentPlayer().ToString() + " Collect 50$");
                                    CurrentPlayerInstantReceiveBank(50);
                                    break;
                                case CommunityChestCards.JailFree:
                                    //print(getCurrentPlayer().ToString() + " Get Out of Jaili Free Card");
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
                                    //print(getCurrentPlayer().ToString() + " Collect 100$");
                                    CurrentPlayerInstantReceiveBank(100);
                                    break;
                                case CommunityChestCards.Income:
                                    //print(getCurrentPlayer().ToString() + " Collect 20$");
                                    CurrentPlayerInstantReceiveBank(20);
                                    break;
                                case CommunityChestCards.Birthday:
                                    //print(getCurrentPlayer().ToString() + " Collect 10$ from each player");
                                    CurrentPlayerReceiveFrom(getRemainingPlayer(), 10);
                                    break;
                                case CommunityChestCards.Insurance:
                                    //print(getCurrentPlayer().ToString() + " Collect 100$");
                                    CurrentPlayerInstantReceiveBank(100);
                                    break;
                                case CommunityChestCards.Hospital:
                                    //print(getCurrentPlayer().ToString() + " Pays 100$"); 
                                    CurrentPlayerInstantPayBank(100);
                                    break;
                                case CommunityChestCards.School:
                                    //print(getCurrentPlayer().ToString() + " Pays 50$");
                                    CurrentPlayerInstantPayBank(50);
                                    break;
                                case CommunityChestCards.Consultancy:
                                    //print(getCurrentPlayer().ToString() + " Collect 25$");
                                    CurrentPlayerInstantReceiveBank(25);
                                    break;
                                case CommunityChestCards.StreetRepair:
                                    CurrentPlayerInstantPayBank(getCurrentPlayer().houseOwned * 40 + getCurrentPlayer().hotelOwned * 115);
                                    //print(getCurrentPlayer().ToString() + " Pay 40$ per house, 115$ per hotel");
                                    break;
                                case CommunityChestCards.Beauty:
                                    //print(getCurrentPlayer().ToString() + " Collect 10$");
                                    CurrentPlayerInstantReceiveBank(10);
                                    break;
                                case CommunityChestCards.Inherit:
                                    //print(getCurrentPlayer().ToString() + " Collect 100$");
                                    CurrentPlayerInstantReceiveBank(100);
                                    break;
                            }
                        }
                        else if (getSlot(slotNumber).supriseSlot.slotType == SupriseSlot_Type.Tax)
                        {
                            //Process Tax Card in here
                            //print("Paid " + getSlot(slotNumber).supriseSlot.taxPrice);
                            CurrentPlayerInstantPayBank(getSlot(slotNumber).supriseSlot.taxPrice);
                        }
                    }
                }
                else //has to paid slot
                {
                    PaidRent(slotNumber);
                }
            }
        }

        public void PaidRent(int slotNumber)
        {
            if ((getSlot(slotNumber).slotType == Slot_Type.ColorProperty || getSlot(slotNumber).slotType == Slot_Type.SpecialProperty) && getSlot(slotNumber).getOwner() != getCurrentPlayer() && !getSlot(slotNumber).isMortgaged) //is color or special props & the owner is not this currentPlayer & the slot is not morgaged
            {
                //if current player is executing Utilities or Railroads
                if (getCurrentPlayer().exeRailroads)
                {
                    CurrentPlayerPayFor(getSlot(slotNumber).getOwner(), getSlot(slotNumber).getPropertyRent() * 2);
                    _UIManager.ShowRentPaidUI(getCurrentPlayer(), getSlot(slotNumber).getOwner(), getSlot(slotNumber).getPropertyRent() * 2);
                    getCurrentPlayer().exeRailroads = false;
                }
                else if (getCurrentPlayer().exeUtilities) //show the UI said the player must roll again to pay the owner
                {
                    //show UI
                    _UIManager.DicesActive(true); //turn on dices
                    _UIManager.DicesFacesActive();
                    getCurrentPlayer().isRolltoPay = true;
                    _UIManager.EndTurnActive(false);
                }    
                else //if player is not executing anything
                {
                    CurrentPlayerPayFor(getSlot(slotNumber).getOwner(), getSlot(slotNumber).getPropertyRent());
                    _UIManager.ShowRentPaidUI(getCurrentPlayer(), getSlot(slotNumber).getOwner(), getSlot(slotNumber).getPropertyRent());
                }
            }
        }

        public void Buy()
        {
            slot[getCurrentPlayer().currentSlot].GetComponent<Slot>().setOwner(getCurrentPlayer()); //set owner to slot
            CurrentPlayerPayBank(slot[getCurrentPlayer().currentSlot].GetComponent<Slot>().getSlotPrice()); //pay bank

            if (getSlot(getCurrentPlayer().currentSlot).slotType == Slot_Type.ColorProperty)    
            {
                bool isGroup_Brown = true;
                bool isGroup_Blue = true;
                bool isGroup_Pink = true;
                bool isGroup_Orange = true;
                bool isGroup_Red = true;
                bool isGroup_Yellow = true;
                bool isGroup_Green = true;
                bool isGroup_Purple = true;

                bool skipBrown = false;
                bool skipBlue = false;
                bool skipPink = false;
                bool skipOrange = false;
                bool skipRed = false;
                bool skipYellow = false;
                bool skipGreen = false;
                bool skipPurple = false;

                for (int i = 0; i < slot.Length; i++)
                {
                    if (getSlot(i).slotType == Slot_Type.ColorProperty)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Brown && !skipBrown)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Brown = true;
                            }
                            else
                            {
                                isGroup_Brown = false;
                                skipBrown = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Blue && !skipBlue)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Blue = true;
                            }
                            else
                            {
                                isGroup_Blue = false;
                                skipBlue = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Pink && !skipPink)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Pink = true;
                            }
                            else
                            {
                                isGroup_Pink = false;
                                skipPink = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Orange && !skipOrange)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Orange = true;
                            }
                            else
                            {
                                isGroup_Orange = false;
                                skipOrange = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Red && !skipRed)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Red = true;
                            }
                            else
                            {
                                isGroup_Red = false;
                                skipRed = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Yellow && !skipYellow)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Yellow = true;
                            }
                            else
                            {
                                isGroup_Yellow = false;
                                skipYellow = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Green && !skipGreen)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Green = true;
                            }
                            else
                            {
                                isGroup_Green = false;
                                skipGreen = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Purple && !skipPurple)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Purple = true;
                            }
                            else
                            {
                                isGroup_Purple = false;
                                skipPurple = true;
                            }
                        }
                    }
                }

                for (int i = 0; i < slot.Length; i++)
                {
                    if (getSlot(i).slotType == Slot_Type.ColorProperty)
                    {
                        if (isGroup_Brown)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Brown)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Blue)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Blue)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Pink)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Pink)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Orange)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Orange)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Red)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Red)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Yellow)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Yellow)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Green)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Green)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Purple)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Purple)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                _UIManager.ShowColorPropertyBought();
            }
            else if (getSlot(getCurrentPlayer().currentSlot).slotType == Slot_Type.SpecialProperty)
            {
                if (getSlot(getCurrentPlayer().currentSlot).specialProperty.propertyType == SpecialProperty_Type.RailRoad)
                {
                    getCurrentPlayer().railroadOwned++;
                }
                else if (getSlot(getCurrentPlayer().currentSlot).specialProperty.propertyType == SpecialProperty_Type.Utility)
                {
                    getCurrentPlayer().utilityOwned++;
                }

                _UIManager.ShowSpecialPropertyBought();
            }
        }

        public void Buy(int slotNumber, int slotPrice)
        {
            getSlot(slotNumber).setOwner(getCurrentPlayer()); //set owner to slot
            CurrentPlayerPayBank(slotPrice); //pay bank

            if (getSlot(slotNumber).slotType == Slot_Type.ColorProperty)
            {
                bool isGroup_Brown = true;
                bool isGroup_Blue = true;
                bool isGroup_Pink = true;
                bool isGroup_Orange = true;
                bool isGroup_Red = true;
                bool isGroup_Yellow = true;
                bool isGroup_Green = true;
                bool isGroup_Purple = true;

                bool skipBrown = false;
                bool skipBlue = false;
                bool skipPink = false;
                bool skipOrange = false;
                bool skipRed = false;
                bool skipYellow = false;
                bool skipGreen = false;
                bool skipPurple = false;

                for (int i = 0; i < slot.Length; i++)
                {
                    if (getSlot(i).slotType == Slot_Type.ColorProperty)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Brown && !skipBrown)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Brown = true;
                            }
                            else
                            {
                                isGroup_Brown = false;
                                skipBrown = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Blue && !skipBlue)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Blue = true;
                            }
                            else
                            {
                                isGroup_Blue = false;
                                skipBlue = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Pink && !skipPink)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Pink = true;
                            }
                            else
                            {
                                isGroup_Pink = false;
                                skipPink = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Orange && !skipOrange)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Orange = true;
                            }
                            else
                            {
                                isGroup_Orange = false;
                                skipOrange = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Red && !skipRed)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Red = true;
                            }
                            else
                            {
                                isGroup_Red = false;
                                skipRed = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Yellow && !skipYellow)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Yellow = true;
                            }
                            else
                            {
                                isGroup_Yellow = false;
                                skipYellow = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Green && !skipGreen)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Green = true;
                            }
                            else
                            {
                                isGroup_Green = false;
                                skipGreen = true;
                            }
                        }
                        else if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Purple && !skipPurple)
                        {
                            if (getSlot(i).getOwner() == getCurrentPlayer())
                            {
                                isGroup_Purple = true;
                            }
                            else
                            {
                                isGroup_Purple = false;
                                skipPurple = true;
                            }
                        }
                    }
                }

                for (int i = 0; i < slot.Length; i++)
                {
                    if (getSlot(i).slotType == Slot_Type.ColorProperty)
                    {
                        if (isGroup_Brown)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Brown)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Blue)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Blue)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Pink)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Pink)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Orange)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Orange)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Red)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Red)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Yellow)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Yellow)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Green)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Green)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (isGroup_Purple)
                        {
                            if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Purple)
                            {
                                getSlot(i).inSet = true;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                _UIManager.ShowColorPropertyBought();
            }
            else if (getSlot(slotNumber).slotType == Slot_Type.SpecialProperty)
            {
                if (getSlot(slotNumber).specialProperty.propertyType == SpecialProperty_Type.RailRoad)
                {
                    getCurrentPlayer().railroadOwned++;
                }
                else if (getSlot(slotNumber).specialProperty.propertyType == SpecialProperty_Type.Utility)
                {
                    getCurrentPlayer().utilityOwned++;
                }

                _UIManager.ShowSpecialPropertyBought();
            }
        }
    
        public void AuctionStart()
        {
            auc_currentPrice = 0;
            auc_currentPlayer = getCurrentPlayer();
            auc_startingPlayer = getCurrentPlayer();
            auc_playerInAuction = remainingPlayer;
            auc_slotNumber = getCurrentPlayer().currentSlot;

            _UIManager.ShowAuction(auc_slotNumber, auc_currentPlayer, auc_currentPrice, auc_playerWithHighestBid);
        }

        public void AuctionExecute()
        {
            //Show UI
            //them currentPlayer, currentPrice thanh parameter
            //Xu ly cac nut khi truyen vao nguoi choi (xem co du tien de bet khong)

            if (auc_playerInAuction == 1 && auc_currentPrice != 0)
            {
                _UIManager.CloseAuction(auc_slotNumber, getCurrentPlayer(), auc_startingPlayer, auc_currentPrice, true);
            }
            else
            {
                _UIManager.ShowAuction(auc_slotNumber, auc_currentPlayer, auc_currentPrice, auc_playerWithHighestBid);
            }
        }

        public void Auction_SmallBid()
        {
            auc_currentPrice += 10;
            auc_playerWithHighestBid = getCurrentPlayer();

            if (auc_playerInAuction == 0) //no one left, all player has withdraw
            {
                _UIManager.CloseAuction(auc_slotNumber, getCurrentPlayer(), auc_startingPlayer, auc_currentPrice, false);
            }
            else if (auc_playerInAuction == 1) //only one left, and he/she click on bid
            {
                _UIManager.CloseAuction(auc_slotNumber, getCurrentPlayer(), auc_startingPlayer, auc_currentPrice, true);
            }
            else
            {
                do
                {
                    SwitchPlayer(true);
                }
                while (getCurrentPlayer().joinAuction == false || getCurrentPlayer().isBankrupt);

                auc_currentPlayer = getCurrentPlayer();
                AuctionExecute();
            }
        }

        public void Auction_BigBid()
        {
            auc_currentPrice += 100;
            auc_playerWithHighestBid = getCurrentPlayer();

            if (auc_playerInAuction == 0) //no one left, all player has withdraw
            {
                _UIManager.CloseAuction(auc_slotNumber, getCurrentPlayer(), auc_startingPlayer, auc_currentPrice, false);
            }
            else if (auc_playerInAuction == 1) //only one left, and he/she click on bid
            {
                _UIManager.CloseAuction(auc_slotNumber, getCurrentPlayer(), auc_startingPlayer, auc_currentPrice, true);
            }
            else
            { 
                do
                {
                    SwitchPlayer(true);
                }
                while (getCurrentPlayer().joinAuction == false || getCurrentPlayer().isBankrupt);

                auc_currentPlayer = getCurrentPlayer();
                AuctionExecute();
            }
        }

        public void Auction_Withdraw()
        {
            getCurrentPlayer().joinAuction = false;
            auc_playerInAuction--;


            if (auc_playerInAuction == 0) //when everyone leave auction
            {
                _UIManager.CloseAuction(auc_slotNumber, getCurrentPlayer(), auc_startingPlayer, auc_currentPrice, false);
            }
            else
            {
                do
                {
                    SwitchPlayer(true);
                }
                while (getCurrentPlayer().joinAuction == false || getCurrentPlayer().isBankrupt);

                auc_currentPlayer = getCurrentPlayer();
                AuctionExecute();
            }
        }

        public void JailPay()
        {
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
            //LiveUpdate.Instance.CallBot();
        }

        //5 main actions
        //

        public void Build()
        {
            TurnPlayerApperance(false);
            bool isGroup_Brown = true;
            bool isGroup_Blue = true;
            bool isGroup_Pink = true;
            bool isGroup_Orange = true;
            bool isGroup_Red = true;
            bool isGroup_Yellow = true;
            bool isGroup_Green = true;
            bool isGroup_Purple = true;
            bool skipBrown = false;
            bool skipBlue = false;
            bool skipPink = false;
            bool skipOrange = false;
            bool skipRed = false;
            bool skipYellow = false;
            bool skipGreen = false;
            bool skipPurple = false;

            int lowestHouse_Brown = 6;
            int lowestHouse_Blue = 6;
            int lowestHouse_Pink = 6;
            int lowestHouse_Orange = 6;
            int lowestHouse_Red = 6;
            int lowestHouse_Yellow = 6;
            int lowestHouse_Green = 6;
            int lowestHouse_Purple = 6;


            for (int i = 0; i < slot.Length; i++)
            {
                if (getSlot(i).slotType == Slot_Type.ColorProperty)
                {
                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Brown && !skipBrown)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Brown = true;
                        }
                        else
                        {
                            isGroup_Brown = false;
                            skipBrown = true;
                        }
                    }
                
                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Blue && !skipBlue)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Blue = true;
                        }
                        else
                        {
                            isGroup_Blue = false;
                            skipBlue = true;
                        }
                    }
                
                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Pink && !skipPink)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Pink = true;
                        }
                        else
                        {
                            isGroup_Pink = false;
                            skipPink = true;
                        }
                    }
                
                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Orange && !skipOrange)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Orange = true;
                        }
                        else
                        {
                            isGroup_Orange = false;
                            skipOrange = true;
                        }
                    }
                
                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Red && !skipRed)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Red = true;
                        }
                        else
                        {
                            isGroup_Red = false;
                            skipRed = true;
                        }
                    }
                
                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Yellow && !skipYellow)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Yellow = true;
                        }
                        else
                        {
                            isGroup_Yellow = false;
                            skipYellow = true;
                        }
                    }
                
                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Green && !skipGreen)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Green = true;
                        }
                        else
                        {
                            isGroup_Green = false;
                            skipGreen = true;
                        }
                    }
                
                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Purple && !skipPurple)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Purple = true;
                        }
                        else
                        {
                            isGroup_Purple = false;
                            skipPurple = true;
                        }
                    }
                }
            }
        
            for (int i = 0; i < slot.Length; i++)
            {
                //slot[i].GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, .5f);
                UnshownSlot(slot[i]);
                getSlot(i).slotAction = SlotAction.None;

                if (getSlot(i).slotType == Slot_Type.ColorProperty)
                {
                    if (isGroup_Brown)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Brown)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Build;

                            if (getSlot(i).numberOfHouse <= lowestHouse_Brown)
                            {
                                lowestHouse_Brown = getSlot(i).numberOfHouse;
                            }
                        }
                    }
                
                    if (isGroup_Blue)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Blue)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Build;

                            if (getSlot(i).numberOfHouse <= lowestHouse_Blue)
                            {
                                lowestHouse_Blue = getSlot(i).numberOfHouse;
                            }
                        }
                    }
                
                    if (isGroup_Pink)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Pink)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Build;

                            if (getSlot(i).numberOfHouse <= lowestHouse_Pink)
                            {
                                lowestHouse_Pink = getSlot(i).numberOfHouse;
                            }
                        }
                    }
                
                    if (isGroup_Orange)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Orange)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Build;

                            if (getSlot(i).numberOfHouse <= lowestHouse_Orange)
                            {
                                lowestHouse_Orange = getSlot(i).numberOfHouse;
                            }
                        }
                    }
                
                    if (isGroup_Red)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Red)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Build;

                            if (getSlot(i).numberOfHouse <= lowestHouse_Red)
                            {
                                lowestHouse_Red = getSlot(i).numberOfHouse;
                            }
                        }
                    }
                
                    if (isGroup_Yellow)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Yellow)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Build;

                            if (getSlot(i).numberOfHouse <= lowestHouse_Yellow)
                            {
                                lowestHouse_Yellow = getSlot(i).numberOfHouse;
                            }
                        }
                    }
                
                    if (isGroup_Green)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Green)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Build;

                            if (getSlot(i).numberOfHouse <= lowestHouse_Green)
                            {
                                lowestHouse_Green = getSlot(i).numberOfHouse;
                            }
                        }
                    }
                
                    if (isGroup_Purple)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Purple)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Build;

                            if (getSlot(i).numberOfHouse <= lowestHouse_Purple)
                            {
                                lowestHouse_Purple = getSlot(i).numberOfHouse;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < slot.Length; i++)
            {
                if (getSlot(i).slotType == Slot_Type.ColorProperty)
                {
                    if (isGroup_Brown)
                    {
                        if (getSlot(i).numberOfHouse > lowestHouse_Brown) //Help to buyild house symmetrically
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 5) //Not showing when reach hotel
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getCurrentPlayer().playerMoney < getSlot(i).getBuildPrice()) //when player dont hanve enough money
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Blue)
                    {
                        if (getSlot(i).numberOfHouse > lowestHouse_Blue)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 5)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getCurrentPlayer().playerMoney < getSlot(i).getBuildPrice()) //when player dont hanve enough money
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Pink)
                    {
                        if (getSlot(i).numberOfHouse > lowestHouse_Pink)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 5)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getCurrentPlayer().playerMoney < getSlot(i).getBuildPrice()) //when player dont hanve enough money
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Orange)
                    {
                        if (getSlot(i).numberOfHouse > lowestHouse_Orange)
                        {
                        
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 5)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getCurrentPlayer().playerMoney < getSlot(i).getBuildPrice()) //when player dont hanve enough money
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Red)
                    {
                        if (getSlot(i).numberOfHouse > lowestHouse_Red)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 5)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getCurrentPlayer().playerMoney < getSlot(i).getBuildPrice()) //when player dont hanve enough money
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Yellow)
                    {
                        if (getSlot(i).numberOfHouse > lowestHouse_Yellow)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 5)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getCurrentPlayer().playerMoney < getSlot(i).getBuildPrice()) //when player dont hanve enough money
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Green)
                    {
                        if (getSlot(i).numberOfHouse > lowestHouse_Green)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 5)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getCurrentPlayer().playerMoney < getSlot(i).getBuildPrice()) //when player dont hanve enough money
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Purple)
                    {
                        if (getSlot(i).numberOfHouse > lowestHouse_Purple)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 5)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getCurrentPlayer().playerMoney < getSlot(i).getBuildPrice()) //when player dont hanve enough money
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }
                }
            }
        }

        public void Sell()
        {
            TurnPlayerApperance(false);
            bool isGroup_Brown = true;
            bool isGroup_Blue = true;
            bool isGroup_Pink = true;
            bool isGroup_Orange = true;
            bool isGroup_Red = true;
            bool isGroup_Yellow = true;
            bool isGroup_Green = true;
            bool isGroup_Purple = true;
            bool skipBrown = false;
            bool skipBlue = false;
            bool skipPink = false;
            bool skipOrange = false;
            bool skipRed = false;
            bool skipYellow = false;
            bool skipGreen = false;
            bool skipPurple = false;

            int highestHouse_Brown = -1;
            int highestHouse_Blue = -1;
            int highestHouse_Pink = -1;
            int highestHouse_Orange = -1;
            int highestHouse_Red = -1;
            int highestHouse_Yellow = -1;
            int highestHouse_Green = -1;
            int highestHouse_Purple = -1;


            for (int i = 0; i < slot.Length; i++)
            {
                if (getSlot(i).slotType == Slot_Type.ColorProperty)
                {
                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Brown && !skipBrown)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Brown = true;
                        }
                        else
                        {
                            isGroup_Brown = false;
                            skipBrown = true;
                        }
                    }

                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Blue && !skipBlue)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Blue = true;
                        }
                        else
                        {
                            isGroup_Blue = false;
                            skipBlue = true;
                        }
                    }

                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Pink && !skipPink)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Pink = true;
                        }
                        else
                        {
                            isGroup_Pink = false;
                            skipPink = true;
                        }
                    }

                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Orange && !skipOrange)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Orange = true;
                        }
                        else
                        {
                            isGroup_Orange = false;
                            skipOrange = true;
                        }
                    }

                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Red && !skipRed)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Red = true;
                        }
                        else
                        {
                            isGroup_Red = false;
                            skipRed = true;
                        }
                    }

                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Yellow && !skipYellow)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Yellow = true;
                        }
                        else
                        {
                            isGroup_Yellow = false;
                            skipYellow = true;
                        }
                    }

                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Green && !skipGreen)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Green = true;
                        }
                        else
                        {
                            isGroup_Green = false;
                            skipGreen = true;
                        }
                    }

                    if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Purple && !skipPurple)
                    {
                        if (getSlot(i).getOwner() == getCurrentPlayer())
                        {
                            isGroup_Purple = true;
                        }
                        else
                        {
                            isGroup_Purple = false;
                            skipPurple = true;
                        }
                    }
                }
            }

            for (int i = 0; i < slot.Length; i++)
            {
                //slot[i].GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, .5f);
                UnshownSlot(slot[i]);
                getSlot(i).slotAction = SlotAction.None;

                if (getSlot(i).slotType == Slot_Type.ColorProperty)
                {
                    if (isGroup_Brown)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Brown)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Sell;

                            if (getSlot(i).numberOfHouse > highestHouse_Brown)
                            {
                                highestHouse_Brown = getSlot(i).numberOfHouse;
                            }
                        }
                    }

                    if (isGroup_Blue)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Blue)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Sell;

                            if (getSlot(i).numberOfHouse > highestHouse_Blue)
                            {
                                highestHouse_Blue = getSlot(i).numberOfHouse;
                            }
                        }
                    }

                    if (isGroup_Pink)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Pink)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Sell;

                            if (getSlot(i).numberOfHouse > highestHouse_Pink)
                            {
                                highestHouse_Pink = getSlot(i).numberOfHouse;
                            }
                        }
                    }

                    if (isGroup_Orange)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Orange)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Sell;

                            if (getSlot(i).numberOfHouse > highestHouse_Orange)
                            {
                                highestHouse_Orange = getSlot(i).numberOfHouse;
                            }
                        }
                    }

                    if (isGroup_Red)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Red)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Sell;

                            if (getSlot(i).numberOfHouse > highestHouse_Red)
                            {
                                highestHouse_Red = getSlot(i).numberOfHouse;
                            }
                        }
                    }

                    if (isGroup_Yellow)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Yellow)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Sell;

                            if (getSlot(i).numberOfHouse > highestHouse_Yellow)
                            {
                                highestHouse_Yellow = getSlot(i).numberOfHouse;
                            }
                        }
                    }

                    if (isGroup_Green)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Green)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Sell;

                            if (getSlot(i).numberOfHouse > highestHouse_Green)
                            {
                                highestHouse_Green = getSlot(i).numberOfHouse;
                            }
                        }
                    }

                    if (isGroup_Purple)
                    {
                        if (getSlot(i).colorProperty.propertyColor == ColorProperty_Color.Purple)
                        {
                            ShowSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.Sell;

                            if (getSlot(i).numberOfHouse > highestHouse_Purple)
                            {
                                highestHouse_Purple = getSlot(i).numberOfHouse;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < slot.Length; i++)
            {
                if (getSlot(i).slotType == Slot_Type.ColorProperty)
                {
                    if (isGroup_Brown)
                    {
                        if (getSlot(i).numberOfHouse < highestHouse_Brown) //Help to buyild house symmetrically
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 0) //Not showing when reach 0 house
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Blue)
                    {
                        if (getSlot(i).numberOfHouse < highestHouse_Blue)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 0)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Pink)
                    {
                        if (getSlot(i).numberOfHouse < highestHouse_Pink)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 0)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Orange)
                    {
                        if (getSlot(i).numberOfHouse < highestHouse_Orange)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 0)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Red)
                    {
                        if (getSlot(i).numberOfHouse < highestHouse_Red)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 0)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Yellow)
                    {
                        if (getSlot(i).numberOfHouse < highestHouse_Yellow)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 0)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Green)
                    {
                        if (getSlot(i).numberOfHouse < highestHouse_Green)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 0)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }

                    if (isGroup_Purple)
                    {
                        if (getSlot(i).numberOfHouse < highestHouse_Purple)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                        else if (getSlot(i).numberOfHouse == 0)
                        {
                            UnshownSlot(slot[i]);
                            getSlot(i).slotAction = SlotAction.None;
                        }
                    }
                }
            }
        }

        public void Mortgage()
        {
            TurnPlayerApperance(false);
            for (int i = 0; i < slot.Length; i++)
            {
                if (getSlot(i).isOwned && !getSlot(i).isMortgaged)
                {
                    if (getSlot(i).getOwner() == getCurrentPlayer())
                    {
                        getSlot(i).slotAction = SlotAction.Mortgage;
                    }
                    else
                    {
                        UnshownSlot(slot[i]);
                        getSlot(i).slotAction = SlotAction.None;
                    }
                }
                else if (getSlot(i).isOwned && getSlot(i).isMortgaged)
                {
                    UnshownSlot(slot[i]);
                    getSlot(i).slotAction = SlotAction.None;
                }
                else
                {
                    UnshownSlot(slot[i]);
                    getSlot(i).slotAction = SlotAction.None;
                }
            }
        }
    
        public void Redeem()
        {
            TurnPlayerApperance(false);
            for (int i = 0; i < slot.Length; i++)
            {
                if (getSlot(i).isOwned && getSlot(i).isMortgaged)
                {
                    if (getSlot(i).getOwner() == getCurrentPlayer())
                    {
                        getSlot(i).slotAction = SlotAction.Redeem;
                    }
                    else
                    {
                        UnshownSlot(slot[i]);
                        getSlot(i).slotAction = SlotAction.None;
                    }
                }
                else
                {
                    UnshownSlot(slot[i]);
                    getSlot(i).slotAction = SlotAction.None;
                }
            }
        }

        public void ShowTradeItem(Player player, Transform content, GameObject property, bool forOpponent)
        {
            foreach (Slot slot in player.slotOwned)
            {
                GameObject tempProperty = Instantiate(property, content);
                tempProperty.GetComponent<PropertyCard>().TradeShowCard(slot.slotIndex);
                tempProperty.GetComponent<PropertyCard>().isSelected = false;

                if (!forOpponent)
                {
                    tempProperty.GetComponent<PropertyCard>().tradeLeft = true;
                }
                else
                {
                    tempProperty.GetComponent<PropertyCard>().tradeLeft = false;
                }
            }

            for (int i = 0; i < player.getPlayerJailFreeCard(); i++)
            {
                GameObject tempProperty = Instantiate(property, content);
                tempProperty.GetComponent<PropertyCard>().TradeShowCard(-1);
                tempProperty.GetComponent<PropertyCard>().isSelected = false;

                if (!forOpponent)
                {
                    tempProperty.GetComponent<PropertyCard>().tradeLeft = true;
                }
                else
                {
                    tempProperty.GetComponent<PropertyCard>().tradeLeft = false;
                }
            }
        } 

        public void UnshownSlot(GameObject slot)
        {
            IEnumerator start()
            {
                for (float f = 0; f <= .5f; f += Time.deltaTime)
                {
                    slot.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, Mathf.Lerp(1f, .5f, f / .15f));
                    //standOnInformationCasvasGroup.alpha = Mathf.Lerp(0f, 1f, f / .15f);
                    yield return null;
                }
            }
            StartCoroutine(start());
        }

        public void ShowSlot()
        {
            TurnPlayerApperance(true);
            for (int i = 0; i < slot.Length; i++)
            {
                ShowSlot(slot[i]);
            }
        }

        public void ShowSlot(GameObject slot)
        {
            IEnumerator start()
            {
                for (float f = 0; f <= .5f; f += Time.deltaTime)
                {
                    slot.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, Mathf.Lerp(.5f, 1f, f / .15f));
                    //standOnInformationCasvasGroup.alpha = Mathf.Lerp(0f, 1f, f / .15f);
                    yield return null;
                }
            }
            StartCoroutine(start());
        }

        public void TurnPlayerApperance(bool value)
        {
            if (numOfPlayers == 2)
            {
                player[0].gameObject.SetActive(value);
                player[1].gameObject.SetActive(value);
                player[2].gameObject.SetActive(false);
                player[3].gameObject.SetActive(false);
            }
            else if (numOfPlayers == 3)
            {
                player[0].gameObject.SetActive(value);
                player[1].gameObject.SetActive(value);
                player[2].gameObject.SetActive(value);
                player[3].gameObject.SetActive(false);
            }
            else if (numOfPlayers == 4)
            {
                player[0].gameObject.SetActive(value);
                player[1].gameObject.SetActive(value);
                player[2].gameObject.SetActive(value);
                player[3].gameObject.SetActive(value);
            }
        }

        #endregion

        //After player's move
        //
        public void AfterPlayerMove(Player player)
        {
            if (getCurrentPlayer().isInJail) //in jail: dice off, options on, endturn on
            {
                //print("in jail: dice off, options on, endturn on");
                _UIManager.DicesActive(false);
                _UIManager.DicesFacesActive();

                _UIManager.ActionsActive(true);
                _UIManager.EndTurnActive(true);

                StandOnThisSlot(player.currentSlot);
            }
            else if (!getCurrentPlayer().isInJail)
            {
                if (getCurrentPlayer().hasSecondTurn) //second turn on: dice on, options on, endturn off
                {
                    //print("second turn on: dice on, options on, endturn off");
                    _UIManager.DicesActive(true);
                    _UIManager.DicesFacesActive();

                    _UIManager.ActionsActive(true);
                    _UIManager.EndTurnActive(false);

                    StandOnThisSlot(player.currentSlot);
                }
                else if (!getCurrentPlayer().hasSecondTurn) //second turn off: dice off, options on, endturn on
                {
                    //print("second turn off: dice off, options on, endturn on");
                    _UIManager.DicesActive(false);
                    _UIManager.DicesFacesActive();

                    _UIManager.ActionsActive(true);
                    _UIManager.EndTurnActive(true);

                    StandOnThisSlot(player.currentSlot); 
                }
            }
        }

        public void SetPlayerOnSlot(int currentSlot)
        {
            if (currentSlot >= 40)
            {
                currentSlot -= 40;
            }

            getSlot(currentSlot).numOfPlayerInSlot = 0;
            List<Player> playerOnSlot = new List<Player>();

            for (int i = 0; i < numOfPlayers; i++)
            {
                if (player[i].currentSlot == currentSlot)
                {
                    getSlot(currentSlot).numOfPlayerInSlot++;
                    playerOnSlot.Add(player[i]);
                    //print("add " + currentSlot + player[i].playerName);
                }
            }

            if (getSlot(currentSlot).numOfPlayerInSlot != 0)
            {
                getSlot(currentSlot).setPlayerPos(playerOnSlot);
            }
        }

        public void SetPlayLeaveSlot(Player p)
        {
            getSlot(p.currentSlot).numOfPlayerInSlot--;
            getSlot(p.currentSlot).temp_playerOnSlot.Remove(p);
            getSlot(p.currentSlot).setPlayerLeave(getSlot(p.currentSlot).temp_playerOnSlot);
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
            //_UIManager.MoneyUpdate();
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
            //_UIManager.MoneyUpdate();
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

        public void PlayerPayForPlayer(Player payP, Player receiveP, int amount)
        {
            payP.PayMoney(amount);
            receiveP.ReceiveMoney(amount);
            _UIManager.MoneyUpdate();
        }

        #endregion

        public float GetScreenRatio()
        {
            int width = Screen.currentResolution.width;
            int height = Screen.currentResolution.height;
            float dpi = (float) width / height;
            //print("W: " + width + "; H: " + height);
            //print(dpi);
            return dpi;
        }

        public void ExecutingBankrupt()
        {
            _UIManager.OnDisable_TransparentPanel(_UIManager.bankruptcyPanel, _UIManager.moneyPanel);
        }
    }
}
