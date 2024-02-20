using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialPropertyCard : MonoBehaviour
{
    [Header("Railroads Information")]
    public GameObject railroad_Panel;
    public TextMeshProUGUI rr_propertyName;

    [Header("Utilities Information")]
    public GameObject utilities_Panel;
    public TextMeshProUGUI ut_propertyName;
    public GameObject ut_waterWorks_Image;
    public GameObject ut_electricCompany_Image;

    public void TradeShowCard(int slotNumber)
    {
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
}
