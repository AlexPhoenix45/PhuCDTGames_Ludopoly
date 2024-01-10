using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Color Property", menuName = "Slot/Color Property")]
public class ColorProperty : ScriptableObject
{
    //Display Data
    
    public ColorProperty_Color propertyColor;

    public Sprite propertyImage;
    public string propertyName;
    public int propertyPrice;

    //Non-display Data
    public int rentPrice;
    public int rentPrice_Set;
    public int rentPrice_1House;
    public int rentPrice_2House;
    public int rentPrice_3House;
    public int rentPrice_4House;
    public int rentPrice_Hotel;
    public int buildPrice;
    public int mortgagePrice;
}
