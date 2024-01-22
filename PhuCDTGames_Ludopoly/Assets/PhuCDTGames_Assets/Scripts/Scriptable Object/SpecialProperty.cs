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

    //Others Data
    public int mortgagePrice;
    //25 if 1 owned, 50 if 2 owned, 100 if 3 owned, 200 if all 4 
    public SpecialProperty_Type propertyType;
    public Utility_Type utilityType;
}
