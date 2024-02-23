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
    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player1Money;
    public Image player1Image;

    [Header("Player 2")]
    public GameObject player2Panel;
    public TextMeshProUGUI player2Name;
    public TextMeshProUGUI player2Money;
    public Image player2Image;

    [Header("Player 3")]
    public GameObject player3Panel;
    public TextMeshProUGUI player3Name;
    public TextMeshProUGUI player3Money;
    public Image player3Image;

    [Header("Player 4")]
    public GameObject player4Panel;
    public TextMeshProUGUI player4Name;
    public TextMeshProUGUI player4Money;
    public Image player4Image;

    [Header("Slot Information")]
    public GameObject informationPanel;
    public GameObject colorPropertyInformationCard;
    public GameObject specialPropertyInformationCard;
    public GameObject supriseInformationCard;

    #region Color Property Information Card

    [Header("Color Property - Card Template")]
    [Header("Color Property Information Card")]
    public GameObject cpi_brownCard;
    public GameObject cpi_blueCard;
    public GameObject cpi_greenCard;
    public GameObject cpi_orangeCard;
    public GameObject cpi_pinkCard;
    public GameObject cpi_purpleCard;
    public GameObject cpi_redCard;
    public GameObject cpi_yellowCard;

    [Header("Color Property - Information")]
    public TextMeshProUGUI cpi_propertyName;
    public TextMeshProUGUI cpi_rentPrice;
    public TextMeshProUGUI cpi_rentDescription;
    public TextMeshProUGUI cpi_house1;
    public TextMeshProUGUI cpi_house2;
    public TextMeshProUGUI cpi_house3;
    public TextMeshProUGUI cpi_house4;
    public TextMeshProUGUI cpi_hotel;
    public TextMeshProUGUI cpi_buildPrice;
    public TextMeshProUGUI cpi_mortgagePrice;
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
    public Button sp_buyButton;
    public Button sp_auctionButton;

    [Header("Special Property - Railroads Information")]
    public GameObject railroad_Panel;
    public TextMeshProUGUI rr_propertyName;

    [Header("Special Property - Utilities Information")]
    public GameObject utilities_Panel;
    public TextMeshProUGUI ut_propertyName;
    public GameObject ut_waterWorks_Image;
    public GameObject ut_electricCompany_Image;

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

    #region On-click Information
    [Header("On-click - Information")]
    [Header("On-click")]
    public GameObject Onclick_InformationPanel;
    public GameObject Onclick_ColorPropertyInformationCard;
    public GameObject Onclick_SpecialPropertyInformationCard;

    [Header("On-click - Card Template")]
    public GameObject oc_cpi_brownCard;
    public GameObject oc_cpi_blueCard;
    public GameObject oc_cpi_greenCard;
    public GameObject oc_cpi_orangeCard;
    public GameObject oc_cpi_pinkCard;
    public GameObject oc_cpi_purpleCard;
    public GameObject oc_cpi_redCard;
    public GameObject oc_cpi_yellowCard;

    [Header("On-click - Color Property Information")]
    public TextMeshProUGUI oc_cpi_propertyName;
    public TextMeshProUGUI oc_cpi_rentPrice;
    public TextMeshProUGUI oc_cpi_rentDescription;
    public TextMeshProUGUI oc_cpi_house1;
    public TextMeshProUGUI oc_cpi_house2;
    public TextMeshProUGUI oc_cpi_house3;
    public TextMeshProUGUI oc_cpi_house4;
    public TextMeshProUGUI oc_cpi_hotel;
    public TextMeshProUGUI oc_cpi_buildPrice;
    public TextMeshProUGUI oc_cpi_mortgagePrice;

    [Header("On-click - Railroads Information")]
    public GameObject oc_railroad_Panel;
    public TextMeshProUGUI oc_rr_propertyName;

    [Header("On-click - Utilities Information")]
    public GameObject oc_utilities_Panel;
    public TextMeshProUGUI oc_ut_propertyName;
    public GameObject oc_ut_waterWorks_Image;
    public GameObject oc_ut_electricCompany_Image;
    #endregion

    #region Main Actions
    [Header("Main Actions")]
    public GameObject mainActionPanel;
    public GameObject buildPanel;
    public GameObject sellPanel;
    public GameObject mortgagePanel;
    public GameObject redeemPanel;
    #endregion

    #region Bankruptcy

    [Header("Bankruptcy")]
    public GameObject bankruptcyPanel;
    public Button payDebt;
    public Button bankRupt;

    #endregion

    #region Auction
    [Header("Auction - Information")]
    [Header("Auction")]
    public GameObject auctionPanel;
    public GameObject autionInformationPanel;
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
                player1Name.text = Table.Instance.player[0].playerName.ToString();
                //player1Money.text = Table.Instance.player[0].playerMoney.ToString() + "$";
                player1Image.color = Table.Instance.player[0].playerColor;

                //Player 2
                player2Name.text = Table.Instance.player[1].playerName.ToString();
                //player2Money.text = Table.Instance.player[1].playerMoney.ToString() + "$";
                player2Image.color = Table.Instance.player[1].playerColor;
            }
            else if (_Table.numOfPlayers == 3)
            {
                player1Panel.SetActive(true);
                player2Panel.SetActive(true);
                player3Panel.SetActive(true);
                player4Panel.SetActive(false);
                //Player 1
                player1Name.text = Table.Instance.player[0].playerName.ToString();
                //player1Money.text = Table.Instance.player[0].playerMoney.ToString() + "$";
                player1Image.color = Table.Instance.player[0].playerColor;

                //Player 2
                player2Name.text = Table.Instance.player[1].playerName.ToString();
                //player2Money.text = Table.Instance.player[1].playerMoney.ToString() + "$";
                player2Image.color = Table.Instance.player[1].playerColor;

                //Player 3
                player3Name.text = Table.Instance.player[2].playerName.ToString();
                //player3Money.text = Table.Instance.player[2].playerMoney.ToString() + "$";
                player3Image.color = Table.Instance.player[2].playerColor;
            }
            else if (_Table.numOfPlayers == 4)
            {
                player1Panel.SetActive(true);
                player2Panel.SetActive(true);
                player3Panel.SetActive(true);
                player4Panel.SetActive(true);
                //Player 1
                player1Name.text = Table.Instance.player[0].playerName.ToString();
                //player1Money.text = Table.Instance.player[0].playerMoney.ToString() + "$";
                player1Image.color = Table.Instance.player[0].playerColor;

                //Player 2
                player2Name.text = Table.Instance.player[1].playerName.ToString();
                //player2Money.text = Table.Instance.player[1].playerMoney.ToString() + "$";
                player2Image.color = Table.Instance.player[1].playerColor;

                //Player 3
                player3Name.text = Table.Instance.player[2].playerName.ToString();
                //player3Money.text = Table.Instance.player[2].playerMoney.ToString() + "$";
                player3Image.color = Table.Instance.player[2].playerColor;

                //Player 4
                player4Name.text = Table.Instance.player[3].playerName.ToString();
                //player4Money.text = Table.Instance.player[3].playerMoney.ToString() + "$";
                player4Image.color = Table.Instance.player[3].playerColor;
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

                    player1Money.text = previousValue.ToString("N0") + "$";

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

                    player1Money.text = previousValue.ToString("N0") + "$";

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

                    player2Money.text = previousValue.ToString("N0") + "$";

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

                    player2Money.text = previousValue.ToString("N0") + "$";

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

                    player3Money.text = previousValue.ToString("N0") + "$";

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

                    player3Money.text = previousValue.ToString("N0") + "$";

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

                    player4Money.text = previousValue.ToString("N0") + "$";

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

                    player4Money.text = previousValue.ToString("N0") + "$";

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
            paidRentPanel.SetActive(false);
            moneyPanel.SetActive(false);
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
            bankruptcyPanel.transform.position = pos;
            payDebt.interactable = true;
            bankRupt.interactable = true;
        }
        else
        {
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            moneyPanel.SetActive(true);
            bankruptcyPanel.SetActive(true);
            bankruptcyPanel.transform.position = pos;
            payDebt.interactable = false;
            bankRupt.interactable = true;
        }
    }

    public void OnClick_PayDebt()
    {
        moneyPanel.SetActive(false);
        bankruptcyPanel.SetActive(false);
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
        OnClick_ActionsClose();
        mainActionPanel.SetActive(true);
        buildPanel.SetActive(true);
        buildPanel.transform.position = pos;

        ScaleMainActionsPanel(buildPanel);

        _Table.Build();
    }

    public void OnClick_Sell()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        OnClick_ActionsClose();
        mainActionPanel.SetActive(true);
        sellPanel.SetActive(true);
        sellPanel.transform.position = pos;

        ScaleMainActionsPanel(sellPanel);

        _Table.Sell();
    }

    public void OnClick_Mortgage()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        OnClick_ActionsClose();
        mainActionPanel.SetActive(true);
        mortgagePanel.SetActive(true);
        mortgagePanel.transform.position = pos;

        ScaleMainActionsPanel(mortgagePanel);

        _Table.Mortgage();
    }

    public void OnClick_Redeem()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        OnClick_ActionsClose();
        mainActionPanel.SetActive(true);
        redeemPanel.SetActive(true);
        redeemPanel.transform.position = pos;

        ScaleMainActionsPanel(redeemPanel);

        _Table.Redeem();
    }

    public void OnClick_Trade()
    {
        OnClick_ActionsClose();
        tradePanel.SetActive(true);
        trade_offerPanel.SetActive(true);
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
        OnClick_CloseOnClickInformation();
        mainActionPanel.SetActive(false);
        buildPanel.SetActive(false);
        sellPanel.SetActive(false);
        mortgagePanel.SetActive(false);
        tradePanel.SetActive(false);
        redeemPanel.SetActive(false);
        _Table.UnshownSlot();
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
        trade_offerPanel.SetActive(false);
        trade_receivePanel.SetActive(false);
    }

    public void ShowTradeReceive()
    {
        trade_offerPanel.SetActive(false);
        trade_receivePanel.SetActive(true);
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
        informationPanel.SetActive(true);
        colorPropertyInformationCard.SetActive(true);
        Vector2 pos  = Camera.main.WorldToScreenPoint(_Table.transform.position);
        cpi_showButtonPanel.SetActive(true);
        cpi_boughtPanel.SetActive(false);

        ScaleInformationPanel(colorPropertyInformationCard);

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
        cpi_propertyName.text = _Table.getSlot(slotNumber).getSlotName().ToUpper();
        cpi_rentPrice.text = "RENT $" + _Table.getSlot(slotNumber).getPropertyRentUI(0).ToString();
        cpi_rentDescription.text = "Rent is doubled on owning all unimproved sites in the group.";
        cpi_house1.text = "$" + _Table.getSlot(slotNumber).getPropertyRentUI(1).ToString();
        cpi_house2.text = "$" + _Table.getSlot(slotNumber).getPropertyRentUI(2).ToString();
        cpi_house3.text = "$" + _Table.getSlot(slotNumber).getPropertyRentUI(3).ToString();
        cpi_house4.text = "$" + _Table.getSlot(slotNumber).getPropertyRentUI(4).ToString();
        cpi_hotel.text = "$" + _Table.getSlot(slotNumber).getPropertyRentUI(5).ToString();
        cpi_buildPrice.text = "Contruction $" + _Table.getSlot(slotNumber).getBuildPrice().ToString() + " each";
        cpi_mortgagePrice.text = "Mortgage $" + _Table.getSlot(slotNumber).getMortgagePrice().ToString() + " each";

        if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Brown)
        {
            cpi_brownCard.SetActive(true);
            cpi_blueCard.SetActive(false);
            cpi_greenCard.SetActive(false);
            cpi_orangeCard.SetActive(false);
            cpi_pinkCard.SetActive(false);
            cpi_purpleCard.SetActive(false);
            cpi_redCard.SetActive(false);
            cpi_yellowCard.SetActive(false);
        }
        else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Blue)
        {
            cpi_brownCard.SetActive(false);
            cpi_blueCard.SetActive(true);
            cpi_greenCard.SetActive(false);
            cpi_orangeCard.SetActive(false);
            cpi_pinkCard.SetActive(false);
            cpi_purpleCard.SetActive(false);
            cpi_redCard.SetActive(false);
            cpi_yellowCard.SetActive(false);
        }
        else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Green)
        {
            cpi_brownCard.SetActive(false);
            cpi_blueCard.SetActive(false);
            cpi_greenCard.SetActive(true);
            cpi_orangeCard.SetActive(false);
            cpi_pinkCard.SetActive(false);
            cpi_purpleCard.SetActive(false);
            cpi_redCard.SetActive(false);
            cpi_yellowCard.SetActive(false);
        }
        else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Orange)
        {
            cpi_brownCard.SetActive(false);
            cpi_blueCard.SetActive(false);
            cpi_greenCard.SetActive(false);
            cpi_orangeCard.SetActive(true);
            cpi_pinkCard.SetActive(false);
            cpi_purpleCard.SetActive(false);
            cpi_redCard.SetActive(false);
            cpi_yellowCard.SetActive(false);
        }
        else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Pink)
        {
            cpi_brownCard.SetActive(false);
            cpi_blueCard.SetActive(false);
            cpi_greenCard.SetActive(false);
            cpi_orangeCard.SetActive(false);
            cpi_pinkCard.SetActive(true);
            cpi_purpleCard.SetActive(false);
            cpi_redCard.SetActive(false);
            cpi_yellowCard.SetActive(false);
        }
        else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Purple)
        {
            cpi_brownCard.SetActive(false);
            cpi_blueCard.SetActive(false);
            cpi_greenCard.SetActive(false);
            cpi_orangeCard.SetActive(false);
            cpi_pinkCard.SetActive(false);
            cpi_purpleCard.SetActive(true);
            cpi_redCard.SetActive(false);
            cpi_yellowCard.SetActive(false);
        }
        else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Red)
        {
            cpi_brownCard.SetActive(false);
            cpi_blueCard.SetActive(false);
            cpi_greenCard.SetActive(false);
            cpi_orangeCard.SetActive(false);
            cpi_pinkCard.SetActive(false);
            cpi_purpleCard.SetActive(false);
            cpi_redCard.SetActive(true);
            cpi_yellowCard.SetActive(false);
        }
        else if (_Table.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Yellow)
        {
            cpi_brownCard.SetActive(false);
            cpi_blueCard.SetActive(false);
            cpi_greenCard.SetActive(false);
            cpi_orangeCard.SetActive(false);
            cpi_pinkCard.SetActive(false);
            cpi_purpleCard.SetActive(false);
            cpi_redCard.SetActive(false);
            cpi_yellowCard.SetActive(true);
        }
    }

    public void ShowColorPropertyBought()
    {
        informationPanel.SetActive(true);
        colorPropertyInformationCard.SetActive(true);
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        colorPropertyInformationCard.transform.position = pos;

        ScaleInformationPanel(colorPropertyInformationCard);

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
            specialPropertyInformationCard.SetActive(false);
            informationPanel.SetActive(false);
            HideInformationCard();
        }
        StartCoroutine(wait());
    }

    //Special Property Information Card
    //

    public void ShowSpecialPropertyCard(int slotNumber)
    {
        informationPanel.SetActive(true);
        specialPropertyInformationCard.SetActive(true);
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        specialPropertyInformationCard.transform.position = pos;
        ut_showButtonPanel.SetActive(true);
        ut_boughtPanel.SetActive(false);

        ScaleInformationPanel(specialPropertyInformationCard);

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

        if (_Table.getSlot(slotNumber).specialProperty.propertyType == SpecialProperty_Type.RailRoad)
        {
            railroad_Panel.SetActive(true);
            utilities_Panel.SetActive(false);

            rr_propertyName.text = _Table.getSlot(slotNumber).getSlotName();
        }
        else if (_Table.getSlot(slotNumber).specialProperty.propertyType == SpecialProperty_Type.Utility)
        {
            railroad_Panel.SetActive(false);
            utilities_Panel.SetActive(true);

            if (_Table.getSlot(slotNumber).specialProperty.utilityType == Utility_Type.WaterRorks)
            {
                ut_waterWorks_Image.SetActive(true);
                ut_electricCompany_Image.SetActive(false);
                ut_propertyName.text = _Table.getSlot(slotNumber).getSlotName();
            }
            else if (_Table.getSlot(slotNumber).specialProperty.utilityType == Utility_Type.ElectricCompany)
            {
                ut_waterWorks_Image.SetActive(false);
                ut_electricCompany_Image.SetActive(true);
                ut_propertyName.text = _Table.getSlot(slotNumber).getSlotName();
            }
        }
    }

    public void ShowSpecialPropertyBought()
    {
        informationPanel.SetActive(true);
        specialPropertyInformationCard.SetActive(true);
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        specialPropertyInformationCard.transform.position = pos;

        ut_showButtonPanel.SetActive(false);
        ut_boughtPanel.SetActive(true);

        ScaleInformationPanel(specialPropertyInformationCard);

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
            specialPropertyInformationCard.SetActive(false);
            informationPanel.SetActive(false);
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
        informationPanel.SetActive(true);
        supriseInformationCard.SetActive(true);
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        supriseInformationCard.transform.position = pos;

        ScaleInformationPanel(supriseInformationCard);

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
                            cc_description.text = "Advance to Boardwalk";
                            break;
                        case 1:
                            cc_description.text = "Advance to Go (Collect $200)";
                            break;
                        case 2:
                            cc_description.text = "Advance to Illinois Avenue. If you pass Go, collect $200";
                            break;
                        case 3:
                            cc_description.text = "Advance to St. Charles Place. If you pass Go, collect $200";
                            break;
                        case 4:
                            cc_description.text = "Advance to the nearest Railroad. If unowned, you may buy it from the Bank. If owned, pay wonder twice the rental to which they are otherwise entitled";
                            break;
                        case 5:
                            cc_description.text = "Advance to the nearest Railroad. If unowned, you may buy it from the Bank. If owned, pay wonder twice the rental to which they are otherwise entitled";
                            break;
                        case 6:
                            cc_description.text = "Advance token to nearest Utility. If unowned, you may buy it from the Bank. If owned, throw dice and pay owner a total ten times amount thrown.";
                            break;
                        case 7:
                            cc_description.text = "Bank pays you dividend of $50";
                            break;
                        case 8:
                            cc_description.text = "Get Out of Jail Free";
                            break;
                        case 9:
                            cc_description.text = "Go back 3 spaces";
                            break;
                        case 10:
                            cc_description.text = "Go to Jail. Go directly to Jail, do not pass Go, do not collect $200";
                            break;
                        case 11:
                            cc_description.text = "Make general repairs on all your property. For each house pay $25. For each hotel pay $100";
                            break;
                        case 12:
                            cc_description.text = "Speeding fine $15";
                            break;
                        case 13:
                            cc_description.text = "Take a trip to Reading Railroad. If you pass Go, collect $200";
                            break;
                        case 14:
                            cc_description.text = "You have been elected Chairman of the Board. Pay each player $50";
                            break;
                        case 15:
                            cc_description.text = "Your building loan matures. Collect $150";
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
                            cc_description.text = "Advance to Go (Collect $200)";
                            break;
                        case 1:
                            cc_description.text = "Bank error in your favor. Collect $200";
                            break;
                        case 2:
                            cc_description.text = "Doctor’s fee. Pay $50";
                            break;
                        case 3:
                            cc_description.text = "From sale of stock you get $50";
                            break;
                        case 4:
                            cc_description.text = "Get Out of Jail Free";
                            break;
                        case 5:
                            cc_description.text = "Go to Jail. Go directly to jail, do not pass Go, do not collect $200";
                            break;
                        case 6:
                            cc_description.text = "Holiday fund matures. Receive $100";
                            break;
                        case 7:
                            cc_description.text = "Income tax refund. Collect $20";
                            break;
                        case 8:
                            cc_description.text = "It is your birthday. Collect $10 from every player";
                            break;
                        case 9:
                            cc_description.text = "Life insurance matures. Collect $100";
                            break;
                        case 10:
                            cc_description.text = "Pay hospital fees of $100";
                            break;
                        case 11:
                            cc_description.text = "Pay school fees of $50";
                            break;
                        case 12:
                            cc_description.text = "Receive $25 consultancy fee";
                            break;
                        case 13:
                            cc_description.text = "You are assessed for street repair. $40 per house. $115 per hotel";
                            break;
                        case 14:
                            cc_description.text = "You have won second prize in a beauty contest. Collect $10";
                            break;
                        case 15:
                            cc_description.text = "You inherit $100";
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
            Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
            goToJailPanel.transform.position = pos;

            ScaleInformationPanel(goToJailPanel);

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
                Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
                visitingJailPanel.transform.position = pos;

                ScaleInformationPanel(visitingJailPanel);

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
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        inJailPanel.transform.position = pos;

        ScaleInformationPanel(inJailPanel);

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
        autionInformationPanel.SetActive(true);
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        autionInformationPanel.transform.position = pos;

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
            auctionPanel.SetActive(false);
            autionInformationPanel.SetActive(false);
            _Table.SwitchPlayer(playerWin);
            _Table.Buy(slotNumber, currentPrice);
            _Table.SwitchPlayer(playerStart);
        }
        else
        {
            auctionPanel.SetActive(false);
            autionInformationPanel.SetActive(false);
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
        Onclick_SpecialPropertyInformationCard.SetActive(false);

        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);

        Onclick_ColorPropertyInformationCard.transform.position = pos;
        oc_cpi_propertyName.text = tempSlot.getSlotName().ToUpper();
        oc_cpi_rentPrice.text = "RENT $" + tempSlot.getPropertyRentUI(0).ToString();
        oc_cpi_rentDescription.text = "Rent is doubled on owning all unimproved sites in the group.";
        oc_cpi_house1.text = "$" + tempSlot.getPropertyRentUI(1).ToString();
        oc_cpi_house2.text = "$" + tempSlot.getPropertyRentUI(2).ToString();
        oc_cpi_house3.text = "$" + tempSlot.getPropertyRentUI(3).ToString();
        oc_cpi_house4.text = "$" + tempSlot.getPropertyRentUI(4).ToString();
        oc_cpi_hotel.text = "$" + tempSlot.getPropertyRentUI(5).ToString();
        oc_cpi_buildPrice.text = "Contruction $" + tempSlot.getBuildPrice().ToString() + " each";
        oc_cpi_mortgagePrice.text = "Mortgage $" + tempSlot.getMortgagePrice().ToString() + " each";

        if (tempSlot.colorProperty.propertyColor == ColorProperty_Color.Brown)
        {
            oc_cpi_brownCard.SetActive(true);
            oc_cpi_blueCard.SetActive(false);
            oc_cpi_greenCard.SetActive(false);
            oc_cpi_orangeCard.SetActive(false);
            oc_cpi_pinkCard.SetActive(false);
            oc_cpi_purpleCard.SetActive(false);
            oc_cpi_redCard.SetActive(false);
            oc_cpi_yellowCard.SetActive(false);
        }
        else if (tempSlot.colorProperty.propertyColor == ColorProperty_Color.Blue)
        {
            oc_cpi_brownCard.SetActive(false);
            oc_cpi_blueCard.SetActive(true);
            oc_cpi_greenCard.SetActive(false);
            oc_cpi_orangeCard.SetActive(false);
            oc_cpi_pinkCard.SetActive(false);
            oc_cpi_purpleCard.SetActive(false);
            oc_cpi_redCard.SetActive(false);
            oc_cpi_yellowCard.SetActive(false);
        }
        else if (tempSlot.colorProperty.propertyColor == ColorProperty_Color.Green)
        {
            oc_cpi_brownCard.SetActive(false);
            oc_cpi_blueCard.SetActive(false);
            oc_cpi_greenCard.SetActive(true);
            oc_cpi_orangeCard.SetActive(false);
            oc_cpi_pinkCard.SetActive(false);
            oc_cpi_purpleCard.SetActive(false);
            oc_cpi_redCard.SetActive(false);
            oc_cpi_yellowCard.SetActive(false);
        }
        else if (tempSlot.colorProperty.propertyColor == ColorProperty_Color.Orange)
        {
            oc_cpi_brownCard.SetActive(false);
            oc_cpi_blueCard.SetActive(false);
            oc_cpi_greenCard.SetActive(false);
            oc_cpi_orangeCard.SetActive(true);
            oc_cpi_pinkCard.SetActive(false);
            oc_cpi_purpleCard.SetActive(false);
            oc_cpi_redCard.SetActive(false);
            oc_cpi_yellowCard.SetActive(false);
        }
        else if (tempSlot.colorProperty.propertyColor == ColorProperty_Color.Pink)
        {
            oc_cpi_brownCard.SetActive(false);
            oc_cpi_blueCard.SetActive(false);
            oc_cpi_greenCard.SetActive(false);
            oc_cpi_orangeCard.SetActive(false);
            oc_cpi_pinkCard.SetActive(true);
            oc_cpi_purpleCard.SetActive(false);
            oc_cpi_redCard.SetActive(false);
            oc_cpi_yellowCard.SetActive(false);
        }
        else if (tempSlot.colorProperty.propertyColor == ColorProperty_Color.Purple)
        {
            oc_cpi_brownCard.SetActive(false);
            oc_cpi_blueCard.SetActive(false);
            oc_cpi_greenCard.SetActive(false);
            oc_cpi_orangeCard.SetActive(false);
            oc_cpi_pinkCard.SetActive(false);
            oc_cpi_purpleCard.SetActive(true);
            oc_cpi_redCard.SetActive(false);
            oc_cpi_yellowCard.SetActive(false);
        }
        else if (tempSlot.colorProperty.propertyColor == ColorProperty_Color.Red)
        {
            oc_cpi_brownCard.SetActive(false);
            oc_cpi_blueCard.SetActive(false);
            oc_cpi_greenCard.SetActive(false);
            oc_cpi_orangeCard.SetActive(false);
            oc_cpi_pinkCard.SetActive(false);
            oc_cpi_purpleCard.SetActive(false);
            oc_cpi_redCard.SetActive(true);
            oc_cpi_yellowCard.SetActive(false);
        }
        else if (tempSlot.colorProperty.propertyColor == ColorProperty_Color.Yellow)
        {
            oc_cpi_brownCard.SetActive(false);
            oc_cpi_blueCard.SetActive(false);
            oc_cpi_greenCard.SetActive(false);
            oc_cpi_orangeCard.SetActive(false);
            oc_cpi_pinkCard.SetActive(false);
            oc_cpi_purpleCard.SetActive(false);
            oc_cpi_redCard.SetActive(false);
            oc_cpi_yellowCard.SetActive(true);
        }
    }

    public void OCShowSpecialPropertyCard(Slot tempSlot)
    {
        Onclick_InformationPanel.SetActive(true);
        Onclick_SpecialPropertyInformationCard.SetActive(true);
        Onclick_ColorPropertyInformationCard.SetActive(false);

        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        Onclick_SpecialPropertyInformationCard.transform.position = pos;

        if (tempSlot.specialProperty.propertyType == SpecialProperty_Type.RailRoad)
        {
            oc_railroad_Panel.SetActive(true);
            oc_utilities_Panel.SetActive(false);

            oc_rr_propertyName.text = tempSlot.getSlotName();
        }
        else if (tempSlot.specialProperty.propertyType == SpecialProperty_Type.Utility)
        {
            oc_railroad_Panel.SetActive(false);
            oc_utilities_Panel.SetActive(true);

            if (tempSlot.specialProperty.utilityType == Utility_Type.WaterRorks)
            {
                oc_ut_waterWorks_Image.SetActive(true);
                oc_ut_electricCompany_Image.SetActive(false);
                oc_ut_propertyName.text = tempSlot.getSlotName();
            }
            else if (tempSlot.specialProperty.utilityType == Utility_Type.ElectricCompany)
            {
                oc_ut_waterWorks_Image.SetActive(false);
                oc_ut_electricCompany_Image.SetActive(true);
                oc_ut_propertyName.text = tempSlot.getSlotName();
            }
        }
    }

    public void OnClick_CloseOnClickInformation()
    {
        Onclick_SpecialPropertyInformationCard.SetActive(false);
        Onclick_ColorPropertyInformationCard.SetActive(false);
        Onclick_InformationPanel.SetActive(false);
    }

    public void PointerDown_ShowBoard(bool _down)
    {
        if (_down)
        {
            StartCoroutine(showColor());
            IEnumerator showColor()
            {
                Color shown = new Color(0f, 0f, 0f, 0.3529412f);
                Color unshown = new Color(0f, 0f, 0f, 0f);
                informationPanel.GetComponent<Image>().color = Color.Lerp(shown, unshown, Mathf.PingPong(Time.time, .2f));
                yield return new WaitForSeconds(.2f);
            }
            print("down");
        }
        else
        {

            StartCoroutine(showColor());
            IEnumerator showColor()
            {
                Color shown = new Color(0f, 0f, 0f, 0.3529412f);
                Color unshown = new Color(0f, 0f, 0f, 0f);
                informationPanel.GetComponent<Image>().color = Color.Lerp(unshown, shown, Mathf.PingPong(Time.time, .2f));
                yield return new WaitForSeconds(.2f);
            }
            print("up");
        }
    }

    public void HideInformationCard()
    {
        //Stand-on Card
        informationPanel.SetActive(false);
        //actionsCard.SetActive(false);
        colorPropertyInformationCard.SetActive(false);
        specialPropertyInformationCard.SetActive(false);
        supriseInformationCard.SetActive(false);

        //Jail
        jailPanel.SetActive(false);
        inJailPanel.SetActive(false);
        goToJailPanel.SetActive(false);
        visitingJailPanel.SetActive(false);

        //Auction
        auctionPanel.SetActive(false);
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

    //Scale panel
    //

    public void ScaleInformationPanel(GameObject panel)
    {
        if (_Table.GetScreenRatio() >= 0.46f && _Table.GetScreenRatio() < 0.48f)
        {
            panel.GetComponent<RectTransform>().localScale = new Vector2(1.04f, 1.04f);
        }
        else if (_Table.GetScreenRatio() >= 0.48f && _Table.GetScreenRatio() < 0.5f)
        {
            panel.GetComponent<RectTransform>().localScale = new Vector2(0.98f, 0.98f);
        }
        else if (_Table.GetScreenRatio() >= 0.5f)
        {
            panel.GetComponent<RectTransform>().localScale = new Vector2(.85f, .85f);
        }
    }

    public void ScaleMainActionsPanel(GameObject panel)
    {
        if (_Table.GetScreenRatio() >= 0.46f && _Table.GetScreenRatio() < 0.48f)
        {
            buildPanel.GetComponent<RectTransform>().localScale = new Vector2(.94f, .94f);
        }
        else if (_Table.GetScreenRatio() >= 0.48f && _Table.GetScreenRatio() < 0.5f)
        {
            buildPanel.GetComponent<RectTransform>().localScale = new Vector2(.88f, .88f);
        }
        else if (_Table.GetScreenRatio() >= 0.5f)
        {
            buildPanel.GetComponent<RectTransform>().localScale = new Vector2(.75f, .75f);
        }
    }
}
