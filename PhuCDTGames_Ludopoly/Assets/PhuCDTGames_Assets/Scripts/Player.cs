using JetBrains.Annotations;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Base Information
    //
    public int currentSlot = 0;
    public int prvSlot = 0;
    public int playerIndex;
    public int tradePlayerIndex;
    public string playerName;
    public Vector4 playerColor;
    public bool isMyTurn = false;
    public bool isInJail = false;

    public bool hasSecondTurn = false;

    //Roll a double
    //
    public int timesGetDoubles = 0;
    public int timesNotGetDoubles = 0;
    public int currentDices;

    //Late Move
    //
    public int temp_destinationSlot;
    public bool temp_isForward;
    public bool lateMoveSet = false;

    //Jail
    //
    public bool rollForJail = false;
    public short numberJailFreeCard = 0;

    //Money
    //
    public int playerMoney = 1000;
    public int oldPlayerMoney = 0;
    public bool moneyWarning = false;

    //House
    //
    public short houseOwned = 0; //use to calculate bankruptcy chance
    public short hotelOwned = 0; //use to calculate bankruptcy chance
    public short railroadOwned = 0;
    public short utilityOwned = 0;
    public List<Slot> slotOwned;

    //Auction
    //
    public bool joinAuction = true;
    public bool inAuction = false;

    //Set curent Slot
    //
    public void setCurrentSlot(int currentSlot)
    {
        this.currentSlot = currentSlot;
    }

    //Move with distance
    //

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
            GetComponent<SpriteRenderer>().sortingOrder = 999;
            if (!passGo)
            {
                for (int i = prvSlot + 1; i <= currentSlot; i++)
                {
                    if (!isFastMove)
                    {
                        if (i != currentSlot - 1 && i != currentSlot)
                        {
                            LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .4f).setEaseInOutCirc();
                            yield return new WaitForSeconds(.4f);
                        }
                        else if (i == currentSlot - 1)
                        {
                            LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .4f).setEaseInOutCirc();
                            yield return new WaitForSeconds(.4f);
                            Table.Instance.SetPlayerOnSLot(i+1);
                        }
                        else
                        {
                            yield return new WaitForSeconds(.4f);
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
                            Table.Instance.SetPlayerOnSLot(i+1);
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
                        print("Receive 200$");
                        Table.Instance.CurrentPlayerInstantReceiveBank(200);
                    }

                    if (!isFastMove)
                    {
                        if (i <= 39)
                        {
                            if (i != currentSlot + 40 - 1 && i != currentSlot + 40)
                            {
                                LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .4f).setEaseInOutCirc();
                                yield return new WaitForSeconds(.4f);
                            }
                            else if (i == currentSlot + 40 - 1)
                            { 
                                LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .4f).setEaseInOutCirc();
                                yield return new WaitForSeconds(.4f);
                                Table.Instance.SetPlayerOnSLot(i + 1);
                            }
                            else
                            {
                                yield return new WaitForSeconds(.4f);
                                continue;
                            }
                        }
                        else
                        {
                            if (i != currentSlot + 40 - 1 && i != currentSlot + 40)
                            {
                                LeanTween.move(gameObject, Table.Instance.slot[i - 40].transform.position, .4f).setEaseInOutCirc();
                                yield return new WaitForSeconds(.4f);
                            }
                            else if (i == currentSlot + 40 - 1)
                            { 
                                LeanTween.move(gameObject, Table.Instance.slot[i - 40].transform.position, .4f).setEaseInOutCirc();
                                yield return new WaitForSeconds(.4f);
                                Table.Instance.SetPlayerOnSLot(i - 40 + 1);
                            }
                            else
                            {
                                yield return new WaitForSeconds(.4f);
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
                                Table.Instance.SetPlayerOnSLot(i + 1);
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
                                Table.Instance.SetPlayerOnSLot(i - 40 + 1);
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
            GetComponent<SpriteRenderer>().sortingOrder = 999;
            for (int i = currentSlot - 1; i >= destinationNumber; i--)
            {
                LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .15f);
                yield return new WaitForSeconds(.15f);
            }

            setCurrentSlot(destinationNumber);
            Table.Instance.AfterPlayerMove(this);
            GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        StartCoroutine(move());
        Table.Instance.SetPlayLeaveSlot(this);
    }

    //Turn
    //

    [SerializeField]
    int moneyLeft = 0;

    public void setIsMyTurn(bool value)
    {
        isMyTurn = value;

        if (isMyTurn)
        {
            if (isInJail && !inAuction)
            {
                UIManager.Instance.ShowIsInJail();
            }

            CheckBankruptcy();
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
        print("pay 100$");
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
        if (playerMoney < 0)
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
}
