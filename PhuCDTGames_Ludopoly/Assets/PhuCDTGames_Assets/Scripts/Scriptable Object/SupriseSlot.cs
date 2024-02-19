using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Suprise Slot", menuName = "Slot/Suprise Slot")]
public class SupriseSlot : ScriptableObject
{
    public string slotName;
    public Sprite slotImage;
    public CommunityChestCards communityChestCards;
    public ChanceCards chanceCards;

    public SupriseSlot_Type slotType; //Community Chest, Chance, Tax

    public int taxPrice; //This only for Tax options
    
    public int DrawCommunityChest()
    {
        int random = UnityEngine.Random.Range(0, 16);

        switch (random)
        {
            case 0:
                communityChestCards = CommunityChestCards.AdvanceToGo;
                return 0;
            case 1:
                communityChestCards = CommunityChestCards.BankError;
                return 1;
            case 2:
                communityChestCards = CommunityChestCards.Doctor;
                return 2;
            case 3:
                communityChestCards = CommunityChestCards.Stock;
                return 3;
            case 4:
                communityChestCards = CommunityChestCards.JailFree;
                return 4;
            case 5:
                communityChestCards = CommunityChestCards.GoToJail;
                return 5;
            case 6:
                communityChestCards = CommunityChestCards.Holiday;
                return 6;
            case 7:
                communityChestCards = CommunityChestCards.Income;
                return 7;
            case 8:
                communityChestCards = CommunityChestCards.Birthday;
                return 8;
            case 9:
                communityChestCards = CommunityChestCards.Insurance;
                return 9;
            case 10:
                communityChestCards = CommunityChestCards.Hospital;
                return 10;
            case 11:
                communityChestCards = CommunityChestCards.School;
                return 11;
            case 12:
                communityChestCards = CommunityChestCards.Consultancy;
                return 12;
            case 13:
                communityChestCards = CommunityChestCards.StreetRepair;
                return 13;
            case 14:
                communityChestCards = CommunityChestCards.Beauty;
                return 14;
            case 15:
                communityChestCards = CommunityChestCards.Inherit;
                return 15;
            default:
                return -1;
        }
    }

    public int DrawChance() 
    {
        int random = UnityEngine.Random.Range(0, 16);

        switch (random)
        {
            case 0:
                chanceCards = ChanceCards.AdvanceToBoardwalk;
                return 0;
            case 1:
                chanceCards = ChanceCards.AdvanceToGo;
                return 1;
            case 2:
                chanceCards = ChanceCards.AdvanceToIllinois;
                return 2;
            case 3:
                chanceCards = ChanceCards.AdvanceToStCharles;
                return 3;
            case 4:
                chanceCards = ChanceCards.AdvanceToRailroad1;
                return 4;
            case 5:
                chanceCards = ChanceCards.AdvanceToRailroad2;
                return 5;
            case 6:
                chanceCards = ChanceCards.AdvanceToUtility;
                return 6;
            case 7:
                chanceCards = ChanceCards.Earn50;
                return 7;
            case 8:
                chanceCards = ChanceCards.JailFree;
                return 8;
            case 9:
                chanceCards = ChanceCards.Back3;
                return 9;
            case 10:
                chanceCards = ChanceCards.GoToJail;
                return 10;
            case 11:
                chanceCards = ChanceCards.Repair;
                return 11;
            case 12:
                chanceCards = ChanceCards.Speeding;
                return 12;
            case 13:
                chanceCards = ChanceCards.ReadingRailroad;
                return 13;
            case 14:
                chanceCards = ChanceCards.Chairman;
                return 14;
            case 15:
                chanceCards = ChanceCards.Earn150;
                return 15;
            default:
                return -1;
        }
    }
}