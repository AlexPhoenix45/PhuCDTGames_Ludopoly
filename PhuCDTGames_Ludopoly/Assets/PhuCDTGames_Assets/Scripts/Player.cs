using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int currentSlot = 0;
    public int prvSlot = 0;
    public int playerIndex;
    public string playerName;
    public int playerMoney;
    public Vector4 playerColor;
    public bool isMyTurn = false;
    public bool isInJail = false;

    //Roll a double
    public int timesGetDoubles = 0;


    public void setPlayerIndex(int index)
    {
        playerIndex = index;
    }

    public void Move(int distance)
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
        setPos(passGo); //Set position on table right after Move
    }

    //This is set position on table
    public void setPos(bool passGo)
    {
        IEnumerator move()
        {
            if (!passGo)
            {
                for (int i = prvSlot + 1; i <= currentSlot; i++)
                {
                    LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .5f).setEaseInOutCirc();
                    yield return new WaitForSeconds(.5f);
                }
            }
            else
            {
                for (int i = prvSlot + 1; i <= currentSlot + 40; i++)
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
            }
            UIManager.Instance.DicesFacesActive();
            UIManager.Instance.OptionsActive(true);
            if (timesGetDoubles != 0)
            {
                UIManager.Instance.EndTurnActive(false);
            }
            else
            {
                UIManager.Instance.EndTurnActive(true);
            }
            Table.Instance.StandOnThisSlot(currentSlot);
            //Table.Instance.SwitchPlayer();
        }
        StartCoroutine(move());
    }
    
    public void setIsMyTurn(bool value)
    {
        this.isMyTurn = value;

    }

    public bool getIsMyTurn()
    {
        return isMyTurn;
    }

    //Call whenever roll a double
    public void setTimesGetDoubles(bool hasDoubles)
    {
        if (hasDoubles)
        {
            if (timesGetDoubles < 2)
            {
                timesGetDoubles++;
            }
            else if (timesGetDoubles >= 2)
            {
                print("GO TO JAIL!");
                timesGetDoubles = 0;
            }
        }
        else
        {
            timesGetDoubles = 0;
        }
    }
}
