using GameAdd_Ludopoly;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractable : MonoBehaviour
{
    public bool thisInteractable
    {
        get { return GetComponent<Button>().interactable; }
        set
        {
            //if (!Table.Instance.getCurrentPlayer().isBotPlaying)
            //{
            //    GetComponent<Button>().interactable = value;
            //}
            //else
            //{
            //    GetComponent<Button>().interactable = false;
            //}
            GetComponent<Button>().interactable = value;
            if (GetComponent<Button>().gameObject.name == "Roll Dice")
            {
                UIManager.Instance._LiveUpdate.ReadyRollDice = value;
            }
            else if (GetComponent<Button>().gameObject.name == "End Turn")
            {
                UIManager.Instance._LiveUpdate.ReadyEndTurn = value;
            }
            else if (GetComponent<Button>().gameObject.name == "Build" || GetComponent<Button>().gameObject.name == "Sell" || GetComponent<Button>().gameObject.name == "Mortgage" || GetComponent<Button>().gameObject.name == "Redeem" || GetComponent<Button>().gameObject.name == "Trade")
            {
                UIManager.Instance._LiveUpdate.ReadyMainActions = value;
            }
        }
    }
}
