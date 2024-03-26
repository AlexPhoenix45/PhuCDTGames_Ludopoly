using GameAdd_Ludopoly;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LiveUpdate : MonoBehaviour
{
    //Singleton
    //
    public static LiveUpdate Instance;

    [Header("MAIN MENU")]
    [Header("OPTIONS TOGGLE")]
    public bool _notUIExecute = false;
    public bool NotUIExecute
    {
        get
        {
            return _notUIExecute; 
        }
        set
        {
            _notUIExecute = value;
            if (value)
            {
                CallBot();
            }
        }
    }

    public bool _UIExecute = false;
    public bool UIExecute
    {
        get
        {
            return _UIExecute;
        }
        set
        {
            _UIExecute = value;
            if (value)
            {
                CallBot();
            }
        }
    }

    [Header("NOT UI OPTIONS")]
    public bool ReadyRollDice = false;
    public bool ReadyMainActions = false;
    public bool ReadyEndTurn = false;

    [Header("UI OPTIONS")]
    public bool ReadyToChoose_Property = false;
    public bool ReadyToChoose_Auction = false;
    public bool ReadyToChoose_Jail = false;
    public bool ReadyToChoose_Bankrupt = false;
    public bool ReadyToChoose_Trade = false;

    [Header("Time Called")]
    public int timeCalled = 0;

    [Header("PANEL")]
    [HideInInspector] 
    private bool ColorProp_OnClick = false, Special_OnClick = false, ColorProp_StandOn = false, SpecialProp_StandOn = false, SupriseCard = false, Auction = false, GoToJail = false, VisitJail = false, InJail = false, PaidRent = false, Bankrupt = false, TradeOffer = false, TradeReceive = false, TradeAccept = false, TradeDecline = false, Build = false, Redeem = false;

    [Header("MOVING")]
    [HideInInspector] 
    private bool P1Moving = false, P2Moving = false, P3Moving = false, P4Moving = false;

    private bool forcedClose_ChooseProperty = false;

    private void Start()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }

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
            TradeDecline = value;
        }
        else if (panel.name == "Build")
        {
            Build = value;
        }
        else if (panel.name == "Redeem")
        {
            Redeem = value;
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
        if (!ColorProp_StandOn && !SpecialProp_StandOn && !SupriseCard && !Auction && !GoToJail && !VisitJail && !InJail && !PaidRent && !Bankrupt && !TradeOffer && !TradeReceive && !TradeAccept && !TradeDecline && !P1Moving && !P2Moving && !P3Moving && !P4Moving && !Build && !Redeem)
        {
            if (ReadyEndTurn && !ReadyRollDice)
            {
                NotUIExecute = true;
            }
            else if (ReadyRollDice && !ReadyEndTurn)
            {
                NotUIExecute = true;
            }
            else
            {
                NotUIExecute = false; 
            }
        }
        else
        {
            NotUIExecute = false;
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

        if (ReadyToChoose_Property || ReadyToChoose_Auction || ReadyToChoose_Jail || ReadyToChoose_Bankrupt || ReadyToChoose_Trade)
        {
            UIExecute = true;
        }
        else
        {
            UIExecute = false;
        }
    }

    bool CallBotIsRunning = false;
    public void CallBot()
    {
        IEnumerator delay()
        {
            CallBotIsRunning = true;
            yield return new WaitForSeconds(.05f);
            if (NotUIExecute)
            {
                timeCalled++;
            }
            else if (UIExecute)
            {
                timeCalled++;
            }

            if (Table.Instance.getCurrentPlayer().isBotPlaying)
            {
                Table.Instance.getCurrentPlayer().botBrain.Execute();
            }
            CallBotIsRunning = false;
        }

        if (CallBotIsRunning)
        {
            return;
        }
        else
        {
            StartCoroutine(delay());
        }
    }
}
