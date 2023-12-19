using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Special Property", menuName = "Slot/Special Property")]
public class SpecialProperty : ScriptableObject
{
    //Display Data
    public string propertyName;
    public Sprite propertyImage;
    public int propertyPrice;
}
