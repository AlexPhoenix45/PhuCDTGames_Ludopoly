using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Table
    public Table _Table;

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

    [Header("Player 1")]
    [Header("Players")]
    public GameObject player1Panel;
    public Text player1Name;
    public Text player1Money;

    [Header("Player 2")]
    public GameObject player2Panel;
    public Text player2Name;
    public Text player2Money;

    [Header("Player 3")]
    public GameObject player3Panel;
    public Text player3Name;
    public Text player3Money;

    [Header("Player 4")]
    public GameObject player4Panel;
    public Text player4Name;
    public Text player4Money;

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
    public TextMeshProUGUI cc_description;
    public GameObject cc_communityChestImage;
    public GameObject cc_chanceImage;

    public GameObject taxInformation;
    public TextMeshProUGUI t_title;
    public TextMeshProUGUI t_description;

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
    public TextMeshProUGUI paidAmount;

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
    public TextMeshProUGUI ai_currentPlayerTurn;
    public TextMeshProUGUI ai_currentPrice;
    public Button ai_smallBid;
    public Button ai_bigBid;
    public Button ai_withdraw;

    [Header("Auction - Card Template")]
    public GameObject acp_brownCard;
    public GameObject acp_blueCard;
    public GameObject acp_greenCard;
    public GameObject acp_orangeCard;
    public GameObject acp_pinkCard;
    public GameObject acp_purpleCard;
    public GameObject acp_redCard;
    public GameObject acp_yellowCard;

    [Header("Auction - Information Color Property")]
    public GameObject acp_colorPropertyPanel;
    public TextMeshProUGUI acp_propertyName;
    public TextMeshProUGUI acp_rentPrice;
    public TextMeshProUGUI acp_rentDescription;
    public TextMeshProUGUI acp_house1;
    public TextMeshProUGUI acp_house2;
    public TextMeshProUGUI acp_house3;
    public TextMeshProUGUI acp_house4;
    public TextMeshProUGUI acp_hotel;
    public TextMeshProUGUI acp_buildPrice;
    public TextMeshProUGUI acp_mortgagePrice;

    [Header("Auction - Special Property")]
    public GameObject asp_specialPropertyPanel;
    public GameObject asp_railroad_Panel;
    public TextMeshProUGUI asp_rr_propertyName;

    [Header("Auction - Utilities Information")]
    public GameObject asp_utilities_Panel;
    public TextMeshProUGUI asp_ut_propertyName;
    public GameObject asp_ut_waterWorks_Image;
    public GameObject asp_ut_electricCompany_Image;

    [Header("Trade")]
    public GameObject tradePanel;
    public GameObject trade_offerPanel;
    public GameObject trade_receivePanel;
    public GameObject trade_illegalPanel;
    public CanvasGroup trade_canvasGroup;

    [Header("Trade - Offer Panel")]
    public TextMeshProUGUI tradeoffer_title;
    public TextMeshProUGUI tradeoffer_selectedPlayer;
    public Transform tradeoffer_myPlayerContent;
    public Transform tradeoffer_opponentContent;
    public TextMeshProUGUI tradeoffer_myPlayerMoney;
    public TextMeshProUGUI tradeoffer_opponentMoney;
    public TMP_InputField tradeoffer_myPlayerMoneyValue;
    public TMP_InputField tradeoffer_opponentMoneyValue;
    public GameObject trade_property;
    Player trade_currentOpppnent;

    [Header("Trade - Receive Panel")]
    public TextMeshProUGUI tradereceive_title;
    public Transform tradereceive_myPlayerContent;
    public Transform tradereceive_opponentContent;
    public TextMeshProUGUI tradereceive_myPlayerMoney;
    public TextMeshProUGUI tradereceive_opponentMoney;

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
                int diceFace1 = Random.Range(0, 6);
                int diceFace2 = Random.Range(0, 6);
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
        rollDice.interactable = value;
    }

    public void DicesFacesActive()
    {
        if (rollDice.interactable)
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
                player1Panel.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                player2Panel.GetComponent<Image>().color = new Color(1, 1, 1, .4f);
                player3Panel.GetComponent<Image>().color = new Color(1, 1, 1, .4f);
                player4Panel.GetComponent<Image>().color = new Color(1, 1, 1, .4f);
                break;
            case 2:
                player2Panel.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                player1Panel.GetComponent<Image>().color = new Color(1, 1, 1, .4f);
                player3Panel.GetComponent<Image>().color = new Color(1, 1, 1, .4f);
                player4Panel.GetComponent<Image>().color = new Color(1, 1, 1, .4f);
                break;
            case 3:
                player3Panel.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                player2Panel.GetComponent<Image>().color = new Color(1, 1, 1, .4f);
                player1Panel.GetComponent<Image>().color = new Color(1, 1, 1, .4f);
                player4Panel.GetComponent<Image>().color = new Color(1, 1, 1, .4f);
                break;
            case 4:
                player4Panel.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                player2Panel.GetComponent<Image>().color = new Color(1, 1, 1, .4f);
                player3Panel.GetComponent<Image>().color = new Color(1, 1, 1, .4f);
                player1Panel.GetComponent<Image>().color = new Color(1, 1, 1, .4f);
                break;
            default:
                break;
        }
        if (!isSuffle)
        {
            ActionsActive(true);
            DicesActive(true);
            DicesFacesActive();
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

        paidAmount.text = amount.ToString() + "$";

        IEnumerator wait()
        {
            float timeConsumed = 0f;
            do
            {
                yield return new WaitForSeconds(1f);
                timeConsumed = 1f;
            }
            while (timeConsumed < 1);
            OnDisable_Panel(paidRentPanel, moneyPanel);
        }
        StartCoroutine(wait());
    }

    //Bankruptcy
    //

    public void ShowBankruptcy(bool isBankrupt)
    {
        if (!isBankrupt)
        {
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            moneyPanel.SetActive(true);
            bankruptcyPanel.SetActive(true);
            OnEnable_StandOnPanel(bankruptcyPanel);
            bankruptcyPanel.transform.position = pos;
            payDebt.interactable = true;
            bankRupt.interactable = true;
        }
        else
        {
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            moneyPanel.SetActive(true);
            bankruptcyPanel.SetActive(true);
            OnEnable_StandOnPanel(bankruptcyPanel);
            bankruptcyPanel.transform.position = pos;
            payDebt.interactable = false;
            bankRupt.interactable = true;
        }
    }

    public void OnClick_PayDebt()
    {
        OnDisable_Panel(bankruptcyPanel, moneyPanel);
    }

    public void OnClick_Bankrupt()
    {
        //End game Checker
    }

    #endregion 

    #region Actions

    //Active
    //

    public void ActionsActive(bool value)
    {
        build.interactable = value;
        sell.interactable = value;
        mortgage.interactable = value;
        redeem.interactable = value;
        trade.interactable = value;
    }

    public void EndTurnActive(bool value)
    {
        endTurn.interactable = value;
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
        build.interactable = false;
        sell.interactable = false;
        mortgage.interactable = false;
        redeem.interactable = false;
        trade.interactable = false;

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
        build.interactable = false;
        sell.interactable = false;
        mortgage.interactable = false;
        redeem.interactable = false;
        trade.interactable = false;

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
        build.interactable = false;
        sell.interactable = false;
        mortgage.interactable = false;
        redeem.interactable = false;
        trade.interactable = false;

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
        build.interactable = false;
        sell.interactable = false;
        mortgage.interactable = false;
        redeem.interactable = false;
        trade.interactable = false;

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
        build.interactable = false;
        sell.interactable = false;
        mortgage.interactable = false;
        redeem.interactable = false;
        trade.interactable = false;

        trade_offerPanel.SetActive(true);
        OnEnable_Trade(trade_offerPanel);
        trade_receivePanel.SetActive(false);
        trade_illegalPanel.SetActive(false);

        //Select trade player
        tradeoffer_title.text = _Table.getCurrentPlayer().playerName + "'s Offer";

        //Select first player to trade
        trade_currentOpppnent = _Table.SwitchWithoutPlayer(_Table.getCurrentPlayer(), _Table.getCurrentPlayer(), true); //Select player to trade
        tradeoffer_selectedPlayer.text = trade_currentOpppnent.playerName;
        tradeoffer_myPlayerMoney.text = "Send Money (Maximum: " + _Table.getCurrentPlayer().playerMoney + "$)";
        tradeoffer_opponentMoney.text = "Ask Money (Maximum: " + trade_currentOpppnent.playerMoney + "$)";

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

        _Table.ShowTradeItem(_Table.getCurrentPlayer(), tradeoffer_myPlayerContent, trade_property);
        _Table.ShowTradeItem(trade_currentOpppnent, tradeoffer_opponentContent, trade_property);
    }

    public void OnClick_Trade_PrevPlayer()
    {
        for (int i = 0; i < tradeoffer_opponentContent.childCount; i++)
        {
            Destroy(tradeoffer_opponentContent.GetChild(i).gameObject);
        }

        trade_currentOpppnent = _Table.SwitchWithoutPlayer(trade_currentOpppnent, _Table.getCurrentPlayer(), false);
        tradeoffer_selectedPlayer.text = trade_currentOpppnent.playerName;
        tradeoffer_opponentMoney.text = "Ask Money (Maximum: " + trade_currentOpppnent.playerMoney + "$)";
        _Table.ShowTradeItem(trade_currentOpppnent, tradeoffer_opponentContent, trade_property);
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
        tradeoffer_opponentMoney.text = "Ask Money (Maximum: " + trade_currentOpppnent.playerMoney + "$)";
        _Table.ShowTradeItem(trade_currentOpppnent, tradeoffer_opponentContent, trade_property);
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

        if (tradeoffer_myPlayerMoneyValue.text != "" || tradeoffer_opponentMoneyValue.text != "")
        {
            if (myPlayerProp != 0 || int.Parse(tradeoffer_myPlayerMoneyValue.text) != 0)
            {
                if (opponentProp != 0 || int.Parse(tradeoffer_opponentMoneyValue.text) != 0)
                {
                    ShowTradeReceive();
                    return;
                }
            }
        }

        //print(myPlayerProp + int.Parse(tradeoffer_myPlayerMoneyValue.text) + "myplayer");
        //print(opponentProp + int.Parse(tradeoffer_opponentMoneyValue.text) + "opponent");

        ShowIllegalTrade();
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

        _Table.PlayerPayForPlayer(_Table.getCurrentPlayer(), trade_currentOpppnent, int.Parse(tradeoffer_myPlayerMoneyValue.text));

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

        _Table.PlayerPayForPlayer(trade_currentOpppnent, _Table.getCurrentPlayer(), int.Parse(tradeoffer_opponentMoneyValue.text));

        OnClick_ActionsClose();
    }

    public void OnClick_ActionsClose()
    {
        if (buildPanel.activeSelf || sellPanel.activeSelf || mortgagePanel.activeSelf || redeemPanel.activeSelf || tradePanel.activeSelf)
        {
            build.interactable = true;
            sell.interactable = true;
            mortgage.interactable = true;
            redeem.interactable = true;
            trade.interactable = true;
        }

        OnClick_CloseOnClickInformation();


        if (!tradePanel.activeSelf && (buildPanel.activeSelf || sellPanel.activeSelf || mortgagePanel.activeSelf || redeemPanel.activeSelf))
        {
            _Table.ShowSlot();
        }
        else
        {
            OnDisable_Panel(trade_illegalPanel, tradePanel);
            OnDisable_Panel(trade_receivePanel, tradePanel);
            OnDisable_Panel(trade_offerPanel, tradePanel);
        }

        OnDisable_Panel(buildPanel, mainActionPanel);
        OnDisable_Panel(sellPanel, mainActionPanel);
        OnDisable_Panel(mortgagePanel, mainActionPanel);
        OnDisable_Panel(redeemPanel, mainActionPanel);
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
            temp.GetComponent<PropertyCard>().selectedMask.SetActive(false);
        }

        foreach (PropertyCard card in GetTradeOffer(false))
        {
            GameObject temp = Instantiate(card.gameObject, tradereceive_opponentContent);
            temp.GetComponent<PropertyCard>().isTrade = false;
            temp.GetComponent<PropertyCard>().selectedMask.SetActive(false);
        }

        //Money part
        if (tradeoffer_myPlayerMoneyValue.text == "" || tradeoffer_myPlayerMoneyValue.text == "0")
        {
            tradereceive_myPlayerMoney.text = "0$";
        }
        else
        {
            tradereceive_myPlayerMoney.text = tradeoffer_myPlayerMoneyValue.text + "$";
        }

        if (tradeoffer_opponentMoneyValue.text == "" || tradeoffer_opponentMoneyValue.text == "0")
        {
            tradereceive_opponentMoney.text = "0$";
        }
        else
        {
            tradereceive_opponentMoney.text = tradeoffer_opponentMoneyValue.text + "$";
        }
    }

    public void AutoCorrect_InputField()
    {
        if (tradeoffer_myPlayerMoneyValue.text == "")
        {
            tradeoffer_myPlayerMoneyValue.text = "0";
        }
        else if (int.Parse(tradeoffer_myPlayerMoneyValue.text) > _Table.getCurrentPlayer().playerMoney)
        {
            tradeoffer_myPlayerMoneyValue.text = _Table.getCurrentPlayer().playerMoney.ToString();
        }
        //print(int.Parse(tradeoffer_myPlayerMoneyValue.text + "myplayermoney"));

        if (tradeoffer_opponentMoneyValue.text == "")
        {
            tradeoffer_opponentMoneyValue.text = "0";
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
        OnEnable_StandOnPanel(colorPropertyInformationCard);
        Vector2 pos  = Camera.main.WorldToScreenPoint(_Table.transform.position);
        cpi_showButtonPanel.SetActive(true);
        cpi_boughtPanel.SetActive(false);


        if (_Table.getCurrentPlayer().playerMoney < _Table.getSlot(_Table.getCurrentPlayer().currentSlot).getSlotPrice()) //can't afford
        {
            cpi_buyButton.interactable = false;
            cpi_auctionButton.interactable = true;
        }
        else
        {
            cpi_buyButton.interactable = true;
            cpi_auctionButton.interactable = true;
        }

        colorPropertyInformationCard.transform.position = pos;
        cpi_colorPropertyCard.ShowCard(slotNumber);
    }

    public void ShowColorPropertyBought()
    {
        standOnInformationPanel.SetActive(true);
        colorPropertyInformationCard.SetActive(true);
        OnEnable_StandOnPanel(colorPropertyInformationCard);
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        colorPropertyInformationCard.transform.position = pos;


        cpi_showButtonPanel.SetActive(false);
        cpi_boughtPanel.SetActive(true);

        if (_Table.getCurrentPlayer() == _Table.player[0])
        {
            cpi_redPawn.SetActive(true);
            cpi_bluePawn.SetActive(false);
            cpi_greenPawn.SetActive(false);
            cpi_yellowPawn.SetActive(false);
        }
        else if (_Table.getCurrentPlayer() == _Table.player[1])
        {
            cpi_redPawn.SetActive(false);
            cpi_bluePawn.SetActive(true);
            cpi_greenPawn.SetActive(false);
            cpi_yellowPawn.SetActive(false);
        }
        else if (_Table.getCurrentPlayer() == _Table.player[2])
        {
            cpi_redPawn.SetActive(false);
            cpi_bluePawn.SetActive(false);
            cpi_greenPawn.SetActive(true);
            cpi_yellowPawn.SetActive(false);
        }
        else if (_Table.getCurrentPlayer() == _Table.player[3])
        {
            cpi_redPawn.SetActive(false);
            cpi_bluePawn.SetActive(false);
            cpi_greenPawn.SetActive(false);
            cpi_yellowPawn.SetActive(true);
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

    //Special Property Information Card
    //

    public void ShowSpecialPropertyCard(int slotNumber)
    {
        standOnInformationPanel.SetActive(true);
        specialPropertyInformationCard.SetActive(true);
        OnEnable_StandOnPanel(specialPropertyInformationCard);
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        specialPropertyInformationCard.transform.position = pos;
        ut_showButtonPanel.SetActive(true);
        ut_boughtPanel.SetActive(false);


        if (_Table.getCurrentPlayer().playerMoney < _Table.getSlot(_Table.getCurrentPlayer().currentSlot).getSlotPrice()) //can't afford
        {
            sp_buyButton.interactable = false;
            sp_auctionButton.interactable = true;
        }
        else
        {
            sp_buyButton.interactable = true;
            sp_auctionButton.interactable = true;
        }

        sp_specialPropertyCard.ShowCard(slotNumber);
    }

    public void ShowSpecialPropertyBought()
    {
        standOnInformationPanel.SetActive(true);
        specialPropertyInformationCard.SetActive(true);
        OnEnable_StandOnPanel(specialPropertyInformationCard);
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        specialPropertyInformationCard.transform.position = pos;

        ut_showButtonPanel.SetActive(false);
        ut_boughtPanel.SetActive(true);


        if (_Table.getCurrentPlayer() == _Table.player[0])
        {
            ut_redPawn.SetActive(true);
            ut_bluePawn.SetActive(false);
            ut_greenPawn.SetActive(false);
            ut_yellowPawn.SetActive(false);
        }
        else if (_Table.getCurrentPlayer() == _Table.player[1])
        {
            ut_redPawn.SetActive(false);
            ut_bluePawn.SetActive(true);
            ut_greenPawn.SetActive(false);
            ut_yellowPawn.SetActive(false);
        }
        else if (_Table.getCurrentPlayer() == _Table.player[2])
        {
            ut_redPawn.SetActive(false);
            ut_bluePawn.SetActive(false);
            ut_greenPawn.SetActive(true);
            ut_yellowPawn.SetActive(false);
        }
        else if (_Table.getCurrentPlayer() == _Table.player[3])
        {
            ut_redPawn.SetActive(false);
            ut_bluePawn.SetActive(false);
            ut_greenPawn.SetActive(false);
            ut_yellowPawn.SetActive(true);
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
                            cc_description.text = "Advance to Olympus (Collect $200)";
                            break;
                        case 2:
                            cc_description.text = "Advance to Horus. If you pass Olympus, collect $200";
                            break;
                        case 3:
                            cc_description.text = "Advance to Eros Place. If you pass Olympus, collect $200";
                            break;
                        case 4:
                            cc_description.text = "Advance to the nearest Rainbow Bridge and pay owner twice the tribute to which they are otherwise entitled. If Rainbow Bridge is unclaimed, you may claim it from the gods.";
                            break;
                        case 5:
                            cc_description.text = "Advance to the nearest Rainbow Bridge and pay owner twice the tribute to which they are otherwise entitled. If Rainbow Bridge is unclaimed, you may claim it from the gods.";
                            break;
                        case 6:
                            cc_description.text = "Advance token to nearest worship place. If unowned, you may consult it from the gods. If owned, throw dice and pay owner a total ten times amount thrown.";
                            break;
                        case 7:
                            cc_description.text = "The gods reward you with $50";
                            break;
                        case 8:
                            cc_description.text = "Escape from Tartarus Free";
                            break;
                        case 9:
                            cc_description.text = "The Fates rewind your fate by 3 Spaces";
                            break;
                        case 10:
                            cc_description.text = "Go to Tartarus. Go directly to Tartarus, do not pass Olympus, do not collect $200";
                            break;
                        case 11:
                            cc_description.text = "Make offerings to the gods for all your property. For each house pay $25. For each hotel pay $100";
                            break;
                        case 12:
                            cc_description.text = "Hermes charges you $15 for using his winged sandals";
                            break;
                        case 13:
                            cc_description.text = "Take a trip to Asgard. If you pass Olympus, collect $200";
                            break;
                        case 14:
                            cc_description.text = "You have been elected King of the Gods. Pay each player $50";
                            break;
                        case 15:
                            cc_description.text = "Your temple construction is complete. Collect $150";
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
                            cc_description.text = "Advance to Olympus (Collect $200)";
                            break;
                        case 1:
                            cc_description.text = "Divine favor in your favor. Collect $200";
                            break;
                        case 2:
                            cc_description.text = "Healing fee. Pay $50";
                            break;
                        case 3:
                            cc_description.text = "From trade with Midas you get $50";
                            break;
                        case 4:
                            cc_description.text = "Escape from Tartarus Free";
                            break;
                        case 5:
                            cc_description.text = "Go to Tartarus. Go directly to Tartarus, do not pass Olympus, do not collect $200";
                            break;
                        case 6:
                            cc_description.text = "Festival fund matures. Receive $100";
                            break;
                        case 7:
                            cc_description.text = "Caesar’s tribute. Collect $20";
                            break;
                        case 8:
                            cc_description.text = "It is your feast day. Collect $10 from every player";
                            break;
                        case 9:
                            cc_description.text = "Reincarnation bonus. Collect $100";
                            break;
                        case 10:
                            cc_description.text = "Pay healing fees of $100";
                            break;
                        case 11:
                            cc_description.text = "Pay academy fees of $50";
                            break;
                        case 12:
                            cc_description.text = "Receive $25 prophecy fee";
                            break;
                        case 13:
                            cc_description.text = "You are assessed for temple repair. $40 per house. $115 per hotel";
                            break;
                        case 14:
                            cc_description.text = "You have impressed Aphrodite with your charm. Collect $10";
                            break;
                        case 15:
                            cc_description.text = "You receive a blessing from your ancestors. Collect $100";
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
                        t_title.text = "SUPER TAX";
                        t_description.text = "PAY $100";
                    }
                    else if (_Table.getSlot(slotNumber).supriseSlot.taxPrice == 200)
                    {
                        t_title.text = "INCOME TAX";
                        t_description.text = "PAY $200";
                    }
                }
                yield return new WaitForSeconds(.2f);

                timeConsumed += .2f;
            }
            while (timeConsumed < 3 && supriseInformationCard.activeSelf);

            if (timeConsumed > 3)
            {
                OnClick_Done();
            }
        }
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

            StartCoroutine(actions());
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
            ij_Pay.interactable = true;
        }
        else
        {
            ij_Pay.interactable = false;
        }

        //Use Card
        if (_Table.getCurrentPlayer().numberJailFreeCard > 0)
        {
            ij_useCard.interactable = true;
        }
        else
        {
            ij_useCard.interactable = false;
        }
    }

    public void ShowAuction(int slotNumber, Player currentPlayer, int currentPrice, Player playerWithHighestBid)
    {
        auctionPanel.SetActive(true);
        auctionInformationPanel.SetActive(true);

        OnEnable_Auction(auctionInformationPanel);

        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        auctionInformationPanel.transform.position = pos;

        if (_Table.getSlot(slotNumber).slotType == Slot_Type.ColorProperty)
        {
            acp_colorPropertyPanel.SetActive(true);

            acp_propertyName.text = _Table.getSlot(slotNumber).getSlotName().ToUpper();
            acp_rentPrice.text = "RENT $" + _Table.getSlot(slotNumber).getPropertyRentUI(0).ToString();
            acp_rentDescription.text = "Rent is doubled on owning all unimproved sites in the group.";
            acp_house1.text = "$" + _Table.getSlot(slotNumber).getPropertyRentUI(1).ToString();
            acp_house2.text = "$" + _Table.getSlot(slotNumber).getPropertyRentUI(2).ToString();
            acp_house3.text = "$" + _Table.getSlot(slotNumber).getPropertyRentUI(3).ToString();
            acp_house4.text = "$" + _Table.getSlot(slotNumber).getPropertyRentUI(4).ToString();
            acp_hotel.text = "$" + _Table.getSlot(slotNumber).getPropertyRentUI(5).ToString();
            acp_buildPrice.text = "Contruction $" + _Table.getSlot(slotNumber).getBuildPrice().ToString() + " each";
            acp_mortgagePrice.text = "Mortgage $" + _Table.getSlot(slotNumber).getMortgagePrice().ToString() + " each";

            if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Brown)
            {
                acp_brownCard.SetActive(true);
                acp_blueCard.SetActive(false);
                acp_greenCard.SetActive(false);
                acp_orangeCard.SetActive(false);
                acp_pinkCard.SetActive(false);
                acp_purpleCard.SetActive(false);
                acp_redCard.SetActive(false);
                acp_yellowCard.SetActive(false);
            }
            else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Blue)
            {
                acp_brownCard.SetActive(false);
                acp_blueCard.SetActive(true);
                acp_greenCard.SetActive(false);
                acp_orangeCard.SetActive(false);
                acp_pinkCard.SetActive(false);
                acp_purpleCard.SetActive(false);
                acp_redCard.SetActive(false);
                acp_yellowCard.SetActive(false);
            }
            else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Green)
            {
                acp_brownCard.SetActive(false);
                acp_blueCard.SetActive(false);
                acp_greenCard.SetActive(true);
                acp_orangeCard.SetActive(false);
                acp_pinkCard.SetActive(false);
                acp_purpleCard.SetActive(false);
                acp_redCard.SetActive(false);
                acp_yellowCard.SetActive(false);
            }
            else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Orange)
            {
                acp_brownCard.SetActive(false);
                acp_blueCard.SetActive(false);
                acp_greenCard.SetActive(false);
                acp_orangeCard.SetActive(true);
                acp_pinkCard.SetActive(false);
                acp_purpleCard.SetActive(false);
                acp_redCard.SetActive(false);
                acp_yellowCard.SetActive(false);
            }
            else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Pink)
            {
                acp_brownCard.SetActive(false);
                acp_blueCard.SetActive(false);
                acp_greenCard.SetActive(false);
                acp_orangeCard.SetActive(false);
                acp_pinkCard.SetActive(true);
                acp_purpleCard.SetActive(false);
                acp_redCard.SetActive(false);
                acp_yellowCard.SetActive(false);
            }
            else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Purple)
            {
                acp_brownCard.SetActive(false);
                acp_blueCard.SetActive(false);
                acp_greenCard.SetActive(false);
                acp_orangeCard.SetActive(false);
                acp_pinkCard.SetActive(false);
                acp_purpleCard.SetActive(true);
                acp_redCard.SetActive(false);
                acp_yellowCard.SetActive(false);
            }
            else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Red)
            {
                acp_brownCard.SetActive(false);
                acp_blueCard.SetActive(false);
                acp_greenCard.SetActive(false);
                acp_orangeCard.SetActive(false);
                acp_pinkCard.SetActive(false);
                acp_purpleCard.SetActive(false);
                acp_redCard.SetActive(true);
                acp_yellowCard.SetActive(false);
            }
            else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Yellow)
            {
                acp_brownCard.SetActive(false);
                acp_blueCard.SetActive(false);
                acp_greenCard.SetActive(false);
                acp_orangeCard.SetActive(false);
                acp_pinkCard.SetActive(false);
                acp_purpleCard.SetActive(false);
                acp_redCard.SetActive(false);
                acp_yellowCard.SetActive(true);
            }
        }
        else if (_Table.getSlot(slotNumber).slotType == Slot_Type.SpecialProperty)
        {
            asp_specialPropertyPanel.SetActive(true);

            if (_Table.getSlot(slotNumber).specialProperty.propertyType == SpecialProperty_Type.RailRoad)
            {
                asp_railroad_Panel.SetActive(true);
                asp_utilities_Panel.SetActive(false);

                asp_rr_propertyName.text = _Table.getSlot(slotNumber).getSlotName();
            }
            else if (_Table.getSlot(slotNumber).specialProperty.propertyType == SpecialProperty_Type.Utility)
            {
                asp_railroad_Panel.SetActive(false);
                asp_utilities_Panel.SetActive(true);

                if (_Table.getSlot(slotNumber).specialProperty.utilityType == Utility_Type.WaterRorks)
                {
                    asp_ut_waterWorks_Image.SetActive(true);
                    asp_ut_electricCompany_Image.SetActive(false);
                    asp_ut_propertyName.text = _Table.getSlot(slotNumber).getSlotName();
                }
                else if (_Table.getSlot(slotNumber).specialProperty.utilityType == Utility_Type.ElectricCompany)
                {
                    asp_ut_waterWorks_Image.SetActive(false);
                    asp_ut_electricCompany_Image.SetActive(true);
                    asp_ut_propertyName.text = _Table.getSlot(slotNumber).getSlotName();
                }
            }
        }

        if (currentPlayer.playerMoney < currentPrice + 10) //just can withdraw
        {
            ai_smallBid.interactable = false;
            ai_bigBid.interactable = false;
            ai_withdraw.interactable = true;
        }
        else if (currentPlayer.playerMoney < currentPrice + 100) //can small bid
        {
            ai_smallBid.interactable = true;
            ai_bigBid.interactable = false;
            ai_withdraw.interactable = true;
        }
        else //can big bid
        {
            ai_smallBid.interactable = true;
            ai_bigBid.interactable = true;
            ai_withdraw.interactable = true;
        }

        //update currentPlayer and currentPrice
        ai_currentPlayerTurn.text = "Current Turn\n" + currentPlayer.playerName;
        if (playerWithHighestBid == null)
        {
            ai_currentPrice.text = "Current Price: " + currentPrice + "$ (None)";
        }
        else
        {
            ai_currentPrice.text = "Current Price: " + currentPrice + "$ (" + playerWithHighestBid.playerName + ")";
        }
    }
    
    public void CloseAuction(int slotNumber, Player playerWin, Player playerStart, int currentPrice, bool isWin)
    {
        if (isWin)
        {
            OnDisable_Panel(auctionInformationPanel, auctionPanel);
            _Table.SwitchPlayer(playerWin);
            _Table.Buy(slotNumber, currentPrice);
            _Table.SwitchPlayer(playerStart);
        }
        else
        {
            OnDisable_Panel(auctionInformationPanel, auctionPanel);
            _Table.SwitchPlayer(playerStart);
            HideInformationCard();
        }

        foreach (Player p in _Table.player) //reset lai luojt tham gia auction cua nguoi choi
        {
            p.joinAuction = true;
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
        OnDisable_Panel(Onclick_SpecialPropertyInformationCard, Onclick_InformationPanel);
        OnDisable_Panel(Onclick_ColorPropertyInformationCard, Onclick_InformationPanel);
    }

    public void HideInformationCard()
    {
        //Stand-on Card
        OnDisable_Panel(colorPropertyInformationCard, standOnInformationPanel);
        OnDisable_Panel(specialPropertyInformationCard, standOnInformationPanel);
        OnDisable_Panel(supriseInformationCard, standOnInformationPanel);

        //Jail
        OnDisable_Panel(inJailPanel, jailPanel);
        OnDisable_Panel(goToJailPanel, jailPanel);
        OnDisable_Panel(visitingJailPanel, jailPanel);

        //Auction
        //auctionPanel.SetActive(false);
        acp_colorPropertyPanel.SetActive(false);
        asp_specialPropertyPanel.SetActive(false);

        MoneyUpdate();
        _Table.getCurrentPlayer().CheckBankruptcy();
        //StopAllCoroutines();
    }

    #endregion

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
        //panel.SetActive(true);
        //Vector2 oldScale = panel.transform.localScale;
        panel.transform.localScale = new Vector2(0, 0);
        panel.transform.LeanScale(Scale_InformationPanel(), .25f).setEaseOutBack();
    }

    public void OnEnable_MainActionsPanel(GameObject panel)
    {
        //panel.SetActive(true);
        //Vector2 oldScale = panel.transform.localScale;
        panel.transform.localScale = new Vector2(0, 0);
        panel.transform.LeanScale(Scale_MainActionsPanel(), .25f).setEaseOutBack();
    }

    public void OnEnable_Auction(GameObject panel)
    {
        if (!panel.activeSelf)
        {
            panel.transform.localScale = new Vector2(0, 0);
            panel.transform.LeanScale(Scale_AuctionPanel(), .25f).setEaseOutBack();
        }
    }

    public void OnEnable_Trade(GameObject panel)
    {
        panel.transform.localScale = new Vector2(0, 0);
        panel.transform.LeanScale(new Vector2(1, 1), .25f).setEaseOutBack();
    }

    public void OnEnable_OnClickPanel(GameObject panel)
    {
        panel.transform.localScale = new Vector2(0, 0);
        panel.transform.LeanScale(Scale_OnClickPanel(), .25f).setEaseOutBack();
    }

    public void OnDisable_Panel(GameObject panel, GameObject parentPanel)
    {
        panel.transform.LeanScale(new Vector2(0, 0), .25f).setEaseInBack().setOnComplete(() => { panel.SetActive(false); parentPanel.SetActive(false); });
    }
}
