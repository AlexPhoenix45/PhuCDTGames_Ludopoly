using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public GameObject actionsCard;
    public GameObject colorPropertyInformationCard;
    public GameObject specialPropertyInformationCard;
    public GameObject supriseInformationCard;

    #region Color Property Information Card

    [Header("Card Template")]
    [Header("Color Property Information Card")]
    public GameObject cpi_brownCard;
    public GameObject cpi_blueCard;
    public GameObject cpi_greenCard;
    public GameObject cpi_orangeCard;
    public GameObject cpi_pinkCard;
    public GameObject cpi_purpleCard;
    public GameObject cpi_redCard;
    public GameObject cpi_yellowCard;

    [Header("Information")]
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

    #endregion

    #region Special Property Information Card
    [Header("Railroads Information")]
    [Header("Special Property Information Card")]
    public GameObject railroad_Panel;
    public TextMeshProUGUI rr_propertyName;

    [Header("Utilities Information")]
    public GameObject utilities_Panel;
    public TextMeshProUGUI ut_propertyName;
    public GameObject ut_waterWorks_Image;
    public GameObject ut_electricCompany_Image;
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
    public GameObject jailPanel;
    public GameObject inJailPanel;
    public GameObject goToJailPanel;
    public GameObject visitingJailPanel;

    //In Jail
    //
    [Header("In Jail")]
    public Button ij_Pay;
    public Button ij_useCard;
    public Button ij_rollDouble;

    public GameObject ij_redPawn;
    public GameObject ij_greenPawn;
    public GameObject ij_bluePawn;
    public GameObject ij_yellowPawn;

    //Go To Jail
    //
    [Header("Go To Jail")]
    public GameObject gtj_redPawn;
    public GameObject gtj_greenPawn;
    public GameObject gtj_bluePawn;
    public GameObject gtj_yellowPawn;

    //Visiting Jail
    //
    [Header("Visiting Jail")]
    public GameObject vj_redPawn;
    public GameObject vj_greenPawn;
    public GameObject vj_bluePawn;
    public GameObject vj_yellowPawn;

    #endregion

    #region Money
    [Header("Money")]
    public GameObject moneyPanel;
    public GameObject paidRentPanel;
    public TextMeshProUGUI paidAmount;

    [Header("Paid Profile")]
    public GameObject pp_redPawn;
    public GameObject pp_greenPawn;
    public GameObject pp_bluePawn;
    public GameObject pp_yellowPawn;

    [Header("Collect Profile")]
    public GameObject cp_redPawn;
    public GameObject cp_greenPawn;
    public GameObject cp_bluePawn;
    public GameObject cp_yellowPawn;
    #endregion

    #region On-click Information
    [Header("On-click Information")]
    public GameObject Onclick_InformationPanel;
    public GameObject Onclick_ColorPropertyInformationCard;
    public GameObject Onclick_SpecialPropertyInformationCard;

    [Header("OC Card Template")]
    [Header("OC Color Property Information Card")]
    public GameObject oc_cpi_brownCard;
    public GameObject oc_cpi_blueCard;
    public GameObject oc_cpi_greenCard;
    public GameObject oc_cpi_orangeCard;
    public GameObject oc_cpi_pinkCard;
    public GameObject oc_cpi_purpleCard;
    public GameObject oc_cpi_redCard;
    public GameObject oc_cpi_yellowCard;

    [Header("Information")]
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

    [Header("OC Railroads Information")]
    [Header("OC Special Property Information Card")]
    public GameObject oc_railroad_Panel;
    public TextMeshProUGUI oc_rr_propertyName;

    [Header("Utilities Information")]
    public GameObject oc_utilities_Panel;
    public TextMeshProUGUI oc_ut_propertyName;
    public GameObject oc_ut_waterWorks_Image;
    public GameObject oc_ut_electricCompany_Image;
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
        OptionsActive(false);
        EndTurnActive(false);
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
            while (timeConsumed < 1.5f);
            dices = Table.Instance.RollDice();
            setDicesFaces(dices, false);
            if (_Table.getCurrentPlayer().isInJail)
            {
                OptionsActive(true);
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
            OptionsActive(true);
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
            print("p1 update: \nold: " + previousValue.ToString() + " new: " + newValue.ToString());

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
            print("p2 update: \nold: " + previousValue.ToString() + " new: " + newValue.ToString());

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
            print("p3 update: \nold: " + previousValue.ToString() + " new: " + newValue.ToString());

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
            print("p4 update: \nold: " + previousValue.ToString() + " new: " + newValue.ToString());

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

    #endregion

    #region Actions

    //Active
    //

    public void OptionsActive(bool value)
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
    public void ShowColorPropertyCard(int slotNumber)
    {
        informationPanel.SetActive(true);
        colorPropertyInformationCard.SetActive(true);
        Vector2 pos  = Camera.main.WorldToScreenPoint(_Table.transform.position);

        colorPropertyInformationCard.transform.position = pos;
        cpi_propertyName.text = _Table.getSlot(slotNumber).getSlotName().ToUpper();
        cpi_rentPrice.text = "RENT $" + _Table.getSlot(slotNumber).getPropertyRent().ToString();
        cpi_rentDescription.text = "Rent is doubled on owning all unimproved sites in the group.";
        cpi_house1.text = "$" + _Table.getSlot(slotNumber).getPropertyRent(1).ToString();
        cpi_house2.text = "$" + _Table.getSlot(slotNumber).getPropertyRent(2).ToString();
        cpi_house3.text = "$" + _Table.getSlot(slotNumber).getPropertyRent(3).ToString();
        cpi_house4.text = "$" + _Table.getSlot(slotNumber).getPropertyRent(4).ToString();
        cpi_hotel.text = "$" + _Table.getSlot(slotNumber).getPropertyRent(5).ToString();
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
    
    //Special Property Information Card
    public void ShowSpecialPropertyCard(int slotNumber)
    {
        informationPanel.SetActive(true);
        specialPropertyInformationCard.SetActive(true);
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        specialPropertyInformationCard.transform.position = pos;

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

    //Suprise Information Card
    public void ShowSupriseCard(int slotNumber)
    {
        float timeConsumed = 0;
        int chanceCardNumber = _Table.getSlot(slotNumber).supriseSlot.DrawChance();
        int communityChestNumber = _Table.getSlot(slotNumber).supriseSlot.DrawCommunityChest();
        informationPanel.SetActive(true);
        supriseInformationCard.SetActive(true);
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
                while (timeConsumed < 3);

                if (timeConsumed > 3)
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
                while (timeConsumed < 3);

                if (timeConsumed > 3)
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

    public void OnClick_Buy()
    {
        _Table.Buy();
    }

    public void OnClick_Auction() 
    {

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

    //Hold to see board (Pending)
    //

    //On Click Show Information Card
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
        oc_cpi_rentPrice.text = "RENT $" + tempSlot.getPropertyRent().ToString();
        oc_cpi_rentDescription.text = "Rent is doubled on owning all unimproved sites in the group.";
        oc_cpi_house1.text = "$" + tempSlot.getPropertyRent(1).ToString();
        oc_cpi_house2.text = "$" + tempSlot.getPropertyRent(2).ToString();
        oc_cpi_house3.text = "$" + tempSlot.getPropertyRent(3).ToString();
        oc_cpi_house4.text = "$" + tempSlot.getPropertyRent(4).ToString();
        oc_cpi_hotel.text = "$" + tempSlot.getPropertyRent(5).ToString();
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
        informationPanel.SetActive(false);
        //actionsCard.SetActive(false);
        colorPropertyInformationCard.SetActive(false);
        specialPropertyInformationCard.SetActive(false);
        supriseInformationCard.SetActive(false);

        jailPanel.SetActive(false);
        inJailPanel.SetActive(false);
        goToJailPanel.SetActive(false);
        visitingJailPanel.SetActive(false);

        MoneyUpdate();
    }
    #endregion
}
