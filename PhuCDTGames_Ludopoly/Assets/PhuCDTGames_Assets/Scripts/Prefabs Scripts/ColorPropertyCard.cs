using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAdd_Ludopoly
{
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
        public Text slotPrice;
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

        bool isChanged = false;
        public void ShowCard(int slotNumber)
        {
            propertyName.text = Table.Instance.getSlot(slotNumber).getSlotName().ToUpper();
            if (!isChanged)
            {
                slotPrice.text = Table.Instance.getSlot(slotNumber).getSlotPrice().ToString();
            }

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
            buildPrice.text = "Contruction " + Table.Instance.getSlot(slotNumber).getBuildPrice().ToString();

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

        public void ChangeSlotPrice(int value)
        {
            isChanged = true;
            slotPrice.text = value.ToString();
        }

        private void OnDisable()
        {
            isChanged = false;
        }
    }
}
