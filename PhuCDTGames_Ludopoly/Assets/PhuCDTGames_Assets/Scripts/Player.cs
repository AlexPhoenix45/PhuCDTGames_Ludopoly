using JetBrains.Annotations;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;

namespace GameAdd_Ludopoly
{
    public class Player : MonoBehaviour
    {
        #region Base Information
        [HideInInspector]
        public int currentSlot = 0, prvSlot = 0, playerIndex, tradePlayerIndex;
        [HideInInspector]
        public string playerName;
        [HideInInspector]
        public Vector4 playerColor;
        [HideInInspector]
        public bool isMyTurn = false, isInJail = false, isBankrupt = false;

        [HideInInspector]
        public int playerRanking = -1;

        [HideInInspector]
        public bool hasSecondTurn = false;
        #endregion

        #region Others Parameters
        //Roll a double
        //
        [HideInInspector]
        public int timesGetDoubles = 0, timesNotGetDoubles = 0, currentDices;

        //Executing Utilities and Railroads
        //
        [HideInInspector]
        public bool isRolltoPay = false, exeUtilities = false, exeRailroads = false;

        //Late Move
        //
        [HideInInspector]
        public int temp_destinationSlot;
        [HideInInspector]
        public bool temp_isForward, lateMoveSet = false, _isMoving = false;
        public bool isMoving
        {
            get {  return _isMoving; }
            set
            {
                _isMoving = value;
                LiveUpdate.Instance.MovingUpdate(this, value);
            }
        }

        //Jail
        //
        [HideInInspector]
        public bool rollForJail = false;
        [HideInInspector]
        public short numberJailFreeCard = 0;

        //Money
        //
        [SerializeField]
        public int PlayerMoney = 1000;

        public int playerMoney
        {
            get { return PlayerMoney; }
            set
            {
                PlayerMoney = value;
                if (PlayerMoney < 0)
                {
                    CheckBankruptcy();
                }
            }
        }

        [HideInInspector]
        public int oldPlayerMoney = 0;
        [HideInInspector]
        public bool moneyWarning = false;

        //House (use to calculate bankruptcy chance)
        //
        [HideInInspector]
        public short houseOwned = 0, hotelOwned = 0, railroadOwned = 0, utilityOwned = 0;
        [HideInInspector]
        public List<Slot> slotOwned;

        //Auction
        //
        [HideInInspector]
        public bool joinAuction = true, inAuction = false;

        //Not showing Jail Popup Parameter
        //
        [HideInInspector]
        public bool notShowJail = false;

        //Set curent Slot
        //
        [HideInInspector]
        public void setCurrentSlot(int currentSlot)
        {
            this.currentSlot = currentSlot;
        }
        #endregion

        //Bot Parameter
        //
        [Tooltip("Check this if Bot is playing this player")]
        public bool isBotPlaying = false;

        public Bot botBrain;

        public BotActions _botActions;
        public BotActions botActions
        {
            get { return _botActions; }
            set { _botActions = value; }
        }

        public CurrentState _currentActions;
        public CurrentState currentState
        {
            get { return _currentActions; }
            set 
            { 
                _currentActions = value;
                //BotExecute();
            }
        }

        #region Move and Move Anim
        public void Move(int distance, bool isFastMove)
        {
            bool passGo;
            prvSlot = currentSlot;
            Table.Instance.SetPlayLeaveSlot(this);
            if (currentSlot + distance >= 40)
            {
                int tempCurrentSlot = (currentSlot + distance) - 40;
                setCurrentSlot(tempCurrentSlot);
                passGo = true;
            }
            else
            {
                int tempCurrentSlot = currentSlot + distance;
                setCurrentSlot(tempCurrentSlot);
                passGo = false;
            }

            if (!isFastMove)
            {
                setPos(passGo, false); //Set position on table right after Move
            }
            else
            {
                setPos(passGo, true); //Set position on table right after Move
            }
        }

        //Move with destination
        //

        public void MoveToward(int destinationSlot, bool isForward)
        {
            if (isForward) //Move forward
            {
                if (destinationSlot > currentSlot)
                {
                    Move(destinationSlot - currentSlot, true);
                }
                else if (destinationSlot < currentSlot)
                { 
                    Move((destinationSlot + 40) - currentSlot, true);
                }
            }
            else //Move backward (to jail or back 3 spaces)
            {
                setPosNeg(destinationSlot);
            }
        }

        public void setLateMove(int destinationSlot, bool isForward) 
        {
            temp_destinationSlot = destinationSlot;
            temp_isForward = isForward;
            lateMoveSet = true;
        }

        public void LateMove()
        {
            if (lateMoveSet)
            {
                UIManager.Instance.EndTurnActive(false);
                UIManager.Instance.ActionsActive(false);
                if (isInJail && hasSecondTurn)
                {
                    UIManager.Instance.DicesFacesActive();
                }
                MoveToward(temp_destinationSlot, temp_isForward);
                lateMoveSet = false;
            }
        }

        //This is set position on table
        //

        public void setPos(bool passGo, bool isFastMove)
        {
            IEnumerator move()
            {
                isMoving = true;
                GetComponent<SpriteRenderer>().sortingOrder = 999;
                if (!passGo)
                {
                    for (int i = prvSlot + 1; i <= currentSlot; i++)
                    {
                        if (!isFastMove)
                        {
                            if (i != currentSlot - 1 && i != currentSlot)
                            {
                                LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .25f).setEaseInOutCirc();
                                yield return new WaitForSeconds(.25f);
                            }
                            else if (i == currentSlot - 1)
                            {
                                LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .25f).setEaseInOutCirc();
                                yield return new WaitForSeconds(.25f);
                                Table.Instance.SetPlayerOnSlot(i+1);
                            }
                            else
                            {
                                yield return new WaitForSeconds(.25f);
                                continue;
                            }
                        }
                        else
                        {
                            if (i != currentSlot - 1 && i != currentSlot)
                            {
                                LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .15f);
                                yield return new WaitForSeconds(.15f);
                            }
                            else if (i == currentSlot - 1)
                            {
                                LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .15f);
                                yield return new WaitForSeconds(.15f);
                                Table.Instance.SetPlayerOnSlot(i+1);
                            }
                            else
                            {
                                yield return new WaitForSeconds(.15f);
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = prvSlot + 1; i <= currentSlot + 40; i++)
                    {
                        if (i == 40)
                        {
                            Table.Instance.CurrentPlayerInstantReceiveBank(200);
                        }

                        if (!isFastMove)
                        {
                            if (i <= 39)
                            {
                                if (i != currentSlot + 40 - 1 && i != currentSlot + 40)
                                {
                                    LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .25f).setEaseInOutCirc();
                                    yield return new WaitForSeconds(.25f);
                                }
                                else if (i == currentSlot + 40 - 1)
                                { 
                                    LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .25f).setEaseInOutCirc();
                                    yield return new WaitForSeconds(.25f);
                                    Table.Instance.SetPlayerOnSlot(i + 1);
                                }
                                else
                                {
                                    yield return new WaitForSeconds(.25f);
                                    continue;
                                }
                            }
                            else
                            {
                                if (i != currentSlot + 40 - 1 && i != currentSlot + 40)
                                {
                                    LeanTween.move(gameObject, Table.Instance.slot[i - 40].transform.position, .25f).setEaseInOutCirc();
                                    yield return new WaitForSeconds(.25f);
                                }
                                else if (i == currentSlot + 40 - 1)
                                { 
                                    LeanTween.move(gameObject, Table.Instance.slot[i - 40].transform.position, .25f).setEaseInOutCirc();
                                    yield return new WaitForSeconds(.25f);
                                    Table.Instance.SetPlayerOnSlot(i - 40 + 1);
                                }
                                else
                                {
                                    yield return new WaitForSeconds(.25f);
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            if (i <= 39)
                            {
                                if (i != currentSlot + 40 - 1 && i != currentSlot + 40)
                                {
                                    LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .15f);
                                    yield return new WaitForSeconds(.15f);
                                }
                                else /*if (i != currentSlot + 40 - 1)*/
                                { 
                                    LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .15f);
                                    yield return new WaitForSeconds(.15f);
                                    Table.Instance.SetPlayerOnSlot(i + 1);
                                }
                                //else
                                //{
                                //    yield return new WaitForSeconds(.15f);
                                //    continue;
                                //}
                            }
                            else
                            {
                                if (i != currentSlot + 40 - 1 && i != currentSlot + 40)
                                {
                                    LeanTween.move(gameObject, Table.Instance.slot[i - 40].transform.position, .15f);
                                    yield return new WaitForSeconds(.15f);
                                }
                                else /*if (i != currentSlot + 40 - 1)*/
                                {
                                    LeanTween.move(gameObject, Table.Instance.slot[i - 40].transform.position, .15f);
                                    yield return new WaitForSeconds(.15f);
                                    Table.Instance.SetPlayerOnSlot(i - 40 + 1);
                                }
                                //else
                                //{
                                //    yield return new WaitForSeconds(.15f);
                                //    continue;
                                //}
                            }
                        }
                    }
                }
                isMoving = false;
                Table.Instance.AfterPlayerMove(this);
                //Table.Instance.SwitchPlayer();
                GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            StartCoroutine(move());
        }

        public void setPosNeg (int destinationNumber)
        {
            IEnumerator move()
            {
                isMoving = true;
                GetComponent<SpriteRenderer>().sortingOrder = 999;
                for (int i = currentSlot - 1; i >= destinationNumber; i--)
                {
                    LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .15f);
                    yield return new WaitForSeconds(.15f);
                }

                isMoving = false;
                setCurrentSlot(destinationNumber);
                Table.Instance.SetPlayerOnSlot(destinationNumber);
                Table.Instance.AfterPlayerMove(this);
                GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            StartCoroutine(move());
            Table.Instance.SetPlayLeaveSlot(this);
        }

        #endregion

        #region Turn and Double times Call
        int moneyLeft = 0;

        public void setIsMyTurn(bool value)
        {
            isMyTurn = value;

            if (isMyTurn && !isBankrupt)
            {
                if (isInJail && !inAuction && !notShowJail)
                {
                    UIManager.Instance.ShowIsInJail();
                }

                if (!isBankrupt)
                {
                    CheckBankruptcy();
                }

                if (inAuction)
                {
                    currentState = CurrentState.AuctionSelect;
                }

                LiveUpdate.Instance.CallBot();
            }
        }

        public bool getIsMyTurn()
        {
            return isMyTurn;
        }

        //Call whenever roll a double
        //

        public void setTimesGetDoubles(bool hasDoubles, bool rollForJail)
        {
            if (!rollForJail)
            {
                if (hasDoubles)
                {
                    if (timesGetDoubles < 2)
                    {
                        timesGetDoubles++;
                        hasSecondTurn = true;
                    }
                    else if (timesGetDoubles >= 2)
                    {
                        if (currentSlot < 10)
                        {
                            MoveToward(10, true);
                        }
                        else if (currentSlot > 10)
                        {
                            MoveToward(10, false);
                        }

                        hasSecondTurn = false;
                        print("GO TO JAIL!");
                        UIManager.Instance.ShowGoToJail();
                        isInJail = true;    
                        timesGetDoubles = 0;
                    }
                }
                else
                {
                    timesGetDoubles = 0;
                    hasSecondTurn = false;
                }
            }
            else
            {
                if (!hasDoubles)
                {
                    if (timesNotGetDoubles < 2)
                    {
                        timesNotGetDoubles++;
                        UIManager.Instance.EndTurnActive(true);
                    }
                    else if (timesNotGetDoubles >= 2)
                    {
                        print("pay 100$");
                        Table.Instance.CurrentPlayerInstantPayBank(100);
                        isInJail = false;
                        timesNotGetDoubles = 0;
                    }
                }
                else
                {
                    timesNotGetDoubles = 0;
                    isInJail = false;
                }
            }
        }

        #endregion

        #region Jail

        //Jail
        //
        public void setIsInJail(bool value)
        {
            if (isInJail && !value)
            {
                isInJail = value;
            }
            else if (!isInJail && value)
            {
                isInJail = value;
                timesGetDoubles = 0;
                UIManager.Instance.DicesActive(false);
            }
        }

        public void JailPay()
        {
            isInJail = false;
            UIManager.Instance.HideInformationCard();
        }

        public void JailUseCard()
        {
            if (numberJailFreeCard > 0)
            {
                numberJailFreeCard--;
                isInJail = false;
                UIManager.Instance.HideInformationCard();
            }
            else
                return;
        }

        public void AddJailFreeCard()
        {
            numberJailFreeCard++;
        }

        public void RemoveJailFreeCard()
        {
            numberJailFreeCard--;
        }

        #endregion

        #region Money
        public void ReceiveMoney(int amount)
        {
            playerMoney += amount;
        }

        public void PayMoney(int amount)
        {
            playerMoney -= amount;
        }

        public void CheckBankruptcy()
        {
            if (playerMoney < 0 && !inAuction)
            {
                UIManager.Instance.ActionsActive(true);
                UIManager.Instance.DicesActive(false);
                UIManager.Instance.DicesFacesActive();
                UIManager.Instance.EndTurnActive(false);

                moneyLeft = 0; //Calculate all the property after sell and mortgage, if it is not enough, player is bankruptcy, left the game

                foreach (Slot slot in slotOwned)
                {
                    moneyLeft += (slot.numberOfHouse * slot.getSellPrice()) + slot.getMortgagePrice();
                }

                if (moneyLeft + playerMoney > 0) //survived
                {
                    UIManager.Instance.ShowBankruptcy(false);
                    moneyWarning = true;
                }
                else //bankruptcy
                {
                    UIManager.Instance.ShowBankruptcy(true);
                }
            }
        }
        #endregion

        #region Trade

        public int getPlayerMoney()
        {
            return playerMoney;
        }

        public List<Slot> getPlayerSlot()
        {
            List<Slot> slots = new List<Slot>();

            foreach (Slot slot in slotOwned)
            {
                slots.Add(slot);
            }
            return slots;
        }

        public int getPlayerJailFreeCard()
        {
            return numberJailFreeCard;
        }

        #endregion

        public void StartBankrupt()
        {
            foreach (var item in slotOwned)
            {
                item.removeOwner();
            }

            slotOwned.Clear();

            Table.Instance.RemainingPlayer--;

            if (playerIndex == 1)
            {
                UIManager.Instance.player1_bankruptImage.SetActive(true);
            }
            else if (playerIndex == 2)
            {
                UIManager.Instance.player2_bankruptImage.SetActive(true);
            }
            else if (playerIndex == 3)
            {
                UIManager.Instance.player3_bankruptImage.SetActive(true);
            }
            else if (playerIndex == 4)
            {
                UIManager.Instance.player4_bankruptImage.SetActive(true);
            }

            this.playerRanking = Table.Instance.playerRank;
            Table.Instance.playerRank--;
            isBankrupt = true;
            Table.Instance.ExecutingBankrupt(); //turn off bankruptcy panel
            gameObject.SetActive(false);
        } 

        //Bot Execute
        //
        //public void BotExecute()
        //{
        //    if (isBotPlaying)
        //    {
        //        if (currentState == CurrentState.WaitToRoll)
        //        {
        //            if (!isInJail)
        //            {
        //                print(playerName + " is Waiting to Roll!"); //fix for money popup
        //                IEnumerator waitTillMoneyPopupClose()
        //                {
        //                    while (UIManager.Instance.moneyPanel.activeSelf)
        //                    {
        //                        yield return null;  
        //                    }
        //                    botBrain.RollDice();
        //                }
        //                StartCoroutine(waitTillMoneyPopupClose());
        //            }
        //        }
        //        else if (currentState == CurrentState.BuyOrAuction)
        //        {
        //            print(playerName + " is Consider Buying or Auctioning!");
        //            botBrain.BuyOrAuction(this);
        //        }
        //        else if (currentState == CurrentState.AuctionSelect)
        //        {
        //            botBrain.AuctionSelection(this);
        //        }
        //        else if (currentState == CurrentState.JailSelect)
        //        {
        //            print(playerName + " is in Jail and Considering");
        //            botBrain.JailSelection(this);

        //            IEnumerator waitTillInJailPopupOpen()
        //            {
        //                while (!UIManager.Instance.inJailPanel.activeSelf)
        //                {
        //                    yield return null;
        //                }
        //                yield return new WaitForSeconds(.5f);
        //                botBrain.RollDice();
        //            }
        //            StartCoroutine(waitTillInJailPopupOpen());
        //        }
        //        else if (currentState == CurrentState.AfterSelection && !isMoving) //if in jail, next turn
        //        {
        //            if (hasSecondTurn)
        //            {
        //                currentState = CurrentState.WaitToRoll;
        //            }
        //            else
        //            {
        //                print("What will " + playerName + " do?");
        //                botBrain.EndTurn();
        //            }
        //        }
        //    }
        ////}
    }
}
