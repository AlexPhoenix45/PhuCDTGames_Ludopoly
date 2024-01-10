using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Suprise Slot", menuName = "Slot/Suprise Slot")]
public class SupriseSlot : ScriptableObject
{
    public string slotName;
    public Sprite slotImage;
 
    public SupriseSlot_Type slotType;

    public int taxPrice; //This only for Tax options
    
}