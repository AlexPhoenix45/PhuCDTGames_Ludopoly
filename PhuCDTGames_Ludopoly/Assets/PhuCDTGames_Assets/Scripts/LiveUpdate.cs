using GameAdd_Ludopoly;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveUpdate : MonoBehaviour
{
    [Header("OPTIONS")]
    public bool ReadyMainMenu = false;
    public bool ReadyToChoose_Property = false;
    public bool ReadyToChoose_Auction = false;
    public bool ReadyToChoose_Jail = false;
    public bool ReadyToChoose_Bankrupt = false;
    public bool ReadyToChoose_Trade = false;

    [Header("PANEL")]
    public bool ColorProp_OnClick = false;
    public bool Special_OnClick = false;
    public bool ColorProp_StandOn = false;
    public bool SpecialProp_StandOn = false;
    public bool SupriseCard = false;
    public bool Auction = false;
    public bool GoToJail = false;
    public bool VisitJail = false;
    public bool InJail = false;
    public bool PaidRent = false;
    public bool Bankrupt = false;
    public bool TradeOffer = false;
    public bool TradeReceive = false;
    public bool TradeAccept = false;
    public bool TradeDecline = false;

    [Header("MOVING")]
    public bool P1Moving = false;
    public bool P2Moving = false;
    public bool P3Moving = false;
    public bool P4Moving = false;

    private bool forcedClose_ChooseProperty = false;

    public void PanelLiveUpdate(GameObject panel, bool value)
    {
        if (panel.name == "Color Property Information Card")
        {
            if (panel.transform.parent.name == "On-click Information") { ColorProp_OnClick = value; }
            else if (panel.transform.parent.name == "Stand-on Information") 
            {
                forcedClose_ChooseProperty = false;
                if (panel.transform.Find("Bought").gameObject.activeSelf)
                {
                    forcedClose_ChooseProperty = true;
                }
                ColorProp_StandOn = value;
            }
        }
        else if (panel.name == "Special Property Information Card")
        {
            if (panel.transform.parent.name == "On-click Information") { Special_OnClick = value; }
            else if (panel.transform.parent.name == "Stand-on Information") 
            {
                forcedClose_ChooseProperty = false;
                if (panel.transform.Find("Bought").gameObject.activeSelf)
                {
                    forcedClose_ChooseProperty = true;
                }
                SpecialProp_StandOn = value;
            }
        }
        else if (panel.name == "Suprise Information Card")
        {
            SupriseCard = value;
        }
        else if (panel.name == "Auction Information")
        {
            forcedClose_ChooseProperty = true;
            Auction = value;
        }
        else if (panel.name == "Visiting Jail")
        {
            VisitJail = value;
        }
        else if (panel.name == "Go To Jail")
        {
            GoToJail = value;
        }
        else if (panel.name == "In Jail")
        {
            InJail = value;
        }
        else if (panel.name == "Paid Rent")
        {
            PaidRent = value;
        }
        else if (panel.name == "Bankruptcy")
        {
            Bankrupt = value;
        }
        else if (panel.name == "Offer Panel")
        {
            TradeOffer = value;
        }
        else if (panel.name == "Receive Panel")
        {
            TradeReceive = value;
        }
        else if (panel.name == "Accept")
        {
            TradeAccept = value;
        }
        else if (panel.name == "Decline")
        {
            TradeAccept = value;
        }
        OptionsUpdate();
    }

    public void MovingUpdate (Player myPlayer, bool value)
    {
        if (myPlayer == Table.Instance.player[0])
        {
            P1Moving = value;
        }
        else if (myPlayer == Table.Instance.player[1])
        {
            P2Moving = value;
        }
        else if (myPlayer == Table.Instance.player[2])
        {
            P3Moving = value;
        }
        else if (myPlayer == Table.Instance.player[3])
        {
            P4Moving = value;
        }
        OptionsUpdate();
    }

    public void OptionsUpdate()
    {
        if (!ColorProp_StandOn && !SpecialProp_StandOn && !SupriseCard && !Auction && !GoToJail && !VisitJail && !InJail && !PaidRent && !Bankrupt && !TradeOffer && !TradeReceive && !TradeAccept && !TradeDecline && !P1Moving && !P2Moving && !P3Moving && !P4Moving)
        {
            ReadyMainMenu = true;
        }
        else
        {
            ReadyMainMenu = false;
        }

        if (!Auction)
        {
            if (ColorProp_StandOn || SpecialProp_StandOn)
            {
                if (forcedClose_ChooseProperty)
                {
                    ReadyToChoose_Property = false;
                }
                else
                {
                    ReadyToChoose_Property = true;
                }
            }
            else
            { 
                ReadyToChoose_Property = false;
            }
            ReadyToChoose_Auction = false;
        }
        else
        {
            ReadyToChoose_Property = false;
            ReadyToChoose_Auction = true;
        }

        if (InJail)
        {
            ReadyToChoose_Jail = true;
        }
        else
        {
            ReadyToChoose_Jail = false;
        }

        if (Bankrupt)
        {
            ReadyToChoose_Bankrupt = true;
        }
        else
        {
            ReadyToChoose_Bankrupt = false;
        }

        if (TradeReceive)
        {
            ReadyToChoose_Trade = true;
        }
        else
        {
            ReadyToChoose_Trade = false;
        }
    }
}
