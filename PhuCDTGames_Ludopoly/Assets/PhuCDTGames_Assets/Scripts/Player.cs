using JetBrains.Annotations;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Base Information")]
    public int currentSlot = 0;
    public int prvSlot = 0;
    public int playerIndex;
    public string playerName;
    public Vector4 playerColor;
    public bool isMyTurn = false;
    public bool isInJail = false;

    public bool hasSecondTurn = false;

    //Roll a double
    [Header("Roll Double")]
    public int timesGetDoubles = 0;
    public int timesNotGetDoubles = 0;

    //Late Move
    [Header("Late Move")]
    public int temp_destinationSlot;
    public bool temp_isForward;
    public bool lateMoveSet = false;

    //Jail
    [Header("Jail")]
    public bool rollForJail = false;
    public short numberJailFreeCard = 0;

    //Money
    [Header("Money")]
    public int playerMoney = 1000;
    public int oldPlayerMoney = 0;

    public void setPlayerIndex(int index)
    {
        playerIndex = index;
    }

    //Move with distance
    //

    public void Move(int distance, bool isFastMove)
    {
        bool passGo;
        prvSlot = currentSlot;
        if (currentSlot + distance >= 40)
        {
            currentSlot = (currentSlot + distance) - 40;
            passGo = true;
        }
        else
        {
            currentSlot += distance;
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
            UIManager.Instance.OptionsActive(false);
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
            if (!passGo)
            {
                for (int i = prvSlot + 1; i <= currentSlot; i++)
                {
                    if (!isFastMove)
                    {
                        LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .5f).setEaseInOutCirc();
                        yield return new WaitForSeconds(.5f);
                    }
                    else
                    {
                        LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .15f);
                        yield return new WaitForSeconds(.15f);
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
                        Table.Instance.CurrentPlayerReceiveBank(200);
                    }

                    if (!isFastMove)
                    {
                        if (i <= 39)
                        {
                            LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .5f).setEaseInOutCirc();
                            yield return new WaitForSeconds(.5f);
                        }
                        else
                        {
                            LeanTween.move(gameObject, Table.Instance.slot[i - 40].transform.position, .5f).setEaseInOutCirc();
                            yield return new WaitForSeconds(.5f);
                        }
                    }
                    else
                    {
                        if (i <= 39)
                        {
                            LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .15f);
                            yield return new WaitForSeconds(.15f);
                        }
                        else
                        {
                            LeanTween.move(gameObject, Table.Instance.slot[i - 40].transform.position, .15f);
                            yield return new WaitForSeconds(.15f);
                        }
                    }
                }
            }
            Table.Instance.AfterPlayerMove(this);
            //Table.Instance.SwitchPlayer();
        }
        StartCoroutine(move());
    }

    public void setPosNeg (int destinationNumber)
    {
        IEnumerator move()
        { 
            for (int i = currentSlot - 1; i >= destinationNumber; i--)
            {
                LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .15f);
                yield return new WaitForSeconds(.15f);
            }

            currentSlot = destinationNumber;
            Table.Instance.AfterPlayerMove(this);
        }
        StartCoroutine(move());
    }
    
    //Turn
    //

    public void setIsMyTurn(bool value)
    {
        this.isMyTurn = value;

        if (isMyTurn)
        {
            if (isInJail)
            {
                UIManager.Instance.ShowIsInJail();
            }
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
                    Table.Instance.CurrentPlayerPayBank(100);
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

    #region Money
    public void ReceiveMoney(int amount)
    {
        playerMoney += amount;
    }

    public void PayMoney(int amount)
    {
        playerMoney -= amount;
    }
    #endregion
}
