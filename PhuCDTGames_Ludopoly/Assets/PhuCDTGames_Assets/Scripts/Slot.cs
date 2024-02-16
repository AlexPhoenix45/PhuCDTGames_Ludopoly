using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class Slot : MonoBehaviour
{
    
    [Header("Slot Type")]
    public Slot_Type slotType;

    [Header("Attach Slot")]
    public ColorProperty colorProperty;
    public SpecialProperty specialProperty;
    public SupriseSlot supriseSlot;
    public CornerSlot cornerSlot;

    [Header("Color Property")]
    [Header("Local Attribute")]
    public GameObject colorProperty_Panel;
    public GameObject colorProperty_Panel_Name;
    public GameObject colorProperty_Panel_Price;

    [Header("Special Property")]
    public GameObject specialProperty_Panel;
    public GameObject specialProperty_Panel_Name;
    public GameObject specialProperty_Panel_Price;
    public GameObject specialProperty_Panel_Image;

    [Header("Suprise Slot")]
    public GameObject supriseSlot_Panel;
    public GameObject supriseSlot_Panel_Name;
    public GameObject supriseSlot_Panel_Price; //This is for only tax slot
    public GameObject supriseSlot_Panel_Image;

    [Header("Corner Slot")]
    public GameObject cornerSlot_Text;

    [Header("Owner Parameters")]
    public bool isOwned = false;
    public Player owner;
    public GameObject ownerTag;
    public GameObject redTag;
    public GameObject blueTag;
    public GameObject greenTag;
    public GameObject yellowTag;

    [Header("Houses")]
    public short numberOfHouse = 0;
    public bool inSet = false;
    public GameObject house1;
    public GameObject house2;
    public GameObject house3;
    public GameObject house4;
    public GameObject hotel;

    [Header("Actions")]
    public SlotAction slotAction = SlotAction.Idle;
    public bool isMortgaged = false;
    public GameObject mortgagedTag;

    [Header("Slot Position")]
    public int numOfPlayerInSlot = 0;

    private void Start()
    {
        DisplaySlot();
    }

    private void DisplaySlot()
    {
        if (slotType == Slot_Type.ColorProperty)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = colorProperty.propertyImage;
            colorProperty_Panel.SetActive(true);
            colorProperty_Panel_Name.GetComponent<TextMeshPro>().text = colorProperty.propertyName.ToUpper();
            colorProperty_Panel_Price.GetComponent<TextMeshPro>().text = colorProperty.propertyPrice.ToString() + "$";
        }
        else if (slotType == Slot_Type.SpecialProperty)
        {
            specialProperty_Panel.SetActive(true);
            specialProperty_Panel_Name.GetComponent<TextMeshPro>().text = specialProperty.propertyName.ToUpper();
            specialProperty_Panel_Price.GetComponent<TextMeshPro>().text = specialProperty.propertyPrice.ToString() + "$";
            specialProperty_Panel_Image.gameObject.GetComponent<SpriteRenderer>().sprite = specialProperty.propertyImage;
        }
        else if (slotType == Slot_Type.SupriseSlot)
        {
            supriseSlot_Panel.SetActive(true);
            supriseSlot_Panel_Name.GetComponent<TextMeshPro>().text = supriseSlot.slotName.ToUpper();
            if (supriseSlot.taxPrice > 0)
            {
                supriseSlot_Panel_Price.GetComponent<TextMeshPro>().text = "PAY " + supriseSlot.taxPrice.ToString() + "$";
            }
            else
            {
                supriseSlot_Panel_Price.GetComponent<TextMeshPro>().text = "";
            }
            supriseSlot_Panel_Image.gameObject.GetComponent<SpriteRenderer>().sprite = supriseSlot.slotImage;
        }
        else if (slotType == Slot_Type.CornerSlot)
        {
            cornerSlot_Text.SetActive(true);
            if (cornerSlot.slotType == CornerSlot_Type.Go)
            {
                cornerSlot_Text.GetComponent<TextMeshPro>().text = "GO";
            }
            else if (cornerSlot.slotType == CornerSlot_Type.VisitingJail)
            {
                cornerSlot_Text.GetComponent<TextMeshPro>().text = "JAIL";
            }
            else if (cornerSlot.slotType == CornerSlot_Type.Parking)
            {
                cornerSlot_Text.GetComponent<TextMeshPro>().text = "PARK LOT";
            }
            else if (cornerSlot.slotType == CornerSlot_Type.GoToJail)
            {
                cornerSlot_Text.GetComponent<TextMeshPro>().text = "GO TO JAIL";
            }
        }
    }

    #region Slot Information

    public string getSlotName()
    {
        if (slotType == Slot_Type.ColorProperty)
        {
            return colorProperty.propertyName;
        }
        else if (slotType == Slot_Type.SpecialProperty)
        { 
            return specialProperty.propertyName;
        }
        else if (slotType == Slot_Type.SupriseSlot)
        {
            return supriseSlot.slotName;
        }
        else if (slotType == Slot_Type.CornerSlot)
        {
            if (cornerSlot.slotType == CornerSlot_Type.Go)
            {
                return "GO";
            }
            else if (cornerSlot.slotType == CornerSlot_Type.VisitingJail)
            {
                return "JAIL";
            }
            else if (cornerSlot.slotType == CornerSlot_Type.Parking)
            {
                return "PARK LOT";
            }
            else if (cornerSlot.slotType == CornerSlot_Type.GoToJail)
            {
                return "GO TO JAIL";
            }
            else
                return null;
        }
        else
        {
            return null;
        }
    }

    public int getSlotPrice()
    {
        if (slotType == Slot_Type.ColorProperty)
        {
            return colorProperty.propertyPrice;
        }
        else if (slotType == Slot_Type.SpecialProperty)
        {
            return specialProperty.propertyPrice;
        }
        else
            return 0;
    }

    public int getPropertyRent()
    {
        if (slotType == Slot_Type.ColorProperty)
        {
            if (numberOfHouse == 0)
            {
                if (!inSet)
                {
                    return colorProperty.rentPrice;
                }
                else
                {
                    return colorProperty.rentPrice_Set;
                }
            }
            if (numberOfHouse == 1)
            {
                return colorProperty.rentPrice_1House;
            }
            else if (numberOfHouse == 2)
            {
                return colorProperty.rentPrice_2House;
            }
            else if (numberOfHouse == 3)
            {
                return colorProperty.rentPrice_3House;
            }
            else if (numberOfHouse == 4)
            {
                return colorProperty.rentPrice_4House;
            }
            else if (numberOfHouse == 5)
            {
                return colorProperty.rentPrice_Hotel;
            }
            else
            {
                return 0;
            }
        }
        else if (slotType == Slot_Type.SpecialProperty)
        {
            if (specialProperty.propertyType == SpecialProperty_Type.RailRoad)
            {
                if (getOwner().railroadOwned == 1)
                {
                    return 25;
                }
                else if (getOwner().railroadOwned == 2)
                {
                    return 50;
                }
                else if (getOwner().railroadOwned == 3)
                {
                    return 100;
                }
                else if (getOwner().railroadOwned == 4)
                {
                    return 200;
                }
                else { return 0; }
            }
            else if (specialProperty.propertyType == SpecialProperty_Type.Utility)
            {
                if (getOwner().utilityOwned == 1)
                {
                    return Table.Instance.getCurrentPlayer().currentDices * 4;
                }
                else if (getOwner().utilityOwned == 2)
                {
                    return Table.Instance.getCurrentPlayer().currentDices * 10;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    public int getPropertyRentUI(int numOfHouse) //This is for UI
    {
        if (slotType == Slot_Type.ColorProperty)
        {
            if (numOfHouse == 0)
            {
                return colorProperty.rentPrice;
            }
            else if (numOfHouse == 1)
            {
                return colorProperty.rentPrice_1House;
            }
            else if (numOfHouse == 2)
            {
                return colorProperty.rentPrice_2House;
            }
            else if (numOfHouse == 3)
            {
                return colorProperty.rentPrice_3House;
            }
            else if (numOfHouse == 4)
            {
                return colorProperty.rentPrice_4House;
            }
            else if (numOfHouse == 5)
            {
                return colorProperty.rentPrice_Hotel;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    public int getBuildPrice()
    {
        if (slotType == Slot_Type.ColorProperty)
        {
            return colorProperty.buildPrice;
        }
        else
        {
            return 0;
        }
    }

    public int getSellPrice()
    {
        if (slotType == Slot_Type.ColorProperty)
        {
            return colorProperty.buildPrice / 2;
        }
        else
        {
            return 0;
        }
    }

    public int getMortgagePrice()
    {
        if (slotType == Slot_Type.ColorProperty)
        {
            return colorProperty.mortgagePrice;
        }
        else if (slotType == Slot_Type.SpecialProperty)
        {
            return specialProperty.mortgagePrice; 
        }
        else
        {
            return 0;
        }
    }

    public int getRedeemPrice()
    {
        if (slotType == Slot_Type.ColorProperty)
        {
            float price = (colorProperty.mortgagePrice + (((float)colorProperty.mortgagePrice / 100) * 10));
            return (int)price;
        }
        else if (slotType == Slot_Type.SpecialProperty)
        {
            float price = specialProperty.mortgagePrice + (((float)specialProperty.mortgagePrice / 100) * 10);
            return (int)price;
        }
        else
        {
            return 0;
        }
    }

    #endregion

    //Owner Set Get
    //

    public void setOwner(Player player)
    {
        if (!isOwned)
        {
            owner = player;
            isOwned = true;
            Table.Instance.getCurrentPlayer().slotOwned.Add(this);

            if (player.playerColor == new Vector4(255, 0, 0, 255)) //red
            {
                ownerTag.SetActive(true);
                redTag.SetActive(true);
                blueTag.SetActive(false);
                greenTag.SetActive(false);
                yellowTag.SetActive(false);
            }
            else if (player.playerColor == new Vector4(0, 0, 255, 255)) //blue
            {
                ownerTag.SetActive(true);
                redTag.SetActive(false);
                blueTag.SetActive(true);
                greenTag.SetActive(false);
                yellowTag.SetActive(false);
            }
            else if (player.playerColor == new Vector4(0, 255, 0, 255)) //green
            {
                ownerTag.SetActive(true);
                redTag.SetActive(false);
                blueTag.SetActive(false);
                greenTag.SetActive(true);
                yellowTag.SetActive(false);
            }
            else if (player.playerColor == new Vector4(255, 255, 0, 255)) //yellow
            {
                ownerTag.SetActive(true);
                redTag.SetActive(false);
                blueTag.SetActive(false);
                greenTag.SetActive(false);
                yellowTag.SetActive(true);
            }
        }
    }

    public Player getOwner() { return owner; }

    //Add houses
    //

    public void AddHouse()
    {
        if (numberOfHouse == 0)
        {
            numberOfHouse++;
            house1.SetActive(true);
            Table.Instance.getCurrentPlayer().houseOwned++;
        }
        else if (numberOfHouse == 1)
        {
            numberOfHouse++;
            house2.SetActive(true);
            Table.Instance.getCurrentPlayer().houseOwned++;
        }
        else if (numberOfHouse == 2)
        {
            numberOfHouse++;
            house3.SetActive(true);
            Table.Instance.getCurrentPlayer().houseOwned++;
        }
        else if (numberOfHouse == 3)
        {
            numberOfHouse++;
            house4.SetActive(true);
            Table.Instance.getCurrentPlayer().houseOwned++;
        }
        else if (numberOfHouse == 4)
        {
            numberOfHouse++;
            hotel.SetActive(true);
            house1.SetActive(false);
            house2.SetActive(false);
            house3.SetActive(false);
            house4.SetActive(false);
            Table.Instance.getCurrentPlayer().houseOwned -= 4;
            Table.Instance.getCurrentPlayer().hotelOwned++;
        }
    }

    public void RemoveHouse()
    {
        if (numberOfHouse == 5)
        {
            numberOfHouse--;
            hotel.SetActive(false);
            house1.SetActive(true);
            house2.SetActive(true);
            house3.SetActive(true);
            house4.SetActive(true);
        }
        else if (numberOfHouse == 4)
        {
            numberOfHouse--;
            house4.SetActive(false);
        }
        else if (numberOfHouse == 3)
        {
            numberOfHouse--;
            house3.SetActive(false);
        }
        else if (numberOfHouse == 2)
        {
            numberOfHouse--;
            house2.SetActive(false);
        }
        else if (numberOfHouse == 1)
        {
            numberOfHouse--;
            house1.SetActive(false);
        }
    }

    //Player On slot Position
    //

    public List<Player> temp_playerOnSlot = new List<Player>();
    public void setPlayerPos(List<Player> playerOnSlot)
    {
        temp_playerOnSlot.Clear();
        temp_playerOnSlot = playerOnSlot;
        if (playerOnSlot.Count == 1)
        {
            LeanTween.move(playerOnSlot[0].gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), .25f).setEaseInOutCirc();
        }
        else if (playerOnSlot.Count == 2)
        {
            LeanTween.move(playerOnSlot[0].gameObject, new Vector3(gameObject.transform.position.x + .1f, gameObject.transform.position.y + .1f), .25f).setEaseInOutCirc();
            LeanTween.move(playerOnSlot[1].gameObject, new Vector3(gameObject.transform.position.x + -.1f, gameObject.transform.position.y + -.1f), .25f).setEaseInOutCirc();
        }
        else if (playerOnSlot.Count == 3)
        {
            LeanTween.move(playerOnSlot[0].gameObject, new Vector3(gameObject.transform.position.x + .1f, gameObject.transform.position.y + .1f), .25f).setEaseInOutCirc();
            LeanTween.move(playerOnSlot[1].gameObject, new Vector3(gameObject.transform.position.x + -.1f, gameObject.transform.position.y + .1f), .25f).setEaseInOutCirc();
            LeanTween.move(playerOnSlot[2].gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + -.1f), .25f).setEaseInOutCirc();
        }
        else if (playerOnSlot.Count == 4)
        {
            LeanTween.move(playerOnSlot[0].gameObject, new Vector3(gameObject.transform.position.x + .1f, gameObject.transform.position.y + .1f), .25f).setEaseInOutCirc();
            LeanTween.move(playerOnSlot[1].gameObject, new Vector3(gameObject.transform.position.x + -.1f, gameObject.transform.position.y + .1f), .25f).setEaseInOutCirc();
            LeanTween.move(playerOnSlot[2].gameObject, new Vector3(gameObject.transform.position.x + .1f, gameObject.transform.position.y + -.1f), .25f).setEaseInOutCirc();
            LeanTween.move(playerOnSlot[3].gameObject, new Vector3(gameObject.transform.position.x + -.1f, gameObject.transform.position.y + -.1f), .25f).setEaseInOutCirc();
        }
    }
    public void setPlayerLeave(List<Player> playerOnSlot)
    {
        if (playerOnSlot.Count == 1)
        {
            LeanTween.move(playerOnSlot[0].gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), .15f).setDelay(.5f);
        }
        else if (playerOnSlot.Count == 2)
        {
            LeanTween.move(playerOnSlot[0].gameObject, new Vector3(gameObject.transform.position.x + .1f, gameObject.transform.position.y + .1f), .15f).setDelay(.5f);
            LeanTween.move(playerOnSlot[1].gameObject, new Vector3(gameObject.transform.position.x + -.1f, gameObject.transform.position.y + -.1f), .15f).setDelay(.5f);
        }
        else if (playerOnSlot.Count == 3)
        {
            LeanTween.move(playerOnSlot[0].gameObject, new Vector3(gameObject.transform.position.x + .1f, gameObject.transform.position.y + .1f), .15f).setDelay(.5f);
            LeanTween.move(playerOnSlot[1].gameObject, new Vector3(gameObject.transform.position.x + -.1f, gameObject.transform.position.y + .1f), .15f).setDelay(.5f);
            LeanTween.move(playerOnSlot[2].gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + -.1f), .15f).setDelay(.5f);
        }
        else if (playerOnSlot.Count == 4)
        {
            LeanTween.move(playerOnSlot[0].gameObject, new Vector3(gameObject.transform.position.x + .1f, gameObject.transform.position.y + .1f), .15f).setDelay(.5f);
            LeanTween.move(playerOnSlot[1].gameObject, new Vector3(gameObject.transform.position.x + -.1f, gameObject.transform.position.y + .1f), .15f).setDelay(.5f);
            LeanTween.move(playerOnSlot[2].gameObject, new Vector3(gameObject.transform.position.x + .1f, gameObject.transform.position.y + -.1f), .15f).setDelay(.5f);
            LeanTween.move(playerOnSlot[3].gameObject, new Vector3(gameObject.transform.position.x + -.1f, gameObject.transform.position.y + -.1f), .15f).setDelay(.5f);
        }
    }


    //Click on Slot 
    //

    public void OnMouseDown()
    {
        if (slotAction == SlotAction.Idle)
        {
            if (slotType == Slot_Type.ColorProperty || slotType == Slot_Type.SpecialProperty)
            {
                UIManager.Instance.OnClick_ShowInformationCard(this);
            }
        }
        else if (slotAction == SlotAction.Build) //Build House
        {
            AddHouse();
            Table.Instance.CurrentPlayerInstantPayBank(getBuildPrice());
            Table.Instance.Build();
        }
        else if (slotAction == SlotAction.Sell)
        {
            RemoveHouse();
            Table.Instance.CurrentPlayerInstantReceiveBank(getSellPrice());
            Table.Instance.Sell();
        }
        else if (slotAction == SlotAction.Mortgage)
        {
            if (!isMortgaged)
            {
                Table.Instance.CurrentPlayerInstantReceiveBank(getMortgagePrice());
                isMortgaged = true;
                mortgagedTag.SetActive(true);
            }
        }
        else if (slotAction == SlotAction.Redeem)
        {
            if (isMortgaged)
            {
                Table.Instance.CurrentPlayerInstantPayBank(getRedeemPrice());
                isMortgaged = false;
                mortgagedTag.SetActive(false);
                gameObject.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, .5f);
            }
        }
    }
}
