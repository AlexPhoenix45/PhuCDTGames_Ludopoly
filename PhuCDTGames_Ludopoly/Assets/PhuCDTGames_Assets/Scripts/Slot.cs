using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class Slot : MonoBehaviour
{
    
    [Header("Slot Type")]
    public Slot_Type slotType;

    [Header("Attach Slot")]
    public ColorProperty colorProperty;
    public SpecialProperty specialProperty;
    public SupriseSlot supriseSlot;
    public CornerSlot cornerSlot;

    [Header("Color Property")]
    [Header("Local Attribute")]
    public GameObject colorProperty_Panel;
    public GameObject colorProperty_Panel_Name;
    public GameObject colorProperty_Panel_Price;

    [Header("Special Property")]
    public GameObject specialProperty_Panel;
    public GameObject specialProperty_Panel_Name;
    public GameObject specialProperty_Panel_Price;
    public GameObject specialProperty_Panel_Image;

    [Header("Suprise Slot")]
    public GameObject supriseSlot_Panel;
    public GameObject supriseSlot_Panel_Name;
    public GameObject supriseSlot_Panel_Price; //This is for only tax slot
    public GameObject supriseSlot_Panel_Image;

    [Header("Corner Slot")]
    public GameObject cornerSlot_Text;

    [Header("Owner Parameters")]
    public bool isOwned = false;
    public Player owner;
    public GameObject ownerTag;
    public GameObject redTag;
    public GameObject blueTag;
    public GameObject greenTag;
    public GameObject yellowTag;

    private void Start()
    {
        DisplaySlot();
    }

    private void DisplaySlot()
    {
        if (slotType == Slot_Type.ColorProperty)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = colorProperty.propertyImage;
            colorProperty_Panel.SetActive(true);
            colorProperty_Panel_Name.GetComponent<TextMeshPro>().text = colorProperty.propertyName.ToUpper();
            colorProperty_Panel_Price.GetComponent<TextMeshPro>().text = colorProperty.propertyPrice.ToString() + "$";
        }
        else if (slotType == Slot_Type.SpecialProperty)
        {
            specialProperty_Panel.SetActive(true);
            specialProperty_Panel_Name.GetComponent<TextMeshPro>().text = specialProperty.propertyName.ToUpper();
            specialProperty_Panel_Price.GetComponent<TextMeshPro>().text = specialProperty.propertyPrice.ToString() + "$";
            specialProperty_Panel_Image.gameObject.GetComponent<SpriteRenderer>().sprite = specialProperty.propertyImage;
        }
        else if (slotType == Slot_Type.SupriseSlot)
        {
            supriseSlot_Panel.SetActive(true);
            supriseSlot_Panel_Name.GetComponent<TextMeshPro>().text = supriseSlot.slotName.ToUpper();
            if (supriseSlot.taxPrice > 0)
            {
                supriseSlot_Panel_Price.GetComponent<TextMeshPro>().text = "PAY " + supriseSlot.taxPrice.ToString() + "$";
            }
            else
            {
                supriseSlot_Panel_Price.GetComponent<TextMeshPro>().text = "";
            }
            supriseSlot_Panel_Image.gameObject.GetComponent<SpriteRenderer>().sprite = supriseSlot.slotImage;
        }
        else if (slotType == Slot_Type.CornerSlot)
        {
            cornerSlot_Text.SetActive(true);
            if (cornerSlot.slotType == CornerSlot_Type.Go)
            {
                cornerSlot_Text.GetComponent<TextMeshPro>().text = "GO";
            }
            else if (cornerSlot.slotType == CornerSlot_Type.VisitingJail)
            {
                cornerSlot_Text.GetComponent<TextMeshPro>().text = "JAIL";
            }
            else if (cornerSlot.slotType == CornerSlot_Type.Parking)
            {
                cornerSlot_Text.GetComponent<TextMeshPro>().text = "PARK LOT";
            }
            else if (cornerSlot.slotType == CornerSlot_Type.GoToJail)
            {
                cornerSlot_Text.GetComponent<TextMeshPro>().text = "GO TO JAIL";
            }
        }
    }

    #region Slot Information

    public string getSlotName(Slot_Type sType)
    {
        if (sType == Slot_Type.ColorProperty)
        {
            return colorProperty.propertyName;
        }
        else if (sType == Slot_Type.SpecialProperty)
        { 
            return specialProperty.propertyName;
        }
        else if (sType == Slot_Type.SupriseSlot)
        {
            return supriseSlot.slotName;
        }
        else if (sType == Slot_Type.CornerSlot)
        {
            if (cornerSlot.slotType == CornerSlot_Type.Go)
            {
                return "GO";
            }
            else if (cornerSlot.slotType == CornerSlot_Type.VisitingJail)
            {
                return "JAIL";
            }
            else if (cornerSlot.slotType == CornerSlot_Type.Parking)
            {
                return "PARK LOT";
            }
            else if (cornerSlot.slotType == CornerSlot_Type.GoToJail)
            {
                return "GO TO JAIL";
            }
            else
                return null;
        }
        else
        {
            return null;
        }
    }

    public int getSlotPrice(Slot_Type sType)
    {
        if (sType == Slot_Type.ColorProperty)
        {
            return colorProperty.propertyPrice;
        }
        else if (sType == Slot_Type.SpecialProperty)
        {
            return specialProperty.propertyPrice;
        }
        else
            return 0;
    }

    public int getPropertyRent(Slot_Type sType)
    {
        if (sType == Slot_Type.ColorProperty)
        {
            return colorProperty.rentPrice;
        }
        else if (sType == Slot_Type.SpecialProperty)
        {
            return specialProperty.rentPrice;
        }
        else
        {
            return 0;
        }
    }

    public int getPropertyRent(Slot_Type sType, int numOfHouse)
    {
        if (sType == Slot_Type.ColorProperty)
        {
            if (numOfHouse == 1)
            {
                return colorProperty.rentPrice_1House;
            }
            else if (numOfHouse == 2)
            {
                return colorProperty.rentPrice_2House;
            }
            else if (numOfHouse == 3)
            {
                return colorProperty.rentPrice_3House;
            }
            else if (numOfHouse == 4)
            {
                return colorProperty.rentPrice_4House;
            }
            else if (numOfHouse == 5)
            {
                return colorProperty.rentPrice_Hotel;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    public int getBuildPrice(Slot_Type sType)
    {
        if (sType == Slot_Type.ColorProperty)
        {
            return colorProperty.buildPrice;
        }
        else
        {
            return 0;
        }
    }

    public int getMortgagePrice(Slot_Type sType)
    {
        if (sType == Slot_Type.ColorProperty)
        {
            return colorProperty.mortgagePrice;
        }
        else
        {
            return 0; 
        }
    }

    #endregion

    #region Owner Set Get
    public void setOwner(Player player)
    {
        if (!isOwned)
        {
            owner = player;
            isOwned = true;
            if (player.playerColor == new Vector4(255, 0, 0, 255)) //red
            {
                ownerTag.SetActive(true);
                redTag.SetActive(true);
                blueTag.SetActive(false);
                greenTag.SetActive(false);
                yellowTag.SetActive(false);
            }
            else if (player.playerColor == new Vector4(0, 0, 255, 255)) //blue
            {
                ownerTag.SetActive(true);
                redTag.SetActive(false);
                blueTag.SetActive(true);
                greenTag.SetActive(false);
                yellowTag.SetActive(false);
            }
            else if (player.playerColor == new Vector4(0, 255, 0, 255)) //green
            {
                ownerTag.SetActive(true);
                redTag.SetActive(false);
                blueTag.SetActive(false);
                greenTag.SetActive(true);
                yellowTag.SetActive(false);
            }
            else if (player.playerColor == new Vector4(255, 255, 0, 255)) //yellow
            {
                ownerTag.SetActive(true);
                redTag.SetActive(false);
                blueTag.SetActive(false);
                greenTag.SetActive(false);
                yellowTag.SetActive(true);
            }
        }
    }

    public Player getOwner() { return owner; }

    public bool getIsOwned() { return isOwned; }

    #endregion

    #region Card Drawing
    public void DrawAChance()
    {

    }

    #endregion
}
