using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GameAdd_Ludopoly
{
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
        AdvanceToRailroad1, //Advance to the nearest Railroad. If unowned, you may buy it from the Bank. If owned, pay wonder twice the rental to which they are otherwise entitled
        AdvanceToRailroad2,
        AdvanceToUtility, //Advance token to nearest Utility. If unowned, you may buy it from the Bank. If owned, throw dice and pay owner a total ten times amount thrown
        Earn50, //Bank pays you dividend of $50
        JailFree, //Get Out of Jail Free
        Back3, //Go back 3 spaces
        GoToJail, //Go to Jail. Go directly to Jail, do not pass Go, do not collect $200
        Repair, //Make general repairs on all your property. For each house pay $25. For each hotel pay $100
        Speeding, //Speeding fine 15$
        ReadingRailroad, //Take a trip to Reading Railroad. If you pass Go, collect $200
        Chairman, //You have been elected Chairman of the Board. Pay each player $50
        Earn150, //Your building loan matures. Collect $150
    }

    public enum CommunityChestCards
    {
        AdvanceToGo, //Collect 200$
        BankError, //Collect 200$
        Doctor, //Pay 50$
        Stock, //Collect 50$
        JailFree, //Get out of jail free
        GoToJail, //Go directly to jail, do not pass go, do not collect 200$
        Holiday, //Collect 100$
        Income, //Collect 20$
        Birthday, //Collect 10$ from each player
        Insurance, //Collect 100$
        Hospital, //Pay 100$
        School, //Pay 50$
        Consultancy, //Collect 25$
        StreetRepair, //Pay 40$ per house, 115$ per hotel
        Beauty, //Colelct 10$
        Inherit, //Collect 100$
    }

    public enum CurrentPlayer
    {
        player1,
        player2,
        player3,
        player4,
    }

    public enum SlotAction
    {
        None,
        Idle,
        Build,
        Sell,
        Mortgage,
        Redeem
    }

    public enum PropertyType
    {
        ColorProperty,
        SpecialProperty,
        JailFree
    }

    public enum BotActions
    {
        //Roll dice actions
        RollDice,
        
        Done,

        //Buy or auction propperties
        BuyProps,
        AuctionProps,

        //Jail Actions
        JailPay,
        JailUse,
        JailRoll,

        //Trade ?

        //5 Main Actions
        Build,
        Sell,
        Abandon,
        Negotiate,


    }

    public enum CurrentState
    {
        WaitToRoll,
        BuyOrAuction,
        AuctionSelect,
        JailSelect,
        AfterSelection,
    }
}