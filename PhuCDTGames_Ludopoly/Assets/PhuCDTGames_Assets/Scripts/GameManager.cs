using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Table _Table;
    public UIManager _UIManager;

    void Start()
    {
        //Loading Screen
        //After a while, call this
        IEnumerator LoadingScreen()
        {
            print("Loading");
            yield return new WaitForSeconds(3f);
            _Table.ChooseStartingPlayer();
        }
        StartCoroutine(LoadingScreen());
    }
}

public enum SpecialProperty_Type
{
    Utility,
    RailRoad,
}

public enum Utility_Type
{
    WaterRorks,
    ElectricCompany,
    None,
}
public enum Slot_Type
{
    Empty,
    ColorProperty,
    SpecialProperty,
    SupriseSlot,
    CornerSlot
}
public enum ColorProperty_Color
{
    Purple,
    Brown,
    Green,
    Blue,
    Orange,
    Pink,
    Red,
    Yellow
};
public enum SupriseSlot_Type
{
    Chance,
    CommunityChest,
    Tax
};
public enum CornerSlot_Type
{
    Go,
    VisitingJail,
    Parking,
    GoToJail
}

public enum ChanceCards
{
    AdvanceToBoardwalk, //slot no.39 (Advance to Boardwalk)
    AdvanceToGo, //slot no.0 (Advance to Go (Collect $200))
    AdvanceToIllinois, //slot no.24 (Advance to Illinois Avenue. If you pass Go, collect $200)
    AdvanceToStCharles, //slot no.11 (Advance to St. Charles Place. If you pass Go, collect $200)
    AdvanceToRailroad, 
}