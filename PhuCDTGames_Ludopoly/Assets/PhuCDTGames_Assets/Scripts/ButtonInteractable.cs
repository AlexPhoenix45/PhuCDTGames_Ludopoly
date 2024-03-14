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
            if (!Table.Instance.getCurrentPlayer().isBotPlaying)
            {
                GetComponent<Button>().interactable = value;
            }
            else
            {
                GetComponent<Button>().interactable = false;
            }
        }
    }
}
