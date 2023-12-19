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
    public TextMeshProUGUI colorProperty_Panel_Name;
    public TextMeshProUGUI colorProperty_Panel_Price;

    [Header("Special Property")]
    public GameObject specialProperty_Panel;
    public TextMeshProUGUI specialProperty_Panel_Name;
    public TextMeshProUGUI specialProperty_Panel_Price;
    public GameObject specialProperty_Panel_Image;

    [Header("Suprise Slot")]
    public GameObject supriseSlot_Panel;
    public TextMeshProUGUI supriseSlot_Panel_Name;
    public GameObject supriseSlot_Panel_Image;

    private void Start()
    {
        DisplaySlot();
    }

    private void DisplaySlot()
    {
        if (slotType == Type.ColorProperty)
        {
            gameObject.GetComponent<Image>().sprite = colorProperty.propertyImage;
            colorProperty_Panel.SetActive(true);
            colorProperty_Panel_Name.text = colorProperty.propertyName.ToUpper();
            colorProperty_Panel_Price.text = colorProperty.propertyPrice.ToString() + "$";
        }
        else if (slotType == Type.SpecialProperty)
        {
            specialProperty_Panel.SetActive(true);
            specialProperty_Panel_Name.text = specialProperty.propertyName.ToUpper();
            specialProperty_Panel_Price.text = specialProperty.propertyPrice.ToString() + "$";
            specialProperty_Panel_Image.gameObject.GetComponent<Image>().sprite = specialProperty.propertyImage;
        }
        else if (slotType == Type.SupriseSlot)
        {
            supriseSlot_Panel.SetActive(true);
            supriseSlot_Panel_Name.text = supriseSlot.slotName.ToUpper();
            supriseSlot_Panel_Image.gameObject.GetComponent<Image>().sprite = supriseSlot.slotImage;
        }

    }
}
