using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameAdd_Ludopoly
{
    public class UIManager : MonoBehaviour
    {
        //Table
        public Table _Table;

        public LiveUpdate _LiveUpdate;

        //Singleton
        public static UIManager Instance;

        [Header("Actions")]
        public Button build;
        public Button sell;
        public Button mortgage;
        public Button redeem;
        public Button trade;
        public Button endTurn;

        [Header("Dice")]
        public Button rollDice;
        public GameObject[] dice1Faces;
        public GameObject[] dice2Faces;

        //-263.74

        [Header("Player 1")]
        [Header("Players")]
        public GameObject player1Panel;
        public Text player1Name;
        public Text player1Money;
        public CanvasGroup player1CanvasGroup;
        public GameObject player1_bankruptImage;
        public ParticleSystem p1Earn;
        public ParticleSystem p1Lose;

        [Header("Player 2")]
        public GameObject player2Panel;
        public Text player2Name;
        public Text player2Money;
        public CanvasGroup player2CanvasGroup;
        public GameObject player2_bankruptImage;
        public ParticleSystem p2Earn;
        public ParticleSystem p2Lose;

        [Header("Player 3")]
        public GameObject player3Panel;
        public Text player3Name;
        public Text player3Money;
        public CanvasGroup player3CanvasGroup;
        public GameObject player3_bankruptImage;
        public ParticleSystem p3Earn;
        public ParticleSystem p3Lose;

        [Header("Player 4")]
        public GameObject player4Panel;
        public Text player4Name;
        public Text player4Money;
        public CanvasGroup player4CanvasGroup;
        public GameObject player4_bankruptImage;
        public ParticleSystem p4Earn;
        public ParticleSystem p4Lose;

        [Header("Slot Information")]
        public GameObject standOnInformationPanel;
        public CanvasGroup standOnInformationCasvasGroup;
        public GameObject colorPropertyInformationCard;
        public GameObject specialPropertyInformationCard;
        public GameObject supriseInformationCard;

        #region Color Property Information Card

        [Header("Color Property - Card Template")]
        [Header("Color Property Information Card")]
        public ColorPropertyCard cpi_colorPropertyCard;
        public Button cpi_buyButton;
        public Button cpi_auctionButton;

        [Header("Color Property - Bought")]
        public Text cpi_buyer;
        public GameObject cpi_showButtonPanel;
        public GameObject cpi_boughtPanel;
        public GameObject cpi_redPawn;
        public GameObject cpi_bluePawn;
        public GameObject cpi_greenPawn;
        public GameObject cpi_yellowPawn;

        #endregion

        #region Special Property Information Card
        [Header("Special Property Information Card")]
        public SpecialPropertyCard sp_specialPropertyCard;
        public Button sp_buyButton;
        public Button sp_auctionButton;

        [Header("Special Property - Bought")]
        public Text ut_buyer;
        public GameObject ut_showButtonPanel;
        public GameObject ut_boughtPanel;
        public GameObject ut_redPawn;
        public GameObject ut_bluePawn;
        public GameObject ut_greenPawn;
        public GameObject ut_yellowPawn;

        #endregion

        #region Suprise Information Card

        [Header("Suprise Information Card")]
        public GameObject chanceAndCommunityChestInformation;
        public Text cc_description;
        public GameObject cc_communityChestImage;
        public GameObject cc_chanceImage;

        public GameObject taxInformation;
        public Text t_title;
        public Text t_description;

        #endregion

        #region Jail Card
        [Header("Jail Card")]
        [Header("Jail")]
        public GameObject jailPanel;
        public GameObject inJailPanel;
        public GameObject goToJailPanel;
        public GameObject visitingJailPanel;

        //In Jail
        //
        [Header("Jail - In Jail")]
        public Button ij_Pay;
        public Button ij_useCard;
        public Button ij_rollDouble;

        public GameObject ij_redPawn;
        public GameObject ij_greenPawn;
        public GameObject ij_bluePawn;
        public GameObject ij_yellowPawn;

        //Go To Jail
        //
        [Header("Jail - Go To Jail")]
        public GameObject gtj_redPawn;
        public GameObject gtj_greenPawn;
        public GameObject gtj_bluePawn;
        public GameObject gtj_yellowPawn;

        //Visiting Jail
        //
        [Header("Jail - Visiting Jail")]
        public GameObject vj_redPawn;
        public GameObject vj_greenPawn;
        public GameObject vj_bluePawn;
        public GameObject vj_yellowPawn;

        #endregion

        #region Money
        [Header("Money - Information")]
        [Header("Money")]
        public GameObject moneyPanel;
        public GameObject paidRentPanel;
        public Text paidAmount;
        public GameObject paidAmountContainer;

        [Header("Money - Paid Profile")]
        public GameObject pp_redPawn;
        public GameObject pp_greenPawn;
        public GameObject pp_bluePawn;
        public GameObject pp_yellowPawn;

        [Header("Money - Collect Profile")]
        public GameObject cp_redPawn;
        public GameObject cp_greenPawn;
        public GameObject cp_bluePawn;
        public GameObject cp_yellowPawn;
        #endregion

        #region Bankruptcy

        [Header("Bankruptcy")]
        public GameObject bankruptcyPanel;
        public Button payDebt;
        public Button bankRupt;

        #endregion

        #region On-click Information
        [Header("On-click - Information")]
        [Header("On-click")]
        public GameObject Onclick_InformationPanel;
        public GameObject Onclick_ColorPropertyInformationCard;
        public GameObject Onclick_SpecialPropertyInformationCard;

        [Header("On-click - Card Template")]
        public ColorPropertyCard oc_colorPropertyCard;
        public SpecialPropertyCard oc_specialPropertyCard;

        #endregion

        #region Main Actions
        [Header("Main Actions")]
        public GameObject mainActionPanel;
        public GameObject buildPanel;
        public GameObject sellPanel;
        public GameObject mortgagePanel;
        public GameObject redeemPanel;
        #endregion


        #region Auction
        [Header("Auction - Information")]
        [Header("Auction")]
        public GameObject auctionPanel;
        public CanvasGroup auctionCanvasGroup;
        public GameObject auctionInformationPanel;
        public Text ai_currentPlayerTurn;
        public Text ai_currentPrice;
        public GameObject ai_currentPrice_Container;
        public Text ai_currentPrice_Player;
        public Button ai_smallBid;
        public Button ai_bigBid;
        public Button ai_withdraw;
        public ColorPropertyCard ai_colorPropertyCard;
        public SpecialPropertyCard ai_specialPropertyCard;
    
        [Header("Trade")]
        public GameObject tradePanel;
        public GameObject trade_offerPanel;
        public GameObject trade_receivePanel;
        public GameObject trade_illegalPanel;
        public CanvasGroup trade_canvasGroup;

        [Header("Trade - Offer Panel")]
        public Text tradeoffer_title;
        public Text tradeoffer_selectedPlayer;
        public Transform tradeoffer_myPlayerContent;
        public Transform tradeoffer_opponentContent;
        public Text tradeoffer_myPlayerMoney;
        public Text tradeoffer_opponentMoney;
        public InputField tradeoffer_myPlayerMoneyValue;
        public InputField tradeoffer_opponentMoneyValue;
        public GameObject trade_property;
        Player trade_currentOpppnent;

        [Header("Trade - Receive Panel")]
        public Text tradereceive_title;
        public Transform tradereceive_myPlayerContent;
        public Transform tradereceive_opponentContent;
        public Text tradereceive_myPlayerMoney;
        public Text tradereceive_opponentMoney;
        public GameObject tradereceive_myPlayerMoney_Container;
        public GameObject tradereceive_opponentMoney_Container;

        [Header("Trade Result")]
        public GameObject tradeResultPanel;
        public GameObject tr_accept;
        public GameObject tr_decline;

        [Header("Scoreboard")]
        public GameObject scoreboardPanel;
        public GameObject scoreboardPanel_children;
        public GameObject scb_1st_Panel;
        public Text scb_1st_Name;
        public Profile scb_1st_Profile;

        public GameObject scb_2nd_Panel;
        public Text scb_2nd_Name;
        public Profile scb_2nd_Profile;

        public GameObject scb_3rd_Panel;
        public Text scb_3rd_Name;
        public Profile scb_3rd_Profile;

        public GameObject scb_4th_Panel;
        public Text scb_4th_Name;
        public Profile scb_4th_Profile;
        #endregion

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            setPlayerInfo();
        }

        #region Dice

        public void OnClick_RollDice() //This include suffle and roll an actual dices
        {
            DicesActive(false);
            ActionsActive(false);
            EndTurnActive(false);
            OnClick_ActionsClose();
            int[] dices = new int[2];
            IEnumerator diceSuffle()
            {
                float timeConsumed = 0;
                do
                {
                    yield return new WaitForSeconds(.05f);
                    int diceFace1 = UnityEngine.Random.Range(0, 6);
                    int diceFace2 = UnityEngine.Random.Range(0, 6);
                    setDicesFaces(1, diceFace1);
                    setDicesFaces(2, diceFace2);
                    timeConsumed += 0.05f;
                }
                while (timeConsumed < .5f);
                dices = Table.Instance.RollDice();
                setDicesFaces(dices, false);
                if (_Table.getCurrentPlayer().isInJail)
                {
                    ActionsActive(true);
                    DicesActive(false);
                    DicesFacesActive();
                }
            }
            StartCoroutine(diceSuffle());
        }

        public void setDicesFaces(int[] dices, bool suffle) //This is for set an actual faces
        {
            if (!suffle)
            {
                switch (dices[0])
                {
                    case 1:
                        dice1Faces[0].SetActive(true);
                        dice1Faces[1].SetActive(false);
                        dice1Faces[2].SetActive(false);
                        dice1Faces[3].SetActive(false);
                        dice1Faces[4].SetActive(false);
                        dice1Faces[5].SetActive(false);
                        break;
                    case 2:
                        dice1Faces[1].SetActive(true);
                        dice1Faces[0].SetActive(false);
                        dice1Faces[2].SetActive(false);
                        dice1Faces[3].SetActive(false);
                        dice1Faces[4].SetActive(false);
                        dice1Faces[5].SetActive(false);
                        break;
                    case 3:
                        dice1Faces[2].SetActive(true);
                        dice1Faces[1].SetActive(false);
                        dice1Faces[0].SetActive(false);
                        dice1Faces[3].SetActive(false);
                        dice1Faces[4].SetActive(false);
                        dice1Faces[5].SetActive(false);
                        break;
                    case 4:
                        dice1Faces[3].SetActive(true);
                        dice1Faces[1].SetActive(false);
                        dice1Faces[2].SetActive(false);
                        dice1Faces[0].SetActive(false);
                        dice1Faces[4].SetActive(false);
                        dice1Faces[5].SetActive(false);
                        break;
                    case 5:
                        dice1Faces[4].SetActive(true);
                        dice1Faces[1].SetActive(false);
                        dice1Faces[2].SetActive(false);
                        dice1Faces[3].SetActive(false);
                        dice1Faces[0].SetActive(false);
                        dice1Faces[5].SetActive(false);
                        break;
                    case 6:
                        dice1Faces[5].SetActive(true);
                        dice1Faces[1].SetActive(false);
                        dice1Faces[2].SetActive(false);
                        dice1Faces[3].SetActive(false);
                        dice1Faces[4].SetActive(false);
                        dice1Faces[0].SetActive(false);
                        break;
                }
                switch (dices[1])
                {
                    case 1:
                        dice2Faces[0].SetActive(true);
                        dice2Faces[1].SetActive(false);
                        dice2Faces[2].SetActive(false);
                        dice2Faces[3].SetActive(false);
                        dice2Faces[4].SetActive(false);
                        dice2Faces[5].SetActive(false);
                        break;
                    case 2:
                        dice2Faces[1].SetActive(true);
                        dice2Faces[0].SetActive(false);
                        dice2Faces[2].SetActive(false);
                        dice2Faces[3].SetActive(false);
                        dice2Faces[4].SetActive(false);
                        dice2Faces[5].SetActive(false);
                        break;
                    case 3:
                        dice2Faces[2].SetActive(true);
                        dice2Faces[1].SetActive(false);
                        dice2Faces[0].SetActive(false);
                        dice2Faces[3].SetActive(false);
                        dice2Faces[4].SetActive(false);
                        dice2Faces[5].SetActive(false);
                        break;
                    case 4:
                        dice2Faces[3].SetActive(true);
                        dice2Faces[1].SetActive(false);
                        dice2Faces[2].SetActive(false);
                        dice2Faces[0].SetActive(false);
                        dice2Faces[4].SetActive(false);
                        dice2Faces[5].SetActive(false);
                        break;
                    case 5:
                        dice2Faces[4].SetActive(true);
                        dice2Faces[1].SetActive(false);
                        dice2Faces[2].SetActive(false);
                        dice2Faces[3].SetActive(false);
                        dice2Faces[0].SetActive(false);
                        dice2Faces[5].SetActive(false);
                        break;
                    case 6:
                        dice2Faces[5].SetActive(true);
                        dice2Faces[1].SetActive(false);
                        dice2Faces[2].SetActive(false);
                        dice2Faces[3].SetActive(false);
                        dice2Faces[4].SetActive(false);
                        dice2Faces[0].SetActive(false);
                        break;
                }
            }

        }

        public void setDicesFaces(int dices, int faces) //This is for set suffling faces
        {
            if (dices == 1)
            {
                switch (faces)
                {
                    case 1:
                        dice1Faces[0].SetActive(true);
                        dice1Faces[1].SetActive(false);
                        dice1Faces[2].SetActive(false);
                        dice1Faces[3].SetActive(false);
                        dice1Faces[4].SetActive(false);
                        dice1Faces[5].SetActive(false);
                        break;
                    case 2:
                        dice1Faces[1].SetActive(true);
                        dice1Faces[0].SetActive(false);
                        dice1Faces[2].SetActive(false);
                        dice1Faces[3].SetActive(false);
                        dice1Faces[4].SetActive(false);
                        dice1Faces[5].SetActive(false);
                        break;
                    case 3:
                        dice1Faces[2].SetActive(true);
                        dice1Faces[1].SetActive(false);
                        dice1Faces[0].SetActive(false);
                        dice1Faces[3].SetActive(false);
                        dice1Faces[4].SetActive(false);
                        dice1Faces[5].SetActive(false);
                        break;
                    case 4:
                        dice1Faces[3].SetActive(true);
                        dice1Faces[1].SetActive(false);
                        dice1Faces[2].SetActive(false);
                        dice1Faces[0].SetActive(false);
                        dice1Faces[4].SetActive(false);
                        dice1Faces[5].SetActive(false);
                        break;
                    case 5:
                        dice1Faces[4].SetActive(true);
                        dice1Faces[1].SetActive(false);
                        dice1Faces[2].SetActive(false);
                        dice1Faces[3].SetActive(false);
                        dice1Faces[0].SetActive(false);
                        dice1Faces[5].SetActive(false);
                        break;
                    case 6:
                        dice1Faces[5].SetActive(true);
                        dice1Faces[1].SetActive(false);
                        dice1Faces[2].SetActive(false);
                        dice1Faces[3].SetActive(false);
                        dice1Faces[4].SetActive(false);
                        dice1Faces[0].SetActive(false);
                        break;
                }
            }
            else if (dices == 2)
            {
                switch (faces)
                {
                    case 1:
                        dice2Faces[0].SetActive(true);
                        dice2Faces[1].SetActive(false);
                        dice2Faces[2].SetActive(false);
                        dice2Faces[3].SetActive(false);
                        dice2Faces[4].SetActive(false);
                        dice2Faces[5].SetActive(false);
                        break;
                    case 2:
                        dice2Faces[1].SetActive(true);
                        dice2Faces[0].SetActive(false);
                        dice2Faces[2].SetActive(false);
                        dice2Faces[3].SetActive(false);
                        dice2Faces[4].SetActive(false);
                        dice2Faces[5].SetActive(false);
                        break;
                    case 3:
                        dice2Faces[2].SetActive(true);
                        dice2Faces[1].SetActive(false);
                        dice2Faces[0].SetActive(false);
                        dice2Faces[3].SetActive(false);
                        dice2Faces[4].SetActive(false);
                        dice2Faces[5].SetActive(false);
                        break;
                    case 4:
                        dice2Faces[3].SetActive(true);
                        dice2Faces[1].SetActive(false);
                        dice2Faces[2].SetActive(false);
                        dice2Faces[0].SetActive(false);
                        dice2Faces[4].SetActive(false);
                        dice2Faces[5].SetActive(false);
                        break;
                    case 5:
                        dice2Faces[4].SetActive(true);
                        dice2Faces[1].SetActive(false);
                        dice2Faces[2].SetActive(false);
                        dice2Faces[3].SetActive(false);
                        dice2Faces[0].SetActive(false);
                        dice2Faces[5].SetActive(false);
                        break;
                    case 6:
                        dice2Faces[5].SetActive(true);
                        dice2Faces[1].SetActive(false);
                        dice2Faces[2].SetActive(false);
                        dice2Faces[3].SetActive(false);
                        dice2Faces[4].SetActive(false);
                        dice2Faces[0].SetActive(false);
                        break;
                }

            }
        }

        public void DicesActive(bool value)
        {
            rollDice.GetComponent<ButtonInteractable>().thisInteractable = value;

            if (_Table.getCurrentPlayer().isBankrupt)
            {
                rollDice.GetComponent<ButtonInteractable>().thisInteractable = false;
                DicesFacesActive();
            }
            //print(_Table.getCurrentPlayer().playerName + " roll bitch");
            if (!_Table.getCurrentPlayer().hasSecondTurn && value && _Table.getCurrentPlayer().isBotPlaying)
            {
                _Table.getCurrentPlayer().currentState = CurrentState.WaitToRoll;
            }
        }

        public void DicesFacesActive()
        {
            if (rollDice.GetComponent<ButtonInteractable>().thisInteractable)
            {
                foreach (var dice in dice1Faces)
                {
                    dice.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
                }
                foreach (var dice in dice2Faces)
                {
                    dice.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
                }
            }
            else 
            {
                foreach (var dice in dice1Faces)
                {
                    dice.GetComponent<Image>().color = new Vector4(1, 1, 1, .5f);
                }
                foreach (var dice in dice2Faces)
                {
                    dice.GetComponent<Image>().color = new Vector4(1, 1, 1, .5f);
                }
            }
        }

        #endregion

        #region Player & Money

        public void setPlayerInfo()
        {
            IEnumerator setInfo()
            {
                yield return new WaitForSeconds(.5f); //Delay for information to load

                if (_Table.numOfPlayers == 2)
                {
                    player1Panel.SetActive(true);
                    player2Panel.SetActive(true);
                    player3Panel.SetActive(false);
                    player4Panel.SetActive(false);
                    //Player 1
                    player1Name.text = Table.Instance.player[0].playerName.ToString().ToUpper();
                    //player1Money.text = Table.Instance.player[0].playerMoney.ToString() + "$";

                    //Player 2
                    player2Name.text = Table.Instance.player[1].playerName.ToString().ToUpper();
                    //player2Money.text = Table.Instance.player[1].playerMoney.ToString() + "$";
                }
                else if (_Table.numOfPlayers == 3)
                {
                    player1Panel.SetActive(true);
                    player2Panel.SetActive(true);
                    player3Panel.SetActive(true);
                    player4Panel.SetActive(false);
                    //Player 1
                    player1Name.text = Table.Instance.player[0].playerName.ToString().ToUpper();
                    //player1Money.text = Table.Instance.player[0].playerMoney.ToString() + "$";

                    //Player 2
                    player2Name.text = Table.Instance.player[1].playerName.ToString().ToUpper();
                    //player2Money.text = Table.Instance.player[1].playerMoney.ToString() + "$";

                    //Player 3
                    player3Name.text = Table.Instance.player[2].playerName.ToString().ToUpper();
                    //player3Money.text = Table.Instance.player[2].playerMoney.ToString() + "$";
                }
                else if (_Table.numOfPlayers == 4)
                {
                    player1Panel.SetActive(true);
                    player2Panel.SetActive(true);
                    player3Panel.SetActive(true);
                    player4Panel.SetActive(true);
                    //Player 1
                    player1Name.text = Table.Instance.player[0].playerName.ToString().ToUpper();
                    //player1Money.text = Table.Instance.player[0].playerMoney.ToString() + "$";

                    //Player 2
                    player2Name.text = Table.Instance.player[1].playerName.ToString().ToUpper();
                    //player2Money.text = Table.Instance.player[1].playerMoney.ToString() + "$";

                    //Player 3
                    player3Name.text = Table.Instance.player[2].playerName.ToString().ToUpper();
                    //player3Money.text = Table.Instance.player[2].playerMoney.ToString() + "$";

                    //Player 4
                    player4Name.text = Table.Instance.player[3].playerName.ToString().ToUpper();
                    //player4Money.text = Table.Instance.player[3].playerMoney.ToString() + "$";
                }

                MoneyUpdate();
            }
            StartCoroutine(setInfo());
        }

        public void setTurn(int playerIndex, bool isSuffle)
        {
            //IEnumerator setTurn()
            //{
            //    //yield return new WaitForSeconds(.5f);
            //    yield return null;

            //}
            //StartCoroutine(setTurn());

            switch (playerIndex)
            {
                case 1:
                    player1CanvasGroup.alpha = 1;
                    player2CanvasGroup.alpha = .5f;
                    player3CanvasGroup.alpha = .5f;
                    player4CanvasGroup.alpha = .5f;
                    break;
                case 2:
                    player1CanvasGroup.alpha = .5f;
                    player2CanvasGroup.alpha = 1;
                    player3CanvasGroup.alpha = .5f;
                    player4CanvasGroup.alpha = .5f;
                    break;
                case 3:
                    player1CanvasGroup.alpha = .5f;
                    player2CanvasGroup.alpha = .5f;
                    player3CanvasGroup.alpha = 1;
                    player4CanvasGroup.alpha = .5f;
                    break;
                case 4:
                    player1CanvasGroup.alpha = .5f;
                    player2CanvasGroup.alpha = .5f;
                    player3CanvasGroup.alpha = .5f;
                    player4CanvasGroup.alpha = 1;
                    break;
                default:
                    break;
            }
            if (!isSuffle)
            {
                if (_Table.getCurrentPlayer().playerMoney >= 0) //fix loi hien xuc xac khi hien panel bankruptcy
                {
                    ActionsActive(true);
                    DicesActive(true);
                    DicesFacesActive();
                }
                else
                {
                    ActionsActive(true);
                    DicesActive(false);
                    DicesFacesActive();
                }
            }
        }

        [Button]
        public void MoneyUpdate()
        {
            Player p1 = _Table.player[0];
            Player p2 = _Table.player[1];
            Player p3 = _Table.player[2];
            Player p4 = _Table.player[3];

            IEnumerator p1Update()
            {
                int CountFPS = 30;
                float Duration = .5f;
                WaitForSeconds Wait = new WaitForSeconds(1f / CountFPS);
                int newValue = p1.playerMoney;
                int previousValue = p1.oldPlayerMoney;
                int stepAmount;
                //print("p1 update: \nold: " + previousValue.ToString() + " new: " + newValue.ToString());

                if (newValue - previousValue < 0)
                {
                    stepAmount = Mathf.FloorToInt((newValue - previousValue) / (CountFPS * Duration));
                }
                else
                {
                    stepAmount = Mathf.CeilToInt((newValue - previousValue) / (CountFPS * Duration));
                }

                if (p1.oldPlayerMoney > p1.playerMoney)
                {
                    p1Lose.Play();
                }
                else if (p1.oldPlayerMoney < p1.PlayerMoney)
                {
                    p1Earn.Play();
                }

                if (previousValue < newValue)
                {
                    while (previousValue < newValue)
                    {
                        previousValue += stepAmount;
                        if (previousValue > newValue)
                        {
                            previousValue = newValue;
                        }

                        player1Money.text = previousValue.ToString("N0");

                        yield return Wait;
                    }
                }
                else
                {
                    while (previousValue > newValue)
                    {
                        previousValue += stepAmount;
                        if (previousValue < newValue)
                        {
                            previousValue = newValue;
                        }

                        player1Money.text = previousValue.ToString("N0");

                        yield return Wait;
                    }
                }
                p1.oldPlayerMoney = p1.playerMoney;
            }

            IEnumerator p2Update()
            {
                int CountFPS = 30;
                float Duration = .5f;
                WaitForSeconds Wait = new WaitForSeconds(1f / CountFPS);
                int newValue = p2.playerMoney;
                int previousValue = p2.oldPlayerMoney;
                int stepAmount;
                //print("p2 update: \nold: " + previousValue.ToString() + " new: " + newValue.ToString());

                if (newValue - previousValue < 0)
                {
                    stepAmount = Mathf.FloorToInt((newValue - previousValue) / (CountFPS * Duration));
                }
                else
                {
                    stepAmount = Mathf.CeilToInt((newValue - previousValue) / (CountFPS * Duration));
                }

                if (p2.oldPlayerMoney > p2.playerMoney)
                {
                    p2Lose.Play();
                }
                else if (p2.oldPlayerMoney < p2.PlayerMoney)
                {
                    p2Earn.Play();
                }

                if (previousValue < newValue)
                {
                    while (previousValue < newValue)
                    {
                        previousValue += stepAmount;
                        if (previousValue > newValue)
                        {
                            previousValue = newValue;
                        }

                        player2Money.text = previousValue.ToString("N0");

                        yield return Wait;
                    }
                }
                else
                {
                    while (previousValue > newValue)
                    {
                        previousValue += stepAmount;
                        if (previousValue < newValue)
                        {
                            previousValue = newValue;
                        }

                        player2Money.text = previousValue.ToString("N0");

                        yield return Wait;
                    }
                }
                p2.oldPlayerMoney = p2.playerMoney;
            }

            IEnumerator p3Update()
            {
                int CountFPS = 30;
                float Duration = .5f;
                WaitForSeconds Wait = new WaitForSeconds(1f / CountFPS);
                int newValue = p3.playerMoney;
                int previousValue = p3.oldPlayerMoney;
                int stepAmount;
                //print("p3 update: \nold: " + previousValue.ToString() + " new: " + newValue.ToString());

                if (newValue - previousValue < 0)
                {
                    stepAmount = Mathf.FloorToInt((newValue - previousValue) / (CountFPS * Duration));
                }
                else
                {
                    stepAmount = Mathf.CeilToInt((newValue - previousValue) / (CountFPS * Duration));
                }

                if (p3.oldPlayerMoney > p3.playerMoney)
                {
                    p3Lose.Play();
                }
                else if (p3.oldPlayerMoney < p3.PlayerMoney)
                {
                    p3Earn.Play();
                }

                if (previousValue < newValue)
                {
                    while (previousValue < newValue)
                    {
                        previousValue += stepAmount;
                        if (previousValue > newValue)
                        {
                            previousValue = newValue;
                        }

                        player3Money.text = previousValue.ToString("N0");

                        yield return Wait;
                    }
                }
                else
                {
                    while (previousValue > newValue)
                    {
                        previousValue += stepAmount;
                        if (previousValue < newValue)
                        {
                            previousValue = newValue;
                        }

                        player3Money.text = previousValue.ToString("N0");

                        yield return Wait;
                    }
                }
                p3.oldPlayerMoney = p3.playerMoney;
            }

            IEnumerator p4Update()
            {
                int CountFPS = 30;
                float Duration = .5f;
                WaitForSeconds Wait = new WaitForSeconds(1f / CountFPS);
                int newValue = p4.playerMoney;
                int previousValue = p4.oldPlayerMoney;
                int stepAmount;
                //print("p4 update: \nold: " + previousValue.ToString() + " new: " + newValue.ToString());

                if (newValue - previousValue < 0)
                {
                    stepAmount = Mathf.FloorToInt((newValue - previousValue) / (CountFPS * Duration));
                }
                else
                {
                    stepAmount = Mathf.CeilToInt((newValue - previousValue) / (CountFPS * Duration));
                }

                if (p4.oldPlayerMoney > p4.playerMoney)
                {
                    p4Lose.Play();
                }
                else if (p4.oldPlayerMoney < p4.PlayerMoney)
                {
                    p4Earn.Play();
                }

                if (previousValue < newValue)
                {
                    while (previousValue < newValue)
                    {
                        previousValue += stepAmount;
                        if (previousValue > newValue)
                        {
                            previousValue = newValue;
                        }

                        player4Money.text = previousValue.ToString("N0");

                        yield return Wait;
                    }
                }
                else
                {
                    while (previousValue > newValue)
                    {
                        previousValue += stepAmount;
                        if (previousValue < newValue)
                        {
                            previousValue = newValue;
                        }

                        player4Money.text = previousValue.ToString("N0");

                        yield return Wait;
                    }
                }
                p4.oldPlayerMoney = p4.playerMoney;
            }

            StartCoroutine(p1Update());
            StartCoroutine(p2Update());
            StartCoroutine(p3Update());
            StartCoroutine(p4Update());

            if (p1.playerMoney > 0 && p1.moneyWarning)
            {
                p1.moneyWarning = false;
                if (p1.hasSecondTurn)
                {
                    DicesActive(true);
                    DicesFacesActive();
                }
                else
                {
                    EndTurnActive(true);
                }
            }

            if (p2.playerMoney > 0 && p2.moneyWarning)
            {
                p2.moneyWarning = false;
                if (p2.hasSecondTurn)
                {
                    DicesActive(true);
                    DicesFacesActive();
                }
                else
                {
                    EndTurnActive(true);
                }
            }

            if (p3.playerMoney > 0 & p3.moneyWarning)
            {
                p3.moneyWarning = false;
                if (p3.hasSecondTurn)
                {
                    DicesActive(true);
                    DicesFacesActive();
                }
                else
                {
                    EndTurnActive(true);
                }
            }

            if (p4.playerMoney > 0 && p4.moneyWarning)
            {
                p4.moneyWarning = false;
                if (p4.hasSecondTurn)
                {
                    DicesActive(true);
                    DicesFacesActive();
                }
                else
                {
                    EndTurnActive(true);
                }
            }
        }

        public void ShowRentPaidUI(Player p_paid, Player p_collect, int amount)
        {
            moneyPanel.SetActive(true);
            paidRentPanel.SetActive(true);

            OnEnable_StandOnPanel(paidRentPanel);

            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            paidRentPanel.transform.position = pos;

            if (p_paid.playerColor == new Vector4(255, 0, 0, 255)) //red
            {
                pp_redPawn.SetActive(true);
                pp_greenPawn.SetActive(false);
                pp_bluePawn.SetActive(false);
                pp_yellowPawn.SetActive(false);
            }
            else if (p_paid.playerColor == new Vector4(0, 0, 255, 255)) //blue
            {
                pp_redPawn.SetActive(false);
                pp_greenPawn.SetActive(false);
                pp_bluePawn.SetActive(true);
                pp_yellowPawn.SetActive(false);
            }
            else if (p_paid.playerColor == new Vector4(0, 255, 0, 255)) //green
            {
                pp_redPawn.SetActive(false);
                pp_greenPawn.SetActive(true);
                pp_bluePawn.SetActive(false);
                pp_yellowPawn.SetActive(false);
            }
            else if (p_paid.playerColor == new Vector4(255, 255, 0, 255)) //yellow
            {
                pp_redPawn.SetActive(false);
                pp_greenPawn.SetActive(false);
                pp_bluePawn.SetActive(false);
                pp_yellowPawn.SetActive(true);
            }

            if (p_collect.playerColor == new Vector4(255, 0, 0, 255)) //red
            {
                cp_redPawn.SetActive(true);
                cp_greenPawn.SetActive(false);
                cp_bluePawn.SetActive(false);
                cp_yellowPawn.SetActive(false);
            }
            else if (p_collect.playerColor == new Vector4(0, 0, 255, 255)) //blue
            {
                cp_redPawn.SetActive(false);
                cp_greenPawn.SetActive(false);
                cp_bluePawn.SetActive(true);
                cp_yellowPawn.SetActive(false);
            }
            else if (p_collect.playerColor == new Vector4(0, 255, 0, 255)) //green
            {
                cp_redPawn.SetActive(false);
                cp_greenPawn.SetActive(true);
                cp_bluePawn.SetActive(false);
                cp_yellowPawn.SetActive(false);
            }
            else if (p_collect.playerColor == new Vector4(255, 255, 0, 255)) //yellow
            {
                cp_redPawn.SetActive(false);
                cp_greenPawn.SetActive(false);
                cp_bluePawn.SetActive(false);
                cp_yellowPawn.SetActive(true);
            }

            paidAmount.text = amount.ToString();

            if (amount >= 0 && amount < 10)
            {
                paidAmountContainer.GetComponent<RectTransform>().localPosition = new Vector2(-33.3f, -6.5765f);
            }
            else if (amount >= 10 && amount < 100)
            {
                paidAmountContainer.GetComponent<RectTransform>().localPosition = new Vector2(-18.2f, -6.5765f);
            }
            else if (amount >= 100 && amount < 1000)
            {
                paidAmountContainer.GetComponent<RectTransform>().localPosition = new Vector2(-7.1f, -6.5765f);
            }
            else if (amount >= 1000)
            { 
                paidAmountContainer.GetComponent<RectTransform>().localPosition = new Vector2(5.5f, -6.5765f);
            }

            IEnumerator wait()
            {
                float timeConsumed = 0f;
                do
                {
                    yield return new WaitForSeconds(.2f);
                    timeConsumed += .2f;
                }
                while (timeConsumed < 1);
                if (bankruptcyPanel.activeSelf)
                {
                    paidRentPanel.SetActive(false);
                    _LiveUpdate.PanelLiveUpdate(paidRentPanel, false);
                }
                else
                {
                    OnDisable_TransparentPanel(paidRentPanel, moneyPanel);
                }
            }
            StartCoroutine(wait());
        }

        //Bankruptcy
        //

        public void ShowBankruptcy(bool isBankrupt)
        {
            DicesActive(false);
            DicesFacesActive();
            EndTurnActive(false);
            if (!isBankrupt)
            {
                Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
                moneyPanel.SetActive(true);
                bankruptcyPanel.SetActive(true);
                OnEnable_StandOnPanel(bankruptcyPanel);
                bankruptcyPanel.transform.position = pos;
                payDebt.GetComponent<ButtonInteractable>().thisInteractable = true;
                bankRupt.GetComponent<ButtonInteractable>().thisInteractable = true;
            }
            else
            {
                Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
                moneyPanel.SetActive(true);
                bankruptcyPanel.SetActive(true);
                OnEnable_StandOnPanel(bankruptcyPanel);
                bankruptcyPanel.transform.position = pos;
                payDebt.GetComponent<ButtonInteractable>().thisInteractable = false;
                bankRupt.GetComponent<ButtonInteractable>().thisInteractable = true;
            }
        }

        public void OnClick_PayDebt()
        {
            OnDisable_Panel(bankruptcyPanel, moneyPanel);
        }

        public void OnClick_Bankrupt()
        {
            //End game Checker
            _Table.getCurrentPlayer().StartBankrupt();
        }

        #endregion 

        #region Actions

        //Active
        //

        public void ActionsActive(bool value)
        {
            build.GetComponent<ButtonInteractable>().thisInteractable = value;
            sell.GetComponent<ButtonInteractable>().thisInteractable = value;
            mortgage.GetComponent<ButtonInteractable>().thisInteractable = value;
            redeem.GetComponent<ButtonInteractable>().thisInteractable = value;
            trade.GetComponent<ButtonInteractable>().thisInteractable = value;
        }

        public void EndTurnActive(bool value)
        {
            endTurn.GetComponent<ButtonInteractable>().thisInteractable = value;
        }

        //On_Click
        //

        public void OnClick_EndTurn()
        {
            Table.Instance.SwitchPlayer();
            EndTurnActive(false);
            OnClick_ActionsClose();
        }

        public void OnClick_Build()
        {
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            mainActionPanel.SetActive(true);
            buildPanel.SetActive(true);
            sellPanel.SetActive(false);
            mortgagePanel.SetActive(false);
            redeemPanel.SetActive(false);
            tradePanel.SetActive(false);

            //fix loi khi an vao nhieu action button cung 1 luc
            build.GetComponent<ButtonInteractable>().thisInteractable = false;
            sell.GetComponent<ButtonInteractable>().thisInteractable = false;
            mortgage.GetComponent<ButtonInteractable>().thisInteractable = false;
            redeem.GetComponent<ButtonInteractable>().thisInteractable = false;
            trade.GetComponent<ButtonInteractable>().thisInteractable = false;

            OnEnable_MainActionsPanel(buildPanel);
            buildPanel.transform.position = pos;

            _Table.Build();
        }

        public void OnClick_Sell()
        {
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            mainActionPanel.SetActive(true);
            buildPanel.SetActive(false);
            sellPanel.SetActive(true);
            mortgagePanel.SetActive(false);
            redeemPanel.SetActive(false);
            tradePanel.SetActive(false);

            //fix loi khi an vao nhieu action button cung 1 luc
            build.GetComponent<ButtonInteractable>().thisInteractable = false;
            sell.GetComponent<ButtonInteractable>().thisInteractable = false;
            mortgage.GetComponent<ButtonInteractable>().thisInteractable = false;
            redeem.GetComponent<ButtonInteractable>().thisInteractable = false;
            trade.GetComponent<ButtonInteractable>().thisInteractable = false;

            OnEnable_MainActionsPanel(sellPanel);
            sellPanel.transform.position = pos;

            _Table.Sell();
        }

        public void OnClick_Mortgage()
        {
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            mainActionPanel.SetActive(true);
            buildPanel.SetActive(false);
            sellPanel.SetActive(false);
            mortgagePanel.SetActive(true);
            redeemPanel.SetActive(false);
            tradePanel.SetActive(false);

            //fix loi khi an vao nhieu action button cung 1 luc
            build.GetComponent<ButtonInteractable>().thisInteractable = false;
            sell.GetComponent<ButtonInteractable>().thisInteractable = false;
            mortgage.GetComponent<ButtonInteractable>().thisInteractable = false;
            redeem.GetComponent<ButtonInteractable>().thisInteractable = false;
            trade.GetComponent<ButtonInteractable>().thisInteractable = false;

            OnEnable_MainActionsPanel(mortgagePanel);
            mortgagePanel.transform.position = pos;

            _Table.Mortgage();
        }

        public void OnClick_Redeem()
        {
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            mainActionPanel.SetActive(true);
            buildPanel.SetActive(false);
            sellPanel.SetActive(false);
            mortgagePanel.SetActive(false);
            redeemPanel.SetActive(true);
            tradePanel.SetActive(false);

            //fix loi khi an vao nhieu action button cung 1 luc
            build.GetComponent<ButtonInteractable>().thisInteractable = false;
            sell.GetComponent<ButtonInteractable>().thisInteractable = false;
            mortgage.GetComponent<ButtonInteractable>().thisInteractable = false;
            redeem.GetComponent<ButtonInteractable>().thisInteractable = false;
            trade.GetComponent<ButtonInteractable>().thisInteractable = false;

            OnEnable_MainActionsPanel(redeemPanel);
            redeemPanel.transform.position = pos;

            _Table.Redeem();
        }

        public void OnClick_Trade()
        {
            mainActionPanel.SetActive(true);
            buildPanel.SetActive(false);
            sellPanel.SetActive(false);
            mortgagePanel.SetActive(false);
            redeemPanel.SetActive(false);
            tradePanel.SetActive(true);

            //fix loi khi an vao nhieu action button cung 1 luc
            build.GetComponent<ButtonInteractable>().thisInteractable = false;
            sell.GetComponent<ButtonInteractable>().thisInteractable = false;
            mortgage.GetComponent<ButtonInteractable>().thisInteractable = false;
            redeem.GetComponent<ButtonInteractable>().thisInteractable = false;
            trade.GetComponent<ButtonInteractable>().thisInteractable = false;

            trade_offerPanel.SetActive(true);
            OnEnable_Trade(trade_offerPanel);
            trade_receivePanel.SetActive(false);
            trade_illegalPanel.SetActive(false);

            //Select trade player
            tradeoffer_title.text = _Table.getCurrentPlayer().playerName + "'s Offer";

            //Select first player to trade
            trade_currentOpppnent = _Table.SwitchWithoutPlayer(_Table.getCurrentPlayer(), _Table.getCurrentPlayer(), true); //Select player to trade
            tradeoffer_selectedPlayer.text = trade_currentOpppnent.playerName;
            tradeoffer_myPlayerMoney.text = "Maximum: " + _Table.getCurrentPlayer().playerMoney + " coin(s)";
            tradeoffer_opponentMoney.text = "Maximum: " + trade_currentOpppnent.playerMoney + " coin(s)";

            //Reset InputField
            Reset_InputField();
            AutoCorrect_InputField();

            //Reset selection

            for (int i = 0; i < tradeoffer_myPlayerContent.childCount; i++)
            {
                Destroy(tradeoffer_myPlayerContent.GetChild(i).gameObject);
            }

            for (int i = 0; i < tradeoffer_opponentContent.childCount; i++)
            {
                Destroy(tradeoffer_opponentContent.GetChild(i).gameObject);
            }

            _Table.ShowTradeItem(_Table.getCurrentPlayer(), tradeoffer_myPlayerContent, trade_property, false);
            _Table.ShowTradeItem(trade_currentOpppnent, tradeoffer_opponentContent, trade_property, true);
        }

        public void OnClick_Trade_PrevPlayer()
        {
            for (int i = 0; i < tradeoffer_opponentContent.childCount; i++)
            {
                Destroy(tradeoffer_opponentContent.GetChild(i).gameObject);
            }

            trade_currentOpppnent = _Table.SwitchWithoutPlayer(trade_currentOpppnent, _Table.getCurrentPlayer(), false);
            tradeoffer_selectedPlayer.text = trade_currentOpppnent.playerName;
            tradeoffer_opponentMoney.text = "Maximum: " + trade_currentOpppnent.playerMoney + " coin(s)";
            _Table.ShowTradeItem(trade_currentOpppnent, tradeoffer_opponentContent, trade_property, true);
            AutoCorrect_InputField();
        }

        public void OnClick_Trade_NextPlayer()
        {

            for (int i = 0; i < tradeoffer_opponentContent.childCount; i++)
            {
                Destroy(tradeoffer_opponentContent.GetChild(i).gameObject);
            }

            trade_currentOpppnent = _Table.SwitchWithoutPlayer(trade_currentOpppnent, _Table.getCurrentPlayer(), true);
            tradeoffer_selectedPlayer.text = trade_currentOpppnent.playerName;
            tradeoffer_opponentMoney.text = "Maximum: " + trade_currentOpppnent.playerMoney + " coin(s)";
            _Table.ShowTradeItem(trade_currentOpppnent, tradeoffer_opponentContent, trade_property, true);
            AutoCorrect_InputField();
        }

        public void OnClick_Trade_Offer()
        {
            int myPlayerProp = 0;
            foreach (PropertyCard card in GetTradeOffer(true))
            {
                myPlayerProp++;
            }
            int opponentProp = 0;
            foreach (PropertyCard card in GetTradeOffer(false))
            {
                opponentProp++;
            }

            if (tradeoffer_myPlayerMoneyValue.text == "" && tradeoffer_opponentMoneyValue.text == "") //both of money value is null => props trade
            {
                if (myPlayerProp != 0 && opponentProp != 0) //props trade
                {
                    ShowTradeReceive();
                    return;
                }
                else //none of them are choosen
                {
                    ShowIllegalTrade();
                }
            }
            else if (tradeoffer_myPlayerMoneyValue.text != "" && tradeoffer_opponentMoneyValue.text == "") //opponent money is null
            {
                if (opponentProp != 0 && int.Parse(tradeoffer_myPlayerMoneyValue.text) != 0) //opponent have props, and myPlayer money is more than 0
                {
                    ShowTradeReceive();
                }
                else //opponent have props, and myPlayer money is less than 0
                {
                    ShowIllegalTrade();
                }
            }
            else if (tradeoffer_myPlayerMoneyValue.text == "" && tradeoffer_opponentMoneyValue.text != "") //myPlayer money is null
            {
                if (myPlayerProp != 0 && int.Parse(tradeoffer_opponentMoneyValue.text) != 0) //myPlayer have props, and opponent money is more than 0
                {
                    ShowTradeReceive();
                }
                else //myPlayer have props, and opponent money is less than 0
                {
                    ShowIllegalTrade();
                }
            }
            else if (tradeoffer_myPlayerMoneyValue.text != "" && tradeoffer_opponentMoneyValue.text != "") //nothing is null
            {
                if (int.Parse(tradeoffer_myPlayerMoneyValue.text) != 0 && int.Parse(tradeoffer_opponentMoneyValue.text) != 0) //myPlayer have props, and opponent money is more than 0
                {
                    ShowTradeReceive();
                }
                else //myPlayer have props, and opponent money is less than 0
                {
                    ShowIllegalTrade();
                }
            }
        }

        public void OnClick_Trade_Accept()
        {
            for (int i = 0; i < tradereceive_myPlayerContent.childCount; i++)
            {
                if (tradereceive_myPlayerContent.GetChild(i).GetComponent<PropertyCard>().propCardIndex == -1) //-1 equals jailFree card
                {
                    _Table.getCurrentPlayer().RemoveJailFreeCard();
                    trade_currentOpppnent.AddJailFreeCard();
                }
                else
                {
                    Slot tempSlot = _Table.getSlot(tradereceive_myPlayerContent.GetChild(i).GetComponent<PropertyCard>().propCardIndex);
                    _Table.getCurrentPlayer().slotOwned.Remove(tempSlot);
                    trade_currentOpppnent.slotOwned.Add(tempSlot);
                    tempSlot.forcedSetOwner(trade_currentOpppnent);
                }
            }

            if (tradeoffer_myPlayerMoneyValue.text == "")
            {
                _Table.PlayerPayForPlayer(_Table.getCurrentPlayer(), trade_currentOpppnent, 0);
            }
            else
            {
                _Table.PlayerPayForPlayer(_Table.getCurrentPlayer(), trade_currentOpppnent, int.Parse(tradeoffer_myPlayerMoneyValue.text));
            }

            for (int i = 0; i < tradereceive_opponentContent.childCount; i++)
            {
                if (tradereceive_opponentContent.GetChild(i).GetComponent<PropertyCard>().propCardIndex == -1) //-1 equals jailFree card
                {
                    _Table.getCurrentPlayer().AddJailFreeCard();
                    trade_currentOpppnent.RemoveJailFreeCard();
                }
                else
                {
                    Slot tempSlot = _Table.getSlot(tradereceive_opponentContent.GetChild(i).GetComponent<PropertyCard>().propCardIndex);
                    _Table.getCurrentPlayer().slotOwned.Add(tempSlot);
                    trade_currentOpppnent.slotOwned.Remove(tempSlot);
                    tempSlot.forcedSetOwner(_Table.getCurrentPlayer());
                }
            }

            if (tradeoffer_opponentMoneyValue.text == "")
            {
                _Table.PlayerPayForPlayer(trade_currentOpppnent, _Table.getCurrentPlayer(), 0);
            }
            else
            {
                _Table.PlayerPayForPlayer(trade_currentOpppnent, _Table.getCurrentPlayer(), int.Parse(tradeoffer_opponentMoneyValue.text));
            }

            OnClick_ActionsClose();
            ShowTradeResult(true);
        }

        public void OnClick_Trade_Decline()
        {
            ShowTradeResult(false);
            OnClick_ActionsClose();
        }

        public void OnClick_ActionsClose()
        {
            if (buildPanel.activeSelf || sellPanel.activeSelf || mortgagePanel.activeSelf || redeemPanel.activeSelf || tradePanel.activeSelf)
            {
                build.GetComponent<ButtonInteractable>().thisInteractable = true;
                sell.GetComponent<ButtonInteractable>().thisInteractable = true;
                mortgage.GetComponent<ButtonInteractable>().thisInteractable = true;
                redeem.GetComponent<ButtonInteractable>().thisInteractable = true;
                trade.GetComponent<ButtonInteractable>().thisInteractable = true;
            }

            OnClick_CloseOnClickInformation();


            if (!tradePanel.activeSelf && (buildPanel.activeSelf || sellPanel.activeSelf || mortgagePanel.activeSelf || redeemPanel.activeSelf))
            {
                _Table.ShowSlot();
            }
            else
            {
                OnDisable_TransparentPanel(trade_illegalPanel, tradePanel);
                OnDisable_TransparentPanel(trade_receivePanel, tradePanel);
                OnDisable_TransparentPanel(trade_offerPanel, tradePanel);
            }

            OnDisable_TransparentPanel(buildPanel, mainActionPanel);
            OnDisable_TransparentPanel(sellPanel, mainActionPanel);
            OnDisable_TransparentPanel(mortgagePanel, mainActionPanel);
            OnDisable_TransparentPanel(redeemPanel, mainActionPanel);

            foreach (GameObject slot in _Table.slot)
            {
                slot.GetComponent<Slot>().slotAction = SlotAction.Idle;
            }
        }

        //Other Methods
        //
        public PropertyCard[] GetTradeOffer(bool isMyPlayer)
        {
            if (isMyPlayer)
            {
                List<PropertyCard> myPlayerProperty = new List<PropertyCard>();

                for (int i = 0; i < tradeoffer_myPlayerContent.childCount; i++)
                {
                    if (tradeoffer_myPlayerContent.GetChild(i).GetComponent<PropertyCard>().isSelected)
                    {
                        if (tradeoffer_myPlayerContent.GetChild(i).GetComponent<PropertyCard>().propertyType == PropertyType.ColorProperty)
                        {
                            myPlayerProperty.Add(tradeoffer_myPlayerContent.GetChild(i).GetComponent<PropertyCard>());
                            print("color props");
                        }
                        else if (tradeoffer_myPlayerContent.GetChild(i).GetComponent<PropertyCard>().propertyType == PropertyType.SpecialProperty)
                        {
                            myPlayerProperty.Add(tradeoffer_myPlayerContent.GetChild(i).GetComponent<PropertyCard>());
                            print("special props");
                        }
                        else if (tradeoffer_myPlayerContent.GetChild(i).GetComponent<PropertyCard>().propertyType == PropertyType.JailFree)
                        {
                            myPlayerProperty.Add(tradeoffer_myPlayerContent.GetChild(i).GetComponent<PropertyCard>());
                            print("jail free");
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                return myPlayerProperty.ToArray();
            }

            else
            {
                List<PropertyCard> opponentProperty = new List<PropertyCard>();

                for (int i = 0; i < tradeoffer_opponentContent.childCount; i++)
                {
                    if (tradeoffer_opponentContent.GetChild(i).GetComponent<PropertyCard>().isSelected)
                    {
                        if (tradeoffer_opponentContent.GetChild(i).GetComponent<PropertyCard>().propertyType == PropertyType.ColorProperty)
                        {
                            opponentProperty.Add(tradeoffer_opponentContent.GetChild(i).GetComponent<PropertyCard>());
                            print("color props");
                        }
                        else if (tradeoffer_opponentContent.GetChild(i).GetComponent<PropertyCard>().propertyType == PropertyType.SpecialProperty)
                        {
                            opponentProperty.Add(tradeoffer_opponentContent.GetChild(i).GetComponent<PropertyCard>());
                            print("special props");
                        }
                        else if (tradeoffer_opponentContent.GetChild(i).GetComponent<PropertyCard>().propertyType == PropertyType.JailFree)
                        {
                            opponentProperty.Add(tradeoffer_opponentContent.GetChild(i).GetComponent<PropertyCard>());
                            print("jail free");
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                return opponentProperty.ToArray();
            }
        }

        public void ShowIllegalTrade()
        {
            trade_illegalPanel.SetActive(true);
            OnEnable_Trade(trade_illegalPanel);
            trade_offerPanel.SetActive(false);
            trade_receivePanel.SetActive(false);
        }

        public void ShowTradeReceive()
        {
            trade_receivePanel.SetActive(true);
            OnEnable_Trade(trade_receivePanel);
            trade_offerPanel.SetActive(false);
            trade_illegalPanel.SetActive(false);

            tradereceive_title.text = _Table.getCurrentPlayer().playerName + "'s Offer";

            //Destroy old item
            for (int i = 0; i < tradereceive_myPlayerContent.childCount; i++)
            {
                Destroy(tradereceive_myPlayerContent.GetChild(i).gameObject);
            }

            for (int i = 0; i < tradereceive_opponentContent.childCount; i++)
            {
                Destroy(tradereceive_opponentContent.GetChild(i).gameObject);
            }

            //Generate new item
            foreach (PropertyCard card in GetTradeOffer(true))
            {
                GameObject temp = Instantiate(card.gameObject, tradereceive_myPlayerContent);
                temp.GetComponent<PropertyCard>().isTrade = false;
                temp.GetComponent<PropertyCard>().tradeLeft = true;
                temp.GetComponent<PropertyCard>().selectedMask.SetActive(false);
            }

            foreach (PropertyCard card in GetTradeOffer(false))
            {
                GameObject temp = Instantiate(card.gameObject, tradereceive_opponentContent);
                temp.GetComponent<PropertyCard>().isTrade = false;
                temp.GetComponent<PropertyCard>().tradeLeft = false;
                temp.GetComponent<PropertyCard>().selectedMask.SetActive(false);
            }

            //Money part
            if (tradeoffer_myPlayerMoneyValue.text == "" || tradeoffer_myPlayerMoneyValue.text == "0")
            {
                tradereceive_myPlayerMoney.text = "0";
                tradereceive_myPlayerMoney_Container.GetComponent<RectTransform>().localPosition = ContainerSetPos(1, true);
            }
            else
            {
                tradereceive_myPlayerMoney.text = tradeoffer_myPlayerMoneyValue.text;
                if (int.Parse(tradeoffer_myPlayerMoneyValue.text) >= 0 && int.Parse(tradeoffer_myPlayerMoneyValue.text) < 10)
                {
                    tradereceive_myPlayerMoney_Container.GetComponent<RectTransform>().localPosition = ContainerSetPos(1, true);
                }
                else if (int.Parse(tradeoffer_myPlayerMoneyValue.text) >= 10 && int.Parse(tradeoffer_myPlayerMoneyValue.text) < 100)
                {
                    tradereceive_myPlayerMoney_Container.GetComponent<RectTransform>().localPosition = ContainerSetPos(2, true);
                }
                else if (int.Parse(tradeoffer_myPlayerMoneyValue.text) >= 100 && int.Parse(tradeoffer_myPlayerMoneyValue.text) < 1000)
                {
                    tradereceive_myPlayerMoney_Container.GetComponent<RectTransform>().localPosition = ContainerSetPos(3, true);
                }
                else if (int.Parse(tradeoffer_myPlayerMoneyValue.text) >= 1000 && int.Parse(tradeoffer_myPlayerMoneyValue.text) < 10000)
                {
                    tradereceive_myPlayerMoney_Container.GetComponent<RectTransform>().localPosition = ContainerSetPos(4, true);
                }
                else if (int.Parse(tradeoffer_myPlayerMoneyValue.text) >= 10000)
                {
                    tradereceive_myPlayerMoney_Container.GetComponent<RectTransform>().localPosition = ContainerSetPos(5, true);
                }
            }

            if (tradeoffer_opponentMoneyValue.text == "" || tradeoffer_opponentMoneyValue.text == "0")
            {
                tradereceive_opponentMoney.text = "0";
                tradereceive_opponentMoney_Container.GetComponent<RectTransform>().localPosition = ContainerSetPos(1, false);
            }
            else
            {
                tradereceive_opponentMoney.text = tradeoffer_opponentMoneyValue.text;
                if (int.Parse(tradeoffer_opponentMoneyValue.text) >= 0 && int.Parse(tradeoffer_opponentMoneyValue.text) < 10)
                {
                    tradereceive_opponentMoney_Container.GetComponent<RectTransform>().localPosition = ContainerSetPos(1, false);
                }
                else if (int.Parse(tradeoffer_opponentMoneyValue.text) >= 10 && int.Parse(tradeoffer_opponentMoneyValue.text) < 100)
                {
                    tradereceive_opponentMoney_Container.GetComponent<RectTransform>().localPosition = ContainerSetPos(2, false);
                }
                else if (int.Parse(tradeoffer_opponentMoneyValue.text) >= 100 && int.Parse(tradeoffer_opponentMoneyValue.text) < 1000)
                {
                    tradereceive_opponentMoney_Container.GetComponent<RectTransform>().localPosition = ContainerSetPos(3, false);
                }
                else if (int.Parse(tradeoffer_opponentMoneyValue.text) >= 1000 && int.Parse(tradeoffer_opponentMoneyValue.text) < 10000)
                {
                    tradereceive_opponentMoney_Container.GetComponent<RectTransform>().localPosition = ContainerSetPos(4, false);
                }
                else if (int.Parse(tradeoffer_opponentMoneyValue.text) >= 10000)
                {
                    tradereceive_opponentMoney_Container.GetComponent<RectTransform>().localPosition = ContainerSetPos(5, false);
                }
            }

            Vector2 ContainerSetPos(int numOfChar, bool isLeft)
            {
                if (isLeft)
                {
                    if (numOfChar == 1)
                    {
                        return new Vector2(-277.8f, -536f);
                    }
                    else if (numOfChar == 2)
                    {
                        return new Vector2(-266.5f, -536f);
                    }
                    else if (numOfChar == 3)
                    {
                        return new Vector2(-255.8f, -536f);
                    }
                    else if (numOfChar == 4)
                    {
                        return new Vector2(-242.6f, -536f);
                    }
                    else
                    {
                        return new Vector2(-228.5f, -536f);
                    }
                }
                else
                {
                    if (numOfChar == 1)
                    {
                        return new Vector2(170.2f, -536f);
                    }
                    else if (numOfChar == 2)
                    {
                        return new Vector2(183.3f, -536f);
                    }
                    else if (numOfChar == 3)
                    {
                        return new Vector2(197.4f, -536f);
                    }
                    else if (numOfChar == 4)
                    {
                        return new Vector2(210.1f, -536f);
                    }
                    else
                    {
                        return new Vector2(222.1f, -536f);
                    }
                }
            }
        }

        public void AutoCorrect_InputField()
        {
            if (tradeoffer_myPlayerMoneyValue.text == "")
            {
                //tradeoffer_myPlayerMoneyValue.text = "0";
            }
            else if (int.Parse(tradeoffer_myPlayerMoneyValue.text) > _Table.getCurrentPlayer().playerMoney)
            {
                tradeoffer_myPlayerMoneyValue.text = _Table.getCurrentPlayer().playerMoney.ToString();
            }
            //print(int.Parse(tradeoffer_myPlayerMoneyValue.text + "myplayermoney"));

            if (tradeoffer_opponentMoneyValue.text == "")
            {
                //tradeoffer_opponentMoneyValue.text = "0";
            }
            else if (int.Parse(tradeoffer_opponentMoneyValue.text) > trade_currentOpppnent.playerMoney)
            {
                tradeoffer_opponentMoneyValue.text = trade_currentOpppnent.playerMoney.ToString();
            }
            //print(int.Parse(tradeoffer_opponentMoneyValue.text + "opponent"));
        }

        public void Reset_InputField()
        {
            tradeoffer_myPlayerMoneyValue.text = "";
            tradeoffer_opponentMoneyValue.text = "";
        }

        #endregion

        #region Information Card on Table 
        public void ShowInformationCard(int slotNumber)
        {
            Slot_Type type;
            type = _Table.getSlot(slotNumber).slotType;
            OnClick_CloseOnClickInformation();
            if (type == Slot_Type.ColorProperty)
            {
                ShowColorPropertyCard(slotNumber);
            }
            else if (type == Slot_Type.SpecialProperty)
            {
                ShowSpecialPropertyCard(slotNumber);
            }
            else if (type == Slot_Type.SupriseSlot)
            {
                ShowSupriseCard(slotNumber);
            }
            else if (type == Slot_Type.CornerSlot)
            {
                ShowCornerCard(slotNumber);
            }
        }

        //Color Property Information Card
        //

        public void ShowColorPropertyCard(int slotNumber)
        {
            standOnInformationPanel.SetActive(true);
            colorPropertyInformationCard.SetActive(true);

            supriseInformationCard.SetActive(false);
            specialPropertyInformationCard.SetActive(false);

            cpi_showButtonPanel.SetActive(true);
            cpi_boughtPanel.SetActive(false);

            OnEnable_StandOnPanel(colorPropertyInformationCard);
            Vector2 pos  = Camera.main.WorldToScreenPoint(_Table.transform.position);
            cpi_showButtonPanel.SetActive(true);
            cpi_boughtPanel.SetActive(false);
            _Table.getCurrentPlayer().currentState = CurrentState.BuyOrAuction;


            if (_Table.getCurrentPlayer().playerMoney < _Table.getSlot(_Table.getCurrentPlayer().currentSlot).getSlotPrice()) //can't afford
            {
                cpi_buyButton.GetComponent<ButtonInteractable>().thisInteractable = false;
                cpi_auctionButton.GetComponent<ButtonInteractable>().thisInteractable = true;
            }
            else
            {
                cpi_buyButton.GetComponent<ButtonInteractable>().thisInteractable = true;
                cpi_auctionButton.GetComponent<ButtonInteractable>().thisInteractable = true;
            }

            colorPropertyInformationCard.transform.position = pos;
            cpi_colorPropertyCard.ShowCard(slotNumber);
        }

        public void ShowColorPropertyBought()
        {
            standOnInformationPanel.SetActive(true);
            colorPropertyInformationCard.SetActive(true);
            cpi_showButtonPanel.SetActive(false);
            cpi_boughtPanel.SetActive(true);
            OnEnable_StandOnPanel(colorPropertyInformationCard);
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            colorPropertyInformationCard.transform.position = pos;
            //cpi_buyer.text = _Table.getSlot(slotNumber).getOwner().playerName;


            if (_Table.getCurrentPlayer() == _Table.player[0])
            {
                cpi_redPawn.SetActive(true);
                cpi_bluePawn.SetActive(false);
                cpi_greenPawn.SetActive(false);
                cpi_yellowPawn.SetActive(false);
                cpi_buyer.text = _Table.player[0].playerName;
            }
            else if (_Table.getCurrentPlayer() == _Table.player[1])
            {
                cpi_redPawn.SetActive(false);
                cpi_bluePawn.SetActive(true);
                cpi_greenPawn.SetActive(false);
                cpi_yellowPawn.SetActive(false);
                cpi_buyer.text = _Table.player[1].playerName;
            }
            else if (_Table.getCurrentPlayer() == _Table.player[2])
            {
                cpi_redPawn.SetActive(false);
                cpi_bluePawn.SetActive(false);
                cpi_greenPawn.SetActive(true);
                cpi_yellowPawn.SetActive(false);
                cpi_buyer.text = _Table.player[2].playerName;
            }
            else if (_Table.getCurrentPlayer() == _Table.player[3])
            {
                cpi_redPawn.SetActive(false);
                cpi_bluePawn.SetActive(false);
                cpi_greenPawn.SetActive(false);
                cpi_yellowPawn.SetActive(true);
                cpi_buyer.text = _Table.player[3].playerName;
            }

            IEnumerator wait()
            {
                float timeConsumed = 0f;
                do
                {
                    yield return new WaitForSeconds(1.5f);
                    timeConsumed = 1.5f;
                }
                while (timeConsumed < 1.5f);
                OnDisable_Panel(colorPropertyInformationCard, standOnInformationPanel);
                HideInformationCard();
            }
            StartCoroutine(wait());
        }

        //Special Property Information Card
        //

        public void ShowSpecialPropertyCard(int slotNumber)
        {
            standOnInformationPanel.SetActive(true);
            specialPropertyInformationCard.SetActive(true);

            colorPropertyInformationCard.SetActive(false);
            supriseInformationCard.SetActive(false);

            ut_showButtonPanel.SetActive(true);
            ut_boughtPanel.SetActive(false);

            OnEnable_StandOnPanel(specialPropertyInformationCard);
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            specialPropertyInformationCard.transform.position = pos;
            ut_showButtonPanel.SetActive(true);
            ut_boughtPanel.SetActive(false);
            _Table.getCurrentPlayer().currentState = CurrentState.BuyOrAuction;

            if (_Table.getCurrentPlayer().playerMoney < _Table.getSlot(_Table.getCurrentPlayer().currentSlot).getSlotPrice()) //can't afford
            {
                sp_buyButton.GetComponent<ButtonInteractable>().thisInteractable = false;
                sp_auctionButton.GetComponent<ButtonInteractable>().thisInteractable = true;
            }
            else
            {
                sp_buyButton.GetComponent<ButtonInteractable>().thisInteractable = true;
                sp_auctionButton.GetComponent<ButtonInteractable>().thisInteractable = true;
            }

            sp_specialPropertyCard.ShowCard(slotNumber);
        }

        public void ShowSpecialPropertyBought()
        {
            standOnInformationPanel.SetActive(true);
            specialPropertyInformationCard.SetActive(true);
            ut_showButtonPanel.SetActive(false);
            ut_boughtPanel.SetActive(true);
            OnEnable_StandOnPanel(specialPropertyInformationCard);
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            specialPropertyInformationCard.transform.position = pos;



            if (_Table.getCurrentPlayer() == _Table.player[0])
            {
                ut_redPawn.SetActive(true);
                ut_bluePawn.SetActive(false);
                ut_greenPawn.SetActive(false);
                ut_yellowPawn.SetActive(false);
                ut_buyer.text = _Table.player[0].playerName;
            }
            else if (_Table.getCurrentPlayer() == _Table.player[1])
            {
                ut_redPawn.SetActive(false);
                ut_bluePawn.SetActive(true);
                ut_greenPawn.SetActive(false);
                ut_yellowPawn.SetActive(false);
                ut_buyer.text = _Table.player[1].playerName;
            }
            else if (_Table.getCurrentPlayer() == _Table.player[2])
            {
                ut_redPawn.SetActive(false);
                ut_bluePawn.SetActive(false);
                ut_greenPawn.SetActive(true);
                ut_yellowPawn.SetActive(false);
                ut_buyer.text = _Table.player[2].playerName;
            }
            else if (_Table.getCurrentPlayer() == _Table.player[3])
            {
                ut_redPawn.SetActive(false);
                ut_bluePawn.SetActive(false);
                ut_greenPawn.SetActive(false);
                ut_yellowPawn.SetActive(true);
                ut_buyer.text = _Table.player[3].playerName;
            }

            IEnumerator wait()
            {
                float timeConsumed = 0f;
                do
                {
                    yield return new WaitForSeconds(1.5f);
                    timeConsumed = 1.5f;
                }
                while (timeConsumed < 1.5f);
                OnDisable_Panel(specialPropertyInformationCard, standOnInformationPanel);
                HideInformationCard();
            }
            StartCoroutine(wait());
        }

        //Suprise Information Card
        //

        public void ShowSupriseCard(int slotNumber)
        {
            float timeConsumed = 0;
            int chanceCardNumber = _Table.getSlot(slotNumber).supriseSlot.DrawChance();
            int communityChestNumber = _Table.getSlot(slotNumber).supriseSlot.DrawCommunityChest();
            standOnInformationPanel.SetActive(true);
            supriseInformationCard.SetActive(true);

            colorPropertyInformationCard.SetActive(false);
            specialPropertyInformationCard.SetActive(false);

            OnEnable_StandOnPanel(supriseInformationCard);
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            supriseInformationCard.transform.position = pos;


            StartCoroutine(actions());

            IEnumerator actions()
            {
                do
                {
                    if (_Table.getSlot(slotNumber).supriseSlot.slotType == SupriseSlot_Type.Chance)
                    {
                        chanceAndCommunityChestInformation.SetActive(true);
                        taxInformation.SetActive(false);

                        cc_communityChestImage.SetActive(false);
                        cc_chanceImage.SetActive(true);

                        switch (chanceCardNumber)
                        {
                            case 0:
                                cc_description.text = "Advance to Allah";
                                break;
                            case 1:
                                cc_description.text = "Advance to Olympus (Collect 200 Coins)";
                                break;
                            case 2:
                                cc_description.text = "Advance to Horus. If you pass Olympus, collect 200 Coins";
                                break;
                            case 3:
                                cc_description.text = "Advance to Eros Place. If you pass Olympus, collect 200 Coins";
                                break;
                            case 4:
                                cc_description.text = "Advance to the nearest Holy Road. If unowned, you may claim it from the gods. If owned, pay the owner twice the tribute to which they are otherwise entitled.";
                                break;
                            case 5:
                                cc_description.text = "Advance to the nearest Holy Road. If unowned, you may claim it from the gods. If owned, pay the owner twice the tribute to which they are otherwise entitled.";
                                break;
                            case 6:
                                cc_description.text = "Advance token to nearest worship place. If unowned, you may consult it from the gods. If owned, throw dice and pay owner a total ten times amount thrown.";
                                break;
                            case 7:
                                cc_description.text = "The gods reward you with 50 Coins";
                                break;
                            case 8:
                                cc_description.text = "Escape from Tartarus Free";
                                break;
                            case 9:
                                cc_description.text = "The Fates rewind your fate by 3 Spaces";
                                break;
                            case 10:
                                cc_description.text = "Go to Tartarus. Go directly to Tartarus, do not pass Olympus, do not collect 200 Coins";
                                break;
                            case 11:
                                cc_description.text = "Make offerings to the gods for all your property. For each house pay 25 Coins. For each hotel pay 100 Coins";
                                break;
                            case 12:
                                cc_description.text = "Hermes charges you $15 for using his winged sandals";
                                break;
                            case 13:
                                cc_description.text = "Take a trip to Rainbow Bridge. If you pass Olympus, collect 200 Coins";
                                break;
                            case 14:
                                cc_description.text = "You have been elected King of the Gods. Pay each player 50 Coins";
                                break;
                            case 15:
                                cc_description.text = "Your temple construction is complete. Collect 150 Coins";
                                break;
                            default:
                                break;
                        }
                    }
                    else if (_Table.getSlot(slotNumber).supriseSlot.slotType == SupriseSlot_Type.CommunityChest)
                    {
                        chanceAndCommunityChestInformation.SetActive(true);
                        taxInformation.SetActive(false);

                        cc_communityChestImage.SetActive(true);
                        cc_chanceImage.SetActive(false);

                        switch (communityChestNumber)
                        {
                            case 0:
                                cc_description.text = "Advance to Olympus (Collect 200 Coins)";
                                break;
                            case 1:
                                cc_description.text = "Divine favor in your favor. Collect 200 Coins";
                                break;
                            case 2:
                                cc_description.text = "Healing fee. Pay 50 Coins";
                                break;
                            case 3:
                                cc_description.text = "From trade with Midas you get 50 Coins";
                                break;
                            case 4:
                                cc_description.text = "Escape from Tartarus Free";
                                break;
                            case 5:
                                cc_description.text = "Go to Tartarus. Go directly to Tartarus, do not pass Olympus, do not collect 200 Coins";
                                break;
                            case 6:
                                cc_description.text = "Festival fund matures. Receive 100 Coins";
                                break;
                            case 7:
                                cc_description.text = "Caesar’s tribute. Collect 20 Coins";
                                break;
                            case 8:
                                cc_description.text = "It is your feast day. Collect 10 Coins from every player";
                                break;
                            case 9:
                                cc_description.text = "Reincarnation bonus. Collect 100 Coins";
                                break;
                            case 10:
                                cc_description.text = "Pay healing fees of 100 Coins";
                                break;
                            case 11:
                                cc_description.text = "Pay academy fees of 50 Coins";
                                break;
                            case 12:
                                cc_description.text = "Receive 25 Coins prophecy fee";
                                break;
                            case 13:
                                cc_description.text = "You are assessed for temple repair. 40 Coins per house. 115 Coins per hotel";
                                break;
                            case 14:
                                cc_description.text = "You have impressed Aphrodite with your charm. Collect 10 Coins";
                                break;
                            case 15:
                                cc_description.text = "You receive a blessing from your ancestors. Collect 100 Coins";
                                break;
                            default:
                                break;
                        }
                    }
                    else if (_Table.getSlot(slotNumber).supriseSlot.slotType == SupriseSlot_Type.Tax)
                    {

                        chanceAndCommunityChestInformation.SetActive(false);
                        taxInformation.SetActive(true);

                        if (_Table.getSlot(slotNumber).supriseSlot.taxPrice == 100)
                        {
                            t_title.text = "GOD OFFERING";
                            t_description.text = "PAY 100 COINS";
                        }
                        else if (_Table.getSlot(slotNumber).supriseSlot.taxPrice == 200)
                        {
                            t_title.text = "GOD OFFERING";
                            t_description.text = "PAY 200 COINS";
                        }
                    }
                    yield return new WaitForSeconds(.2f);

                    timeConsumed += .2f;
                }
                while (timeConsumed < 1.5f);

                if (timeConsumed > 1.5f)
                {
                    OnClick_Done();
                }
            }
        }

        public void ShowGoToJail()
        {
            _Table.getCurrentPlayer().setIsInJail(true);
            _Table.getCurrentPlayer().setLateMove(10, false);

            jailPanel.SetActive(true);
            goToJailPanel.SetActive(true);
            OnEnable_StandOnPanel(goToJailPanel);
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            goToJailPanel.transform.position = pos;


            if (_Table.getCurrentPlayer().playerColor == new Vector4(255, 0, 0, 255)) //red
            {
                gtj_redPawn.SetActive(true);
                gtj_greenPawn.SetActive(false);
                gtj_bluePawn.SetActive(false);
                gtj_yellowPawn.SetActive(false);
            }
            else if (_Table.getCurrentPlayer().playerColor == new Vector4(0, 0, 255, 255)) //blue
            {
                gtj_redPawn.SetActive(false);
                gtj_greenPawn.SetActive(false);
                gtj_bluePawn.SetActive(true);
                gtj_yellowPawn.SetActive(false);
            }
            else if (_Table.getCurrentPlayer().playerColor == new Vector4(0, 255, 0, 255)) //green
            {
                gtj_redPawn.SetActive(false);
                gtj_greenPawn.SetActive(true);
                gtj_bluePawn.SetActive(false);
                gtj_yellowPawn.SetActive(false);
            }
            else if (_Table.getCurrentPlayer().playerColor == new Vector4(255, 255, 0, 255)) //yellow
            {
                gtj_redPawn.SetActive(false);
                gtj_greenPawn.SetActive(false);
                gtj_bluePawn.SetActive(false);
                gtj_yellowPawn.SetActive(true);
            }

            float timeConsumed = 0;

            IEnumerator actions()
            {
                do
                {
                    yield return new WaitForSeconds(.2f);
                    timeConsumed += .2f;
                }
                while (timeConsumed < 1.5f);

                if (timeConsumed > 1.5f)
                {
                    OnClick_Done();
                }
            }

            StartCoroutine(actions());
        }

        public void ShowCornerCard(int slotNumber)
        {
            if (_Table.getSlot(slotNumber).cornerSlot.slotType == CornerSlot_Type.GoToJail)
            {
                _Table.getCurrentPlayer().setIsInJail(true);
                _Table.getCurrentPlayer().setLateMove(10, false);

                jailPanel.SetActive(true);
                goToJailPanel.SetActive(true);
                OnEnable_StandOnPanel(goToJailPanel);
                Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
                goToJailPanel.transform.position = pos;


                if (_Table.getCurrentPlayer().playerColor == new Vector4(255, 0, 0, 255)) //red
                {
                    gtj_redPawn.SetActive(true);
                    gtj_greenPawn.SetActive(false);
                    gtj_bluePawn.SetActive(false);
                    gtj_yellowPawn.SetActive(false);
                }
                else if (_Table.getCurrentPlayer().playerColor == new Vector4(0, 0, 255, 255)) //blue
                {
                    gtj_redPawn.SetActive(false);
                    gtj_greenPawn.SetActive(false);
                    gtj_bluePawn.SetActive(true);
                    gtj_yellowPawn.SetActive(false);
                }
                else if (_Table.getCurrentPlayer().playerColor == new Vector4(0, 255, 0, 255)) //green
                {
                    gtj_redPawn.SetActive(false);
                    gtj_greenPawn.SetActive(true);
                    gtj_bluePawn.SetActive(false);
                    gtj_yellowPawn.SetActive(false);
                }
                else if (_Table.getCurrentPlayer().playerColor == new Vector4(255, 255, 0, 255)) //yellow
                {
                    gtj_redPawn.SetActive(false);
                    gtj_greenPawn.SetActive(false);
                    gtj_bluePawn.SetActive(false);
                    gtj_yellowPawn.SetActive(true);
                }

                float timeConsumed = 0;

                IEnumerator actions()
                {
                    do
                    {
                        yield return new WaitForSeconds(.2f);
                        timeConsumed += .2f;
                    }
                    while (timeConsumed < 1.5f);

                    if (timeConsumed > 1.5f)
                    {
                        OnClick_Done();
                    }
                }

                StartCoroutine(actions());
            }
            else if (_Table.getSlot(slotNumber).cornerSlot.slotType == CornerSlot_Type.VisitingJail)
            {
                float timeConsumed = 0;


                if (!_Table.getCurrentPlayer().isInJail)
                {
                    jailPanel.SetActive(true);
                    visitingJailPanel.SetActive(true);
                    OnEnable_StandOnPanel(visitingJailPanel);
                    Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
                    visitingJailPanel.transform.position = pos;


                    if (_Table.getCurrentPlayer().playerColor == new Vector4(255, 0, 0, 255)) //red
                    {
                        vj_redPawn.SetActive(true);
                        vj_greenPawn.SetActive(false);
                        vj_bluePawn.SetActive(false);
                        vj_yellowPawn.SetActive(false);
                    }
                    else if (_Table.getCurrentPlayer().playerColor == new Vector4(0, 0, 255, 255)) //blue
                    {
                        vj_redPawn.SetActive(false);
                        vj_greenPawn.SetActive(false);
                        vj_bluePawn.SetActive(true);
                        vj_yellowPawn.SetActive(false);
                    }
                    else if (_Table.getCurrentPlayer().playerColor == new Vector4(0, 255, 0, 255)) //green
                    {
                        vj_redPawn.SetActive(false);
                        vj_greenPawn.SetActive(true);
                        vj_bluePawn.SetActive(false);
                        vj_yellowPawn.SetActive(false);
                    }
                    else if (_Table.getCurrentPlayer().playerColor == new Vector4(255, 255, 0, 255)) //yellow
                    {
                        vj_redPawn.SetActive(false);
                        vj_greenPawn.SetActive(false);
                        vj_bluePawn.SetActive(false);
                        vj_yellowPawn.SetActive(true);
                    }
                }

                IEnumerator actions()
                {
                    do
                    {
                        yield return new WaitForSeconds(.2f);
                        timeConsumed += .2f;
                    }
                    while (timeConsumed < 1.5f);

                    if (timeConsumed > 1.5f)
                    {
                        OnClick_Done();
                    }
                }

                if (!_Table.getCurrentPlayer().isInJail)
                {
                    StartCoroutine(actions());
                }
            }
        }

        public void ShowIsInJail()
        {
            jailPanel.SetActive(true);
            inJailPanel.SetActive(true);
            OnEnable_StandOnPanel(inJailPanel);
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            inJailPanel.transform.position = pos;


            if (_Table.getCurrentPlayer().playerColor == new Vector4(255, 0, 0, 255)) //red
            {
                ij_redPawn.SetActive(true);
                ij_greenPawn.SetActive(false);
                ij_bluePawn.SetActive(false);
                ij_yellowPawn.SetActive(false);
            }
            else if (_Table.getCurrentPlayer().playerColor == new Vector4(0, 0, 255, 255)) //blue
            {
                ij_redPawn.SetActive(false);
                ij_greenPawn.SetActive(false);
                ij_bluePawn.SetActive(true);
                ij_yellowPawn.SetActive(false);
            }
            else if (_Table.getCurrentPlayer().playerColor == new Vector4(0, 255, 0, 255)) //green
            {
                ij_redPawn.SetActive(false);
                ij_greenPawn.SetActive(true);
                ij_bluePawn.SetActive(false);
                ij_yellowPawn.SetActive(false);
            }
            else if (_Table.getCurrentPlayer().playerColor == new Vector4(255, 255, 0, 255)) //yellow
            {
                ij_redPawn.SetActive(false);
                ij_greenPawn.SetActive(false);
                ij_bluePawn.SetActive(false);
                ij_yellowPawn.SetActive(true);
            }

            //Pay Button
            if (_Table.getCurrentPlayer().playerMoney > 100)
            {
                ij_Pay.GetComponent<ButtonInteractable>().thisInteractable = true;
            }
            else
            {
                ij_Pay.GetComponent<ButtonInteractable>().thisInteractable = false;
            }

            //Use Card
            if (_Table.getCurrentPlayer().numberJailFreeCard > 0)
            {
                ij_useCard.GetComponent<ButtonInteractable>().thisInteractable = true;
            }
            else
            {
                ij_useCard.GetComponent<ButtonInteractable>().thisInteractable = false;
            }
        }

        public void ShowAuction(int slotNumber, Player currentPlayer, int currentPrice, Player playerWithHighestBid)
        {
            auctionPanel.SetActive(true);
        
            foreach (Player p in _Table.player)
            {
                if (!p.isBankrupt && p.gameObject.activeSelf) //them active self
                {
                    p.inAuction = true;
                }
            }

            OnEnable_Auction(auctionInformationPanel); //enable panel

            //set position for panel
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            auctionInformationPanel.transform.position = pos; 

            //Set card information
            if (_Table.getSlot(slotNumber).slotType == Slot_Type.ColorProperty)
            {
                ai_colorPropertyCard.gameObject.SetActive(true);
                ai_specialPropertyCard.gameObject.SetActive(false);

                ai_colorPropertyCard.ShowCard(slotNumber);
            }
            else if (_Table.getSlot(slotNumber).slotType == Slot_Type.SpecialProperty)
            {
                ai_colorPropertyCard.gameObject.SetActive(false);
                ai_specialPropertyCard.gameObject.SetActive(true);

                ai_specialPropertyCard.ShowCard(slotNumber);
            }

            //turn on buttons with cooldown
            StartCoroutine(buttonCooldown());

            //update currentPlayer and currentPrice
            ai_currentPlayerTurn.text = currentPlayer.playerName;
            if (playerWithHighestBid == null)
            {
                ai_currentPrice.text = currentPrice.ToString();

                if (currentPrice >= 0 && currentPrice < 10)
                {
                    ai_currentPrice_Container.GetComponent<RectTransform>().localPosition = TextSetPos(1);
                }
                else if (currentPrice >= 10 && currentPrice < 100)
                {
                    ai_currentPrice_Container.GetComponent<RectTransform>().localPosition = TextSetPos(2);
                }
                else if (currentPrice >= 100 && currentPrice < 1000)
                {
                    ai_currentPrice_Container.GetComponent<RectTransform>().localPosition = TextSetPos(3);
                }
                else if (currentPrice >= 1000 && currentPrice < 10000)
                {
                    ai_currentPrice_Container.GetComponent<RectTransform>().localPosition = TextSetPos(4);
                }
                else 
                {
                    ai_currentPrice_Container.GetComponent<RectTransform>().localPosition = TextSetPos(5);
                }

                ai_currentPrice_Player.text = "NONE";
            }
            else
            {
                ai_currentPrice.text = currentPrice.ToString();

                if (currentPrice >= 0 && currentPrice < 10)
                {
                    ai_currentPrice_Container.GetComponent<RectTransform>().localPosition = TextSetPos(1);
                }
                else if (currentPrice >= 10 && currentPrice < 100)
                {
                    ai_currentPrice_Container.GetComponent<RectTransform>().localPosition = TextSetPos(2);
                }
                else if (currentPrice >= 100 && currentPrice < 1000)
                {
                    ai_currentPrice_Container.GetComponent<RectTransform>().localPosition = TextSetPos(3);
                }
                else if (currentPrice >= 1000 && currentPrice < 10000)
                {
                    ai_currentPrice_Container.GetComponent<RectTransform>().localPosition = TextSetPos(4);
                }
                else
                {
                    ai_currentPrice_Container.GetComponent<RectTransform>().localPosition = TextSetPos(5);
                }

                ai_currentPrice_Player.text = playerWithHighestBid.playerName;
            }

            Vector2 TextSetPos(int numOfChar)
            {
                if (numOfChar == 1)
                {
                    return new Vector2(-34f, 0f);
                }
                else if (numOfChar == 2)
                {
                    return new Vector2(-28.3f, 0f);
                }
                else if (numOfChar == 3)
                {
                    return new Vector2(-18.7f, 0f);
                }
                else if (numOfChar == 4)
                {
                    return new Vector2(-9.6f, 0f);
                }
                else
                {
                    return new Vector2(0f, 0f);
                }
            } //Set Position for Price + Image

            IEnumerator buttonCooldown() //Set cooldown for buttons
            {
                ai_smallBid.GetComponent<ButtonInteractable>().thisInteractable = false;
                ai_bigBid.GetComponent<ButtonInteractable>().thisInteractable = false;
                ai_withdraw.GetComponent<ButtonInteractable>().thisInteractable = false;

                yield return new WaitForSeconds(.5f);

                if (currentPlayer.playerMoney < currentPrice + 10) //just can withdraw
                {
                    ai_smallBid.GetComponent<ButtonInteractable>().thisInteractable = false;
                    ai_bigBid.GetComponent<ButtonInteractable>().thisInteractable = false;
                    ai_withdraw.GetComponent<ButtonInteractable>().thisInteractable = true;
                }
                else if (currentPlayer.playerMoney < currentPrice + 100) //can small bid
                {
                    ai_smallBid.GetComponent<ButtonInteractable>().thisInteractable = true;
                    ai_bigBid.GetComponent<ButtonInteractable>().thisInteractable = false;
                    ai_withdraw.GetComponent<ButtonInteractable>().thisInteractable = true;
                }
                else //can big bid
                {
                    ai_smallBid.GetComponent<ButtonInteractable>().thisInteractable = true;
                    ai_bigBid.GetComponent<ButtonInteractable>().thisInteractable = true;
                    ai_withdraw.GetComponent<ButtonInteractable>().thisInteractable = true;
                }
            }
        }
    
        public void CloseAuction(int slotNumber, Player playerWin, Player playerStart, int currentPrice, bool isWin)
        {
            ai_smallBid.GetComponent<ButtonInteractable>().thisInteractable = false;
            ai_bigBid.GetComponent<ButtonInteractable>().thisInteractable = false;
            ai_withdraw.GetComponent<ButtonInteractable>().thisInteractable = false;

            if (isWin)
            {
                StartCoroutine(start());
                IEnumerator start()
                {
                    standOnInformationPanel.SetActive(false);
                    OnDisable_PanelForcedClose(auctionInformationPanel, auctionPanel);
                    yield return new WaitForSeconds(.5f);
                    playerWin.notShowJail = true;
                    _Table.SwitchPlayer(playerWin);

                    if (_Table.getSlot(slotNumber).slotType == Slot_Type.ColorProperty)
                    {
                        cpi_colorPropertyCard.ChangeSlotPrice(currentPrice);
                    }
                    else if (_Table.getSlot(slotNumber).slotType == Slot_Type.SpecialProperty)
                    {
                        sp_specialPropertyCard.ChangeSlotPrice(currentPrice);
                    }

                    _Table.Buy(slotNumber, currentPrice);
                    playerWin.notShowJail = false;
                    _Table.SwitchPlayer(playerStart);

                    foreach (Player p in _Table.player) //reset lai luojt tham gia auction cua nguoi choi
                    {
                        p.joinAuction = true;
                        p.inAuction = false;
                    }

                    if (playerStart.hasSecondTurn) //sua loi hien xuc sac khi dau gia xong
                    {
                        DicesActive(true);
                        DicesFacesActive();
                    }
                    else
                    {
                        DicesActive(false);
                        DicesFacesActive();
                    }
                }
            }
            else
            {
                standOnInformationPanel.SetActive(false);
                OnDisable_PanelForcedClose(auctionInformationPanel, auctionPanel);
                _Table.SwitchPlayer(playerStart);
                HideInformationCard();
            }

            foreach (Player p in _Table.player) //reset lai luojt tham gia auction cua nguoi choi
            {
                p.joinAuction = true;
                p.inAuction = false;
            }

            if (playerStart.hasSecondTurn) //sua loi hien xuc sac khi dau gia xong
            {
                DicesActive(true);
                DicesFacesActive();
            }
            else
            {
                DicesActive(false);
                DicesFacesActive();
            }

            _Table.auc_playerWithHighestBid = null; //fix loi khi dau gia xong van con luu lai playerWithHighestBid cu
        }

        //On-Click
        //

        public void OnClick_Buy()
        {
            _Table.Buy();
        }

        public void OnClick_Auction() 
        {
            _Table.AuctionStart();
        }

        public void OnClick_Auction_SmallBid()
        {
            _Table.Auction_SmallBid();
        }

        public void OnClick_Auction_BigBid()
        {
            _Table.Auction_BigBid();
        }

        public void OnClick_Auction_Withdraw()
        {
            _Table.Auction_Withdraw();
        }

        public void OnClick_Done() //For suprise card
        {
            HideInformationCard();
            //Then move player if needed
            _Table.getCurrentPlayer().LateMove();
        }

        public void OnClick_JailPay()
        {
            _Table.JailPay();
        }

        public void OnClick_JailUseCard()
        {
            _Table.JailUseCard();
        }

        public void OnClick_JailRollDouble()
        {
            _Table.JailRollDouble();
        }

        //On Click Show Information Card
        //

        public void OnClick_ShowInformationCard(Slot tempSlot)
        {
            if (tempSlot.slotType == Slot_Type.ColorProperty)
            {
                OCShowColorPropertyCard(tempSlot);
            }
            else if (tempSlot.slotType == Slot_Type.SpecialProperty)
            {
                OCShowSpecialPropertyCard(tempSlot);
            }
        }

        public void OCShowColorPropertyCard(Slot tempSlot)
        {
            Onclick_InformationPanel.SetActive(true);
            Onclick_ColorPropertyInformationCard.SetActive(true);
            OnEnable_OnClickPanel(Onclick_ColorPropertyInformationCard);
            Onclick_SpecialPropertyInformationCard.SetActive(false);

            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            Onclick_ColorPropertyInformationCard.transform.position = pos;

            oc_colorPropertyCard.ShowCard(tempSlot.slotIndex);
        }

        public void OCShowSpecialPropertyCard(Slot tempSlot)
        {
            Onclick_InformationPanel.SetActive(true);
            Onclick_SpecialPropertyInformationCard.SetActive(true);
            OnEnable_OnClickPanel(Onclick_SpecialPropertyInformationCard);
            Onclick_ColorPropertyInformationCard.SetActive(false);

            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            Onclick_SpecialPropertyInformationCard.transform.position = pos;

            oc_specialPropertyCard.ShowCard(tempSlot.slotIndex);
        } 

        public void OnClick_CloseOnClickInformation()
        {
            OnDisable_TransparentPanel(Onclick_SpecialPropertyInformationCard, Onclick_InformationPanel);
            OnDisable_TransparentPanel(Onclick_ColorPropertyInformationCard, Onclick_InformationPanel);
        }

        public void HideInformationCard()
        {
            if (!inJailPanel.activeSelf)
            {
                _Table.getCurrentPlayer().currentState = CurrentState.AfterSelection;
            }
            //Stand-on Card
            OnDisable_Panel(colorPropertyInformationCard, standOnInformationPanel);
            OnDisable_Panel(specialPropertyInformationCard, standOnInformationPanel);
            OnDisable_Panel(supriseInformationCard, standOnInformationPanel);

            //Jail
            OnDisable_Panel(inJailPanel, jailPanel);
            OnDisable_Panel(goToJailPanel, jailPanel);
            OnDisable_Panel(visitingJailPanel, jailPanel);

            MoneyUpdate();
            //_Table.getCurrentPlayer().CheckBankruptcy();
            //StopAllCoroutines();
        }

        #endregion

        //Trade Result
        public void ShowTradeResult(bool isAccept)
        {
            IEnumerator start()
            {
                if (isAccept)
                {
                    tr_decline.SetActive(false);
                    tradeResultPanel.SetActive(true);
                    tr_accept.SetActive(true); 
                    OnEnable_Trade(tr_accept);
                    tr_accept.transform.position = Camera.main.WorldToScreenPoint(_Table.transform.position);
                    yield return new WaitForSeconds(1f);
                    OnDisable_PanelForcedClose(tr_accept, tradeResultPanel);
                }
                else
                {
                    tr_accept.SetActive(false);
                    tradeResultPanel.SetActive(true);
                    tr_decline.SetActive(true);
                    OnEnable_Trade(tr_decline);
                    tr_decline.transform.position = Camera.main.WorldToScreenPoint(_Table.transform.position);
                    yield return new WaitForSeconds(1f);
                    OnDisable_PanelForcedClose(tr_decline, tradeResultPanel);
                }
            }
            StartCoroutine(start());
        }

        //Show Board
        //
        public void PointerDown_ShowBoard_Trade()
        {
            StopAllCoroutines();
            IEnumerator start()
            {
                for (float f = 0; f <= .2f; f += Time.deltaTime)
                {
                    trade_canvasGroup.alpha = Mathf.Lerp(1f, 0f, f / .15f);
                    yield return null;
                }
            }
            StartCoroutine(start());
        }

        public void PointerUp_ShowBoard_Trade()
        {
            StopAllCoroutines();
            IEnumerator start()
            {
                for (float f = 0; f <= .2f; f += Time.deltaTime)
                {
                    trade_canvasGroup.alpha = Mathf.Lerp(0f, 1f, f / .15f);
                    yield return null;
                }
            }
            StartCoroutine(start());

        }

        public void PointerDown_ShowBoard_Auction()
        {
            StopAllCoroutines();
            IEnumerator start()
            {
                for (float f = 0; f <= .2f; f += Time.deltaTime)
                {
                    auctionCanvasGroup.alpha = Mathf.Lerp(1f, 0f, f / .15f);
                    standOnInformationCasvasGroup.alpha = Mathf.Lerp(1f, 0f, f / .15f);
                    yield return null;
                }
            }
            StartCoroutine(start());
        }

        public void PointerUp_ShowBoard_Auction()
        {
            StopAllCoroutines();
            IEnumerator start()
            {
                for (float f = 0; f <= .2f; f += Time.deltaTime)
                {
                    auctionCanvasGroup.alpha = Mathf.Lerp(0f, 1f, f / .15f);
                    standOnInformationCasvasGroup.alpha = Mathf.Lerp(0f, 1f, f / .15f);
                    yield return null;
                }
            }
            StartCoroutine(start());

        }

        //Scale panel
        //


        public Vector2 Scale_InformationPanel()
        {
            if (_Table.GetScreenRatio() >= 0.46f && _Table.GetScreenRatio() < 0.48f)
            {
                return new Vector2(1.04f, 1.04f);
            }
            else if (_Table.GetScreenRatio() >= 0.48f && _Table.GetScreenRatio() < 0.5f)
            {
                return new Vector2(0.98f, 0.98f);
            }
            else if (_Table.GetScreenRatio() >= 0.5f)
            {
                return new Vector2(.85f, .85f);
            }
            else
            {
                return Vector2.one;
            }
        }

        public Vector2 Scale_MainActionsPanel()
        {
            if (_Table.GetScreenRatio() >= 0.46f && _Table.GetScreenRatio() < 0.48f)
            {
                return new Vector2(.94f, .94f);
            }
            else if (_Table.GetScreenRatio() >= 0.48f && _Table.GetScreenRatio() < 0.5f)
            {
                return new Vector2(.88f, .88f);
            }
            else if (_Table.GetScreenRatio() >= 0.5f)
            {
                return new Vector2(.76f, .76f);
            }
            else
            {
                return Vector2.one;
            }
        }

        public Vector2 Scale_OnClickPanel()
        {
            if (_Table.GetScreenRatio() < 0.45f)
            {
                return new Vector2(1.55f, 1.55f);
            }
            else if (_Table.GetScreenRatio() >= 0.46f && _Table.GetScreenRatio() < 0.48f)
            {
                return new Vector2(1.5f, 1.5f);
            }
            else if (_Table.GetScreenRatio() >= 0.48f && _Table.GetScreenRatio() < 0.5f)
            {
                return new Vector2(1.45f, 1.45f);
            }
            else if (_Table.GetScreenRatio() >= 0.5f)
            {
                return new Vector2(1.25f, 1.25f);
            }
            else
            {
                return Vector2.one;
            }
        }

        public Vector2 Scale_AuctionPanel()
        {
            //Scaling
            if (_Table.GetScreenRatio() >= 0.46f && _Table.GetScreenRatio() < 0.48f)
            {
                return new Vector2(1.5f, 1.5f);
            }
            else if (_Table.GetScreenRatio() >= 0.48f && _Table.GetScreenRatio() < 0.5f)
            {
                return new Vector2(1.45f, 1.45f);
            }
            else if (_Table.GetScreenRatio() >= 0.5f)
            {
                return new Vector2(1.25f, 1.25f);
            }
            else
            {
                return Vector2.one;
            }
        }

        //Panel Animation
        //

        public void OnEnable_StandOnPanel(GameObject panel)
        {
            if (panel.activeSelf)
            {
                print(panel.name + " Open is Child of" + panel.transform.parent.name);
                _LiveUpdate.PanelLiveUpdate(panel, true);

            }

            //panel.SetActive(true);
            //Vector2 oldScale = panel.transform.localScale;
            panel.transform.localScale = new Vector2(0, 0);
            panel.transform.LeanScale(Scale_InformationPanel(), .25f).setEaseOutBack();
            if (panel == paidRentPanel && _Table.getCurrentPlayer().isBotPlaying)
            {
                _Table.getCurrentPlayer().currentState = CurrentState.AfterSelection;
            }
            if (panel == inJailPanel && _Table.getCurrentPlayer().isBotPlaying)
            {
                IEnumerator action()
                {
                    yield return new WaitForSeconds(1);
                    _Table.getCurrentPlayer().currentState = CurrentState.JailSelect;
                }
                StartCoroutine(action());   
            }
        }

        public void OnEnable_MainActionsPanel(GameObject panel)
        {
            if (panel.activeSelf)
            {
                print(panel.name + " Open is Child of" + panel.transform.parent.name);
                _LiveUpdate.PanelLiveUpdate(panel, true);

            }

            //panel.SetActive(true);
            //Vector2 oldScale = panel.transform.localScale;
            panel.transform.localScale = new Vector2(0, 0);
            panel.transform.LeanScale(Scale_MainActionsPanel(), .25f).setEaseOutBack();
        }

        public void OnEnable_Auction(GameObject panel)
        {
            if (!panel.activeSelf)
            {
                print(panel.name + " Open is Child of" + panel.transform.parent.name);
                _LiveUpdate.PanelLiveUpdate(panel, true);

            }

            if (!panel.activeSelf)
            {
                auctionInformationPanel.SetActive(true);
                panel.transform.localScale = new Vector2(0, 0);
                panel.transform.LeanScale(new Vector2(1, 1), .25f).setEaseOutBack();
            }
        }

        public void OnEnable_Trade(GameObject panel)
        {
            if (panel.activeSelf)
            {
                print(panel.name + " Open is Child of" + panel.transform.parent.name);
                _LiveUpdate.PanelLiveUpdate(panel, true);

            }

            panel.transform.localScale = new Vector2(0, 0);
            panel.transform.LeanScale(new Vector2(1, 1), .25f).setEaseOutBack();
        }

        public void OnEnable_OnClickPanel(GameObject panel)
        {
            if (panel.activeSelf)
            {
                print(panel.name + " Open is Child of" + panel.transform.parent.name);
                _LiveUpdate.PanelLiveUpdate(panel, true);

            }

            panel.transform.localScale = new Vector2(0, 0);
            panel.transform.LeanScale(Scale_OnClickPanel(), .25f).setEaseOutBack();
        }

        public void OnEnable_OnClick_TradeResult(GameObject panel)
        {
            if (panel.activeSelf)
            {
                print(panel.name + " Open is Child of" + panel.transform.parent.name);
                _LiveUpdate.PanelLiveUpdate(panel, true);

            }

            panel.transform.localScale = new Vector2(0, 0);
            panel.transform.LeanScale(Vector2.one, .25f).setEaseOutBack();
            panel.GetComponent<RectTransform>().localPosition = Vector2.zero;
        }

        public void OnDisable_Panel(GameObject panel, GameObject parentPanel)
        {
            if (panel.activeSelf)
            {
                print(panel.name + " Close is Child of" + panel.transform.parent.name);
                _LiveUpdate.PanelLiveUpdate(panel, false);
            }

            panel.transform.LeanScale(new Vector2(0, 0), .25f).setEaseInBack().setOnComplete(() =>
            {
                panel.SetActive(false);
                IEnumerator start()
                {
                    for (float f = 0; f <= .2f; f += Time.deltaTime)
                    {
                        parentPanel.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Lerp(0.3529412f, 0f, f / .15f));
                        //standOnInformationCasvasGroup.alpha = Mathf.Lerp(0f, 1f, f / .15f);
                        yield return null;
                    }
                    parentPanel.SetActive(false);
                }
                StartCoroutine(start());
            });

        }

        public void OnDisable_TransparentPanel(GameObject panel, GameObject parentPanel)
        {
            if (panel.activeSelf)
            {
                print(panel.name + " Close is Child of" + panel.transform.parent.name);
                _LiveUpdate.PanelLiveUpdate(panel, false);
            }

            panel.transform.LeanScale(new Vector2(0, 0), .25f).setEaseInBack().setOnComplete(() => { panel.SetActive(false); parentPanel.SetActive(false); });
        }

        public void OnDisable_PanelForcedClose(GameObject panel, GameObject parentPanel)
        {
            if (panel.activeSelf)
            {
                print(panel.name + " Close is Child of" + panel.transform.parent.name);
                _LiveUpdate.PanelLiveUpdate(panel, false);
            }

            panel.transform.LeanScale(new Vector2(0, 0), .25f).setEaseInBack().setOnComplete(() =>
            {
                panel.SetActive(false);
                IEnumerator start()
                {
                    for (float f = 0; f <= .2f; f += Time.deltaTime)
                    {
                        parentPanel.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Lerp(0.3529412f, 0f, f / .15f));
                        //standOnInformationCasvasGroup.alpha = Mathf.Lerp(0f, 1f, f / .15f);
                        yield return null;
                    }
                    parentPanel.SetActive(false);
                }
                StartCoroutine(start());
            });
        }

        //Scoreboard
        //
        public void ShowScoreboard()
        {
            scoreboardPanel.SetActive(true);
            OnEnable_OnClick_TradeResult(scoreboardPanel_children);

            if (_Table.numOfPlayers == 2)
            {
                scb_1st_Panel.SetActive(true);
                scb_2nd_Panel.SetActive(true);
                scb_3rd_Panel.SetActive(false);
                scb_4th_Panel.SetActive(false);
                foreach (var p in _Table.player)
                {
                    if (p.playerRanking == 1)
                    {
                        scb_1st_Name.text = p.playerName.ToUpper();
                        scb_1st_Profile.SetProfile(p);
                    }

                    if (p.playerRanking == 2)
                    {
                        scb_2nd_Name.text = p.playerName.ToUpper();
                        scb_2nd_Profile.SetProfile(p);
                    }
                }
            }
            else if (_Table.numOfPlayers == 3)
            {
                scb_1st_Panel.SetActive(true);
                scb_2nd_Panel.SetActive(true);
                scb_3rd_Panel.SetActive(true);
                scb_4th_Panel.SetActive(false);
                foreach (var p in _Table.player)
                {
                    if (p.playerRanking == 1)
                    {
                        scb_1st_Name.text = p.playerName.ToUpper();
                        scb_1st_Profile.SetProfile(p);
                    }

                    if (p.playerRanking == 2)
                    {
                        scb_2nd_Name.text = p.playerName.ToUpper();
                        scb_2nd_Profile.SetProfile(p);
                    }

                    if (p.playerRanking == 3)
                    {
                        scb_2nd_Name.text = p.playerName.ToUpper();
                        scb_2nd_Profile.SetProfile(p);
                    }
                }
            }
            else if (_Table.numOfPlayers == 4)
            {

                scb_1st_Panel.SetActive(true);
                scb_2nd_Panel.SetActive(true);
                scb_3rd_Panel.SetActive(true);
                scb_4th_Panel.SetActive(false);
                foreach (var p in _Table.player)
                {
                    if (p.playerRanking == 1)
                    {
                        scb_1st_Name.text = p.playerName.ToUpper();
                        scb_1st_Profile.SetProfile(p);
                    }

                    if (p.playerRanking == 2)
                    {
                        scb_2nd_Name.text = p.playerName.ToUpper();
                        scb_2nd_Profile.SetProfile(p);
                    }

                    if (p.playerRanking == 3)
                    {
                        scb_3rd_Name.text = p.playerName.ToUpper();
                        scb_3rd_Profile.SetProfile(p);
                    }

                    if (p.playerRanking == 4)
                    {
                        scb_4th_Name.text = p.playerName.ToUpper();
                        scb_4th_Profile.SetProfile(p);
                    }

                }
            }
        }

        //Restart game
        //
        public void OnClick_RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
