using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    #region Player

    public void setPlayerInfo()
    {
        IEnumerator setInfo()
        {
            yield return new WaitForSeconds(.5f); //Delay for information to load

            //Player 1
            player1Name.text = Table.Instance.player[0].playerName.ToString();
            player1Money.text = Table.Instance.player[0].playerMoney.ToString() + "$";
            player1Image.color = Table.Instance.player[0].playerColor;

            //Player 2
            player2Name.text = Table.Instance.player[1].playerName.ToString();
            player2Money.text = Table.Instance.player[1].playerMoney.ToString() + "$";
            player2Image.color = Table.Instance.player[1].playerColor;

            //Player 3
            player3Name.text = Table.Instance.player[2].playerName.ToString();
            player3Money.text = Table.Instance.player[2].playerMoney.ToString() + "$";
            player3Image.color = Table.Instance.player[2].playerColor;

            //Player 4
            player4Name.text = Table.Instance.player[3].playerName.ToString();
            player4Money.text = Table.Instance.player[3].playerMoney.ToString() + "$";
            player4Image.color = Table.Instance.player[3].playerColor;
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

    #endregion

    #region Actions

    #region Active
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
    #endregion

    #region Actions On_Click

    public void OnClick_EndTurn()
    {
        Table.Instance.SwitchPlayer();
        EndTurnActive(false);
    }

    #endregion

    #endregion

    #region Information Card
    public void ShowInformationCard(int slotNumber)
    {
        Slot_Type type;
        type = _Table.slot[slotNumber].GetComponent<Slot>().slotType;
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
            print("corner slot");
        }
    }

    //Color Property Information Card
    public void ShowColorPropertyCard(int slotNumber)
    {
        informationPanel.SetActive(true);
        colorPropertyInformationCard.SetActive(true);
        Vector2 pos  = Camera.main.WorldToScreenPoint(_Table.transform.position);

        colorPropertyInformationCard.transform.position = pos;
        cpi_propertyName.text = _Table.slot[slotNumber].GetComponent<Slot>().getSlotName(Slot_Type.ColorProperty).ToUpper();
        cpi_rentPrice.text = "RENT $" + _Table.slot[slotNumber].GetComponent<Slot>().getPropertyRent(Slot_Type.ColorProperty).ToString();
        cpi_rentDescription.text = "Rent is doubled on owning all unimproved sites in the group.";
        cpi_house1.text = "$" + _Table.slot[slotNumber].GetComponent<Slot>().getPropertyRent(Slot_Type.ColorProperty, 1).ToString();
        cpi_house2.text = "$" + _Table.slot[slotNumber].GetComponent<Slot>().getPropertyRent(Slot_Type.ColorProperty, 2).ToString();
        cpi_house3.text = "$" + _Table.slot[slotNumber].GetComponent<Slot>().getPropertyRent(Slot_Type.ColorProperty, 3).ToString();
        cpi_house4.text = "$" + _Table.slot[slotNumber].GetComponent<Slot>().getPropertyRent(Slot_Type.ColorProperty, 4).ToString();
        cpi_hotel.text = "$" + _Table.slot[slotNumber].GetComponent<Slot>().getPropertyRent(Slot_Type.ColorProperty, 5).ToString();
        cpi_buildPrice.text = "Contruction $" + _Table.slot[slotNumber].GetComponent<Slot>().getBuildPrice(Slot_Type.ColorProperty).ToString() + " each";
        cpi_mortgagePrice.text = "Mortgage $" + _Table.slot[slotNumber].GetComponent<Slot>().getMortgagePrice(Slot_Type.ColorProperty).ToString() + " each";

        if (_Table.slot[slotNumber].GetComponent<Slot>().colorProperty.propertyColor == ColorProperty_Color.Brown)
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
        else if (_Table.slot[slotNumber].GetComponent<Slot>().colorProperty.propertyColor == ColorProperty_Color.Blue)
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
        else if (_Table.slot[slotNumber].GetComponent<Slot>().colorProperty.propertyColor == ColorProperty_Color.Green)
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
        else if (_Table.slot[slotNumber].GetComponent<Slot>().colorProperty.propertyColor == ColorProperty_Color.Orange)
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
        else if (_Table.slot[slotNumber].GetComponent<Slot>().colorProperty.propertyColor == ColorProperty_Color.Pink)
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
        else if (_Table.slot[slotNumber].GetComponent<Slot>().colorProperty.propertyColor == ColorProperty_Color.Purple)
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
        else if (_Table.slot[slotNumber].GetComponent<Slot>().colorProperty.propertyColor == ColorProperty_Color.Red)
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
        else if (_Table.slot[slotNumber].GetComponent<Slot>().colorProperty.propertyColor == ColorProperty_Color.Yellow)
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

        if (_Table.slot[slotNumber].GetComponent<Slot>().specialProperty.propertyType == SpecialProperty_Type.RailRoad)
        {
            railroad_Panel.SetActive(true);
            utilities_Panel.SetActive(false);

            rr_propertyName.text = _Table.slot[slotNumber].GetComponent<Slot>().getSlotName(Slot_Type.SpecialProperty);
        }
        else if (_Table.slot[slotNumber].GetComponent<Slot>().specialProperty.propertyType == SpecialProperty_Type.Utility)
        {
            railroad_Panel.SetActive(false);
            utilities_Panel.SetActive(true);

            if (_Table.slot[slotNumber].GetComponent<Slot>().specialProperty.utilityType == Utility_Type.WaterRorks)
            {
                ut_waterWorks_Image.SetActive(true);
                ut_electricCompany_Image.SetActive(false);
                ut_propertyName.text = _Table.slot[slotNumber].GetComponent<Slot>().getSlotName(Slot_Type.SpecialProperty);
            }
            else if (_Table.slot[slotNumber].GetComponent<Slot>().specialProperty.utilityType == Utility_Type.ElectricCompany)
            {
                ut_waterWorks_Image.SetActive(false);
                ut_electricCompany_Image.SetActive(true);
                ut_propertyName.text = _Table.slot[slotNumber].GetComponent<Slot>().getSlotName(Slot_Type.SpecialProperty);
            }
        }
    }

    //Suprise Information Card
    public void ShowSupriseCard(int slotNumber)
    {
        informationPanel.SetActive(true);
        supriseInformationCard.SetActive(true);
        Vector2 pos = Camera.main.WorldToScreenPoint(_Table.transform.position);
        supriseInformationCard.transform.position = pos;

        if (_Table.slot[slotNumber].GetComponent<Slot>().supriseSlot.slotType == SupriseSlot_Type.Chance)
        {
            chanceAndCommunityChestInformation.SetActive(true);
            taxInformation.SetActive(false);

            cc_communityChestImage.SetActive(false);
            cc_chanceImage.SetActive(true);

            int chanceCardNumber = _Table.slot[slotNumber].GetComponent<Slot>().supriseSlot.DrawChance();

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
                    cc_description.text = "Get Out of Jail Free";
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
        else if (_Table.slot[slotNumber].GetComponent<Slot>().supriseSlot.slotType == SupriseSlot_Type.CommunityChest)
        {
            chanceAndCommunityChestInformation.SetActive(true);
            taxInformation.SetActive(false);

            cc_communityChestImage.SetActive(true);
            cc_chanceImage.SetActive(false);

            int communityChestNumber = _Table.slot[slotNumber].GetComponent<Slot>().supriseSlot.DrawCommunityChest();

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
        else if (_Table.slot[slotNumber].GetComponent<Slot>().supriseSlot.slotType == SupriseSlot_Type.Tax)
        {

            chanceAndCommunityChestInformation.SetActive(false);
            taxInformation.SetActive(true);

            if (_Table.slot[slotNumber].GetComponent<Slot>().supriseSlot.taxPrice == 100)
            {
                t_title.text = "SUPER TAX";
                t_description.text = "PAY $100";
            }
            else if (_Table.slot[slotNumber].GetComponent<Slot>().supriseSlot.taxPrice == 200)
            {
                t_title.text = "INCOME TAX";
                t_description.text = "PAY $200";
            }
        }
    }

    public void OnClick_Buy()
    {
        _Table.Buy();
    }

    public void OnClick_Auction() 
    {

    }

    public void OnClick_Done()
    {
        HideInformationCard();
    }

    public void HideInformationCard()
    {
        informationPanel.SetActive(false);
        //actionsCard.SetActive(false);
        colorPropertyInformationCard.SetActive(false);
        specialPropertyInformationCard.SetActive(false);
        supriseInformationCard.SetActive(false);
    }
    #endregion
}
