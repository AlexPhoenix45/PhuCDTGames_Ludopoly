using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PropertyCard : MonoBehaviour
{
    public GameObject colorPropertyPanel;
    public GameObject specialPropertyPanel;
    public GameObject jailFreePanel;
    public int propCardIndex;

    public PropertyType propertyType;

    [Header("Card Template")]
    public GameObject brownCard;
    public GameObject blueCard;
    public GameObject greenCard;
    public GameObject orangeCard;
    public GameObject pinkCard;
    public GameObject purpleCard;
    public GameObject redCard;
    public GameObject yellowCard;

    [Header("Card Information")]
    public Text cp_slotPrice;
    public Text propertyName;
    public Text rentPrice;
    public Text rentDescription;
    public Text house1;
    public Text house2;
    public Text house3;
    public Text house4;
    public Text hotel;
    public Text buildPrice;
    public Text mortgagePrice;

    [Header("Railroads Information")]
    public GameObject railroad_Panel;
    public Text rr_propertyName;

    [Header("Utilities Information")]
    public Text ut_slotPrice;
    public GameObject utilities_Panel;
    public Text ut_propertyName;
    public GameObject ut_waterWorks_Image;
    public GameObject ut_electricCompany_Image;

    [Header("Trade Parameter")]
    public bool isTrade;
    public bool isSelected;
    public GameObject selectedMask;
    public GameObject selectedMask_MyPlayer;
    public GameObject selectedMask_Opponent;
    public bool tradeLeft = true;


    public void TradeShowCard(int slotNumber)
    {
        propCardIndex = slotNumber;
        if (slotNumber != -1 && Table.Instance.getSlot(slotNumber).slotType == Slot_Type.ColorProperty) 
        {
            colorPropertyPanel.SetActive(true);
            specialPropertyPanel.SetActive(false);
            jailFreePanel.SetActive(false);
            propertyType = PropertyType.ColorProperty;
            isTrade = true;
            propertyName.text = Table.Instance.getSlot(slotNumber).getSlotName().ToUpper();

            if (Table.Instance.getSlot(slotNumber).getPropertyRentUI(0) < 10)
            {
                rentPrice.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(22.8125f, 47.1822f);
                rentPrice.text = Table.Instance.getSlot(slotNumber).getPropertyRentUI(0).ToString();
            }
            else
            {
                rentPrice.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(44.375f, 47.1822f);
                rentPrice.text = Table.Instance.getSlot(slotNumber).getPropertyRentUI(0).ToString();
            }

            rentDescription.text = "Rent is doubled on owning all unimproved sites in the group.";
            house1.text = Table.Instance.getSlot(slotNumber).getPropertyRentUI(1).ToString();
            house2.text = Table.Instance.getSlot(slotNumber).getPropertyRentUI(2).ToString();
            house3.text = Table.Instance.getSlot(slotNumber).getPropertyRentUI(3).ToString();
            house4.text = Table.Instance.getSlot(slotNumber).getPropertyRentUI(4).ToString();
            hotel.text = Table.Instance.getSlot(slotNumber).getPropertyRentUI(5).ToString();
            buildPrice.text = Table.Instance.getSlot(slotNumber).getBuildPrice().ToString();

            if (Table.Instance.getSlot(slotNumber).getMortgagePrice() < 100)
            {
                mortgagePrice.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(86.8125f, 17);
                mortgagePrice.text = "Mortgage " + Table.Instance.getSlot(slotNumber).getMortgagePrice().ToString();
            }
            else
            {
                mortgagePrice.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(96.1875f, 17);
                mortgagePrice.text = "Mortgage " + Table.Instance.getSlot(slotNumber).getMortgagePrice().ToString();
            }

            cp_slotPrice.text = Table.Instance.getSlot(slotNumber).getSlotPrice().ToString();

            if (Table.Instance.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Brown)
            {
                brownCard.SetActive(true);
                blueCard.SetActive(false);
                greenCard.SetActive(false);
                orangeCard.SetActive(false);
                pinkCard.SetActive(false);
                purpleCard.SetActive(false);
                redCard.SetActive(false);
                yellowCard.SetActive(false);
            }
            else if (Table.Instance.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Blue)
            {
                brownCard.SetActive(false);
                blueCard.SetActive(true);
                greenCard.SetActive(false);
                orangeCard.SetActive(false);
                pinkCard.SetActive(false);
                purpleCard.SetActive(false);
                redCard.SetActive(false);
                yellowCard.SetActive(false);
            }
            else if (Table.Instance.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Green)
            {
                brownCard.SetActive(false);
                blueCard.SetActive(false);
                greenCard.SetActive(true);
                orangeCard.SetActive(false);
                pinkCard.SetActive(false);
                purpleCard.SetActive(false);
                redCard.SetActive(false);
                yellowCard.SetActive(false);
            }
            else if (Table.Instance.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Orange)
            {
                brownCard.SetActive(false);
                blueCard.SetActive(false);
                greenCard.SetActive(false);
                orangeCard.SetActive(true);
                pinkCard.SetActive(false);
                purpleCard.SetActive(false);
                redCard.SetActive(false);
                yellowCard.SetActive(false);
            }
            else if (Table.Instance.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Pink)
            {
                brownCard.SetActive(false);
                blueCard.SetActive(false);
                greenCard.SetActive(false);
                orangeCard.SetActive(false);
                pinkCard.SetActive(true);
                purpleCard.SetActive(false);
                redCard.SetActive(false);
                yellowCard.SetActive(false);
            }
            else if (Table.Instance.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Purple)
            {
                brownCard.SetActive(false);
                blueCard.SetActive(false);
                greenCard.SetActive(false);
                orangeCard.SetActive(false);
                pinkCard.SetActive(false);
                purpleCard.SetActive(true);
                redCard.SetActive(false);
                yellowCard.SetActive(false);
            }
            else if (Table.Instance.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Red)
            {
                brownCard.SetActive(false);
                blueCard.SetActive(false);
                greenCard.SetActive(false);
                orangeCard.SetActive(false);
                pinkCard.SetActive(false);
                purpleCard.SetActive(false);
                redCard.SetActive(true);
                yellowCard.SetActive(false);
            }
            else if (Table.Instance.getSlot(slotNumber).colorProperty.propertyColor == ColorProperty_Color.Yellow)
            {
                brownCard.SetActive(false);
                blueCard.SetActive(false);
                greenCard.SetActive(false);
                orangeCard.SetActive(false);
                pinkCard.SetActive(false);
                purpleCard.SetActive(false);
                redCard.SetActive(false);
                yellowCard.SetActive(true);
            }
        }
        else if (slotNumber != -1 && Table.Instance.getSlot(slotNumber).slotType == Slot_Type.SpecialProperty)
        {
            colorPropertyPanel.SetActive(false);
            specialPropertyPanel.SetActive(true);
            jailFreePanel.SetActive(false);
            propertyType = PropertyType.SpecialProperty;
            isTrade = true;
            ut_slotPrice.text = Table.Instance.getSlot(slotNumber).getSlotPrice().ToString();
            if (Table.Instance.getSlot(slotNumber).specialProperty.propertyType == SpecialProperty_Type.RailRoad)
            {
                railroad_Panel.SetActive(true);
                utilities_Panel.SetActive(false);

                rr_propertyName.text = Table.Instance.getSlot(slotNumber).getSlotName();
            }
            else if (Table.Instance.getSlot(slotNumber).specialProperty.propertyType == SpecialProperty_Type.Utility)
            {
                railroad_Panel.SetActive(false);
                utilities_Panel.SetActive(true);

                if (Table.Instance.getSlot(slotNumber).specialProperty.utilityType == Utility_Type.WaterRorks)
                {
                    ut_waterWorks_Image.SetActive(true);
                    ut_electricCompany_Image.SetActive(false);
                    ut_propertyName.text = Table.Instance.getSlot(slotNumber).getSlotName();
                }
                else if (Table.Instance.getSlot(slotNumber).specialProperty.utilityType == Utility_Type.ElectricCompany)
                {
                    ut_waterWorks_Image.SetActive(false);
                    ut_electricCompany_Image.SetActive(true);
                    ut_propertyName.text = Table.Instance.getSlot(slotNumber).getSlotName();
                }
            }
        }
        else if (slotNumber == -1)
        {

            colorPropertyPanel.SetActive(false);
            specialPropertyPanel.SetActive(false);
            jailFreePanel.SetActive(true);
            isTrade = true;
            propertyType = PropertyType.JailFree;
        }
    }

    public void OnClick_TradeSelect()
    {
        if (isTrade && !isSelected)
        {
            isSelected = true;
            if (tradeLeft)
            {
                selectedMask.SetActive(true);
                selectedMask_MyPlayer.SetActive(true);
                selectedMask_Opponent.SetActive(false);
            }
            else
            {
                selectedMask.SetActive(true);
                selectedMask_MyPlayer.SetActive(false);
                selectedMask_Opponent.SetActive(true);
            }
        }
        else if (isTrade && isSelected)
        {
            isSelected = false;
            if (tradeLeft)
            {
                selectedMask.SetActive(false);
                selectedMask_MyPlayer.SetActive(false);
                selectedMask_Opponent.SetActive(false);
            }
            else
            {
                selectedMask.SetActive(false);
                selectedMask_MyPlayer.SetActive(false);
                selectedMask_Opponent.SetActive(false);
            }
        }
    }
}
