using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAdd_Ludopoly
{
    public class SpecialPropertyCard : MonoBehaviour
    {
        [Header("Railroads Information")]
        public GameObject railroad_Panel;
        public Text rr_propertyName;

        [Header("Utilities Information")]
        public GameObject utilities_Panel;
        public Text ut_propertyName;
        public GameObject ut_waterWorks_Image;
        public GameObject ut_electricCompany_Image;

        public Text slotPrice;

        bool isChanged = false;

        public void ShowCard(int slotNumber)
        {
            if (!isChanged)
            {
                slotPrice.text = Table.Instance.getSlot(slotNumber).getSlotPrice().ToString();
            }

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
