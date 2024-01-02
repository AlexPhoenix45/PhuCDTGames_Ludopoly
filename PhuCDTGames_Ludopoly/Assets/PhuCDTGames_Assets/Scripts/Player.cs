using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int currentSlot = 0;
    public int oldSlot = 0;
    public int playerIndex;
    public string playerName;
    public int playerMoney;
    public Vector4 playerColor;
    public bool isMyTurn = false;
    public bool isInJail = false;


    public void setPlayerIndex(int index)
    {
        playerIndex = index;
    }

    public void Move(int distance)
    {
        bool passGo;
        oldSlot = currentSlot;
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
                for (int i = oldSlot + 1; i <= currentSlot; i++)
                {
                    LeanTween.move(gameObject, Table.Instance.slot[i].transform.position, .5f).setEaseInOutCirc();
                    yield return new WaitForSeconds(.5f);
                }
            }
            else
            {
                for (int i = oldSlot + 1; i <= currentSlot + 40; i++)
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
            UIManager.Instance.DicesActive(true);
            UIManager.Instance.OptionsActive(true);
            Table.Instance.SwitchPlayer();
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
}
