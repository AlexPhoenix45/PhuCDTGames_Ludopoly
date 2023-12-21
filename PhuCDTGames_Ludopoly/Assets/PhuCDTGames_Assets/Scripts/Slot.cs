using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public enum Type 
    {
        Empty,
        ColorProperty,
        SpecialProperty,
        SupriseSlot,
        CornerSlot
    }
    [Header("Slot Type")]
    public Type slotType;

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

    private void Start()
    {
        DisplaySlot();
    }

    private void DisplaySlot()
    {
        if (slotType == Type.ColorProperty)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = colorProperty.propertyImage;
            colorProperty_Panel.SetActive(true);
            colorProperty_Panel_Name.GetComponent<TextMeshPro>().text = colorProperty.propertyName.ToUpper();
            colorProperty_Panel_Price.GetComponent<TextMeshPro>().text = colorProperty.propertyPrice.ToString() + "$";
        }
        else if (slotType == Type.SpecialProperty)
        {
            specialProperty_Panel.SetActive(true);
            specialProperty_Panel_Name.GetComponent<TextMeshPro>().text = specialProperty.propertyName.ToUpper();
            specialProperty_Panel_Price.GetComponent<TextMeshPro>().text = specialProperty.propertyPrice.ToString() + "$";
            specialProperty_Panel_Image.gameObject.GetComponent<SpriteRenderer>().sprite = specialProperty.propertyImage;
        }
        else if (slotType == Type.SupriseSlot)
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
        else if (slotType == Type.CornerSlot)
        {
            cornerSlot_Text.SetActive(true);
            if (cornerSlot.slotType == CornerSlot.Type.Go)
            {
                cornerSlot_Text.GetComponent<TextMeshPro>().text = "GO";
            }
            else if (cornerSlot.slotType == CornerSlot.Type.VisitingJail)
            {
                cornerSlot_Text.GetComponent<TextMeshPro>().text = "JAIL";
            }
            else if (cornerSlot.slotType == CornerSlot.Type.Parking)
            {
                cornerSlot_Text.GetComponent<TextMeshPro>().text = "PARK LOT";
            }
            else if (cornerSlot.slotType == CornerSlot.Type.GoToJail)
            {
                cornerSlot_Text.GetComponent<TextMeshPro>().text = "GO TO JAIL";
            }
        }
    }
}
