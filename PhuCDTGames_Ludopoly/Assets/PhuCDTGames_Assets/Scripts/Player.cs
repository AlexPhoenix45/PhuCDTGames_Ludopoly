using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int currentSlot = 0;
    public int playerIndex;
    public string playerName;
    public int playerMoney;
    public Vector4 playerColor;

    public void setPlayerIndex(int index)
    {
        playerIndex = index;
    }

    public void Move(int distance)
    {
        if (currentSlot + distance >= 40)
        {
            currentSlot = (currentSlot + distance) - 40;
        }
        else
        {
            currentSlot += distance;
        }
        SetPos(); //Set position on table right after Move
    }

    //This is set position on table
    public void SetPos()
    {
        transform.position = Table.Instance.slot[currentSlot].transform.position;
    }
    
    
}
