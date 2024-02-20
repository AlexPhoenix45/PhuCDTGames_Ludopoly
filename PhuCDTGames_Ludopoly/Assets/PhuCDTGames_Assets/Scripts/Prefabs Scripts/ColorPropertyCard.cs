using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorPropertyCard : MonoBehaviour
{
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
    public TextMeshProUGUI propertyName;
    public TextMeshProUGUI rentPrice;
    public TextMeshProUGUI rentDescription;
    public TextMeshProUGUI house1;
    public TextMeshProUGUI house2;
    public TextMeshProUGUI house3;
    public TextMeshProUGUI house4;
    public TextMeshProUGUI hotel;
    public TextMeshProUGUI buildPrice;
    public TextMeshProUGUI mortgagePrice;
    public void TradeShowCard(int slotNumber)
    {
        propertyName.text = Table.Instance.getSlot(slotNumber).getSlotName().ToUpper();
        rentPrice.text = "RENT $" + Table.Instance.getSlot(slotNumber).getPropertyRentUI(0).ToString();
        rentDescription.text = "Rent is doubled on owning all unimproved sites in the group.";
        house1.text = "$" + Table.Instance.getSlot(slotNumber).getPropertyRentUI(1).ToString();
        house2.text = "$" + Table.Instance.getSlot(slotNumber).getPropertyRentUI(2).ToString();
        house3.text = "$" + Table.Instance.getSlot(slotNumber).getPropertyRentUI(3).ToString();
        house4.text = "$" + Table.Instance.getSlot(slotNumber).getPropertyRentUI(4).ToString();
        hotel.text = "$" + Table.Instance.getSlot(slotNumber).getPropertyRentUI(5).ToString();
        buildPrice.text = "Contruction $" + Table.Instance.getSlot(slotNumber).getBuildPrice().ToString() + " each";
        mortgagePrice.text = "Mortgage $" + Table.Instance.getSlot(slotNumber).getMortgagePrice().ToString() + " each";

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
}
