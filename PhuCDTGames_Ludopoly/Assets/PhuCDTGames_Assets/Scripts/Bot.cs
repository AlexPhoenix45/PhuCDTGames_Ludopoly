using GameAdd_Ludopoly;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [HideInInspector]
    public UIManager _UIManager;
    [HideInInspector]
    public Table _Table;
    [HideInInspector]
    public Player myPlayer;
    [HideInInspector]
    public LiveUpdate _liveUpdate;

    [SerializeField]
    List<Slot> mySlots = new List<Slot>();
    [SerializeField]
    List<Slot> unSetSlot = new List<Slot>();
    [SerializeField]
    List<Slot> unHouseSlot = new List<Slot>();
    [SerializeField]
    List<Slot> houseSlot = new List<Slot>();

    [Header("PROPERTIES")]
    [Tooltip("This variable is how many percentage of a SlotPrice you can afford")]
    public float OverBudgetPercentage = 125.00f;
    [Tooltip("Trying to auction all stations")]
    public bool stationAuction = false;
    [Tooltip("If playerMoney < <var>, Bot will trying to Roll instead of instant Pay")]
    public int moneyBound = 300;
    [Tooltip("If playerMoney > <var>, Bot will consider to Build houses")]
    public int buildBudget = 300;
    [Tooltip("If playerMoney > <var>, Bot will consider to Trade")]
    public int tradeBudget = 200;


    public void Execute()
    {
        IEnumerator delay()
        {
            float random = UnityEngine.Random.Range(.7f, 1.5f);
            yield return new WaitForSeconds(random);

            if (_liveUpdate.NotUIExecute) //Do 3 options (end turn, done, main actions)
            {
                if (_liveUpdate.ReadyRollDice && _liveUpdate.ReadyMainActions) //Roll Dice & Main Actions
                {
                    RollDice();
                }
                else if (_liveUpdate.ReadyEndTurn && _liveUpdate.ReadyMainActions) //End Turn & Main Actions
                {
                    MainActionsConsidering();
                }
            }
            else if (_liveUpdate.UIExecute) //Do others
            {
                if (_liveUpdate.ReadyToChoose_Property)
                {
                    BuyOrAuction();
                }
                else if (_liveUpdate.ReadyToChoose_Auction)
                {
                    AuctionSelection();
                }
                else if (_liveUpdate.ReadyToChoose_Jail)
                {
                    JailSelection();
                }
                else if (_liveUpdate.ReadyToChoose_Bankrupt)
                {
                    BankruptSelection();
                }
                else if (_liveUpdate.ReadyToChoose_Trade)
                {

                }
            }
        }
        StartCoroutine(delay());    
    }

    public void RollDice()
    {
        if (myPlayer.isBotPlaying)
        {
            _UIManager.OnClick_RollDice();
        }
        else
        {
            return;
        }
    }

    public void BuyOrAuction()
    {
        if (myPlayer.playerMoney >= _Table.getSlot(myPlayer.currentSlot).getSlotPrice()) //neu du tien mua property do
        {
            _UIManager.OnClick_Buy();
        }
        else
        {
            _UIManager.OnClick_Auction();
        }
    }

    public void AuctionSelection()
    {

        List<Player> remainingPlayer = new List<Player>();
        int maxMoney = 0;
        int currentMaxPrice = _Table.auc_currentPrice;
        int currentSlotPrice = _Table.getSlot(_Table.auc_slotNumber).getSlotPrice();

        foreach (Player p in _Table.player)
        {
            if (p.gameObject.activeSelf && p != myPlayer && p.inAuction)
            {
                remainingPlayer.Add(p);
                if (maxMoney < p.playerMoney)
                {
                    maxMoney = p.playerMoney;
                }
            }
        }

        if (currentMaxPrice < myPlayer.playerMoney)
        {
            if (maxMoney <= 100)
            {
                if (currentMaxPrice + 10 <= myPlayer.playerMoney)
                {
                    _UIManager.OnClick_Auction_SmallBid();
                }
                else
                {
                    _UIManager.OnClick_Auction_Withdraw();
                }
            }
            else
            {
                if (maxMoney < currentSlotPrice)
                {
                    if (currentMaxPrice + 100 < maxMoney)
                    {
                        if (currentMaxPrice + 10 <= myPlayer.playerMoney)
                        {
                            _UIManager.OnClick_Auction_SmallBid();
                        }
                        else
                        {
                            _UIManager.OnClick_Auction_Withdraw();
                        }
                    }
                    else
                    {
                        if (currentMaxPrice + 100 <= myPlayer.playerMoney)
                        {
                            _UIManager.OnClick_Auction_BigBid();
                        }
                        else
                        {
                            _UIManager.OnClick_Auction_Withdraw();
                        }
                    }
                }
                else
                {
                    if (ColorSetExecute(_Table.getSlot(_Table.auc_slotNumber)))
                    {
                        if (currentMaxPrice < currentSlotPrice / 100 * OverBudgetPercentage)
                        {
                            if (currentMaxPrice + 100 > myPlayer.playerMoney)
                            {
                                if (currentMaxPrice + 10 <= myPlayer.playerMoney)
                                {
                                    _UIManager.OnClick_Auction_SmallBid();
                                }
                                else
                                {
                                    _UIManager.OnClick_Auction_Withdraw();
                                }
                            }
                            else
                            {
                                if (currentMaxPrice + 100 <= myPlayer.playerMoney)
                                {
                                    _UIManager.OnClick_Auction_BigBid();
                                }
                                else
                                {
                                    _UIManager.OnClick_Auction_Withdraw();
                                }
                            }
                        }
                        else
                        {
                            _UIManager.OnClick_Auction_Withdraw();
                        }
                    }
                    else
                    {
                        if (currentMaxPrice < currentSlotPrice && currentMaxPrice + 10 <= myPlayer.playerMoney)
                        {
                            if (currentMaxPrice + 100 > currentSlotPrice || currentMaxPrice + 100 > myPlayer.playerMoney)
                            {
                                if (currentMaxPrice + 10 <= myPlayer.playerMoney)
                                {
                                    _UIManager.OnClick_Auction_SmallBid();
                                }
                                else
                                {
                                    _UIManager.OnClick_Auction_Withdraw();
                                }
                            }
                            else
                            {
                                if (currentMaxPrice + 100 <= myPlayer.playerMoney)
                                {
                                    _UIManager.OnClick_Auction_BigBid();
                                }
                                else
                                {
                                    _UIManager.OnClick_Auction_Withdraw();
                                }
                            }
                        }
                        else
                        {
                            _UIManager.OnClick_Auction_Withdraw();
                        }
                    }
                }
            }
        }
        else
        {
            _UIManager.OnClick_Auction_Withdraw();
        }

        bool ColorSetExecute(Slot slot)
        {
            if (slot.slotIndex == 1 || slot.slotIndex == 3)
            {
                if (slot.slotIndex == 1)
                {
                    return SlotCheck(1, 3, -1);
                }
                else if (slot.slotIndex == 3)
                {
                    return SlotCheck(3, 1, -1);
                }
                else
                {
                    return false;
                }
            }
            else if (slot.slotIndex == 6 || slot.slotIndex == 8 || slot.slotIndex == 9)
            {
                if (slot.slotIndex == 6)
                {
                    return SlotCheck(6, 8, 9);
                }
                else if (slot.slotIndex == 8)
                {
                    return SlotCheck(8, 6, 9);
                }
                else if (slot.slotIndex == 9)
                {
                    return SlotCheck(9, 6, 8);
                }
                else
                {
                    return false;
                }
            }
            else if (slot.slotIndex == 11 || slot.slotIndex == 13 || slot.slotIndex == 14)
            {
                if (slot.slotIndex == 11)
                {
                    return SlotCheck(11, 13, 14);
                }
                else if (slot.slotIndex == 13)
                {
                    return SlotCheck(13, 11, 14);
                }
                else if (slot.slotIndex == 14)
                {
                    return SlotCheck(14, 11, 13);
                }
                else
                {
                    return false;
                }
            }
            else if (slot.slotIndex == 16 || slot.slotIndex == 18 || slot.slotIndex == 19)
            {

                if (slot.slotIndex == 16)
                {
                    return SlotCheck(16, 18, 19);
                }
                else if (slot.slotIndex == 18)
                {
                    return SlotCheck(18, 16, 19);
                }
                else if (slot.slotIndex == 19)
                {
                    return SlotCheck(19, 16, 18);
                }
                else
                {
                    return false;
                }
            }
            else if (slot.slotIndex == 21 || slot.slotIndex == 23 || slot.slotIndex == 24)
            {
                if (slot.slotIndex == 21)
                {
                    return SlotCheck(21, 23, 24);
                }
                else if (slot.slotIndex == 23)
                {
                    return SlotCheck(23, 21, 24);
                }
                else if (slot.slotIndex == 24)
                {
                    return SlotCheck(24, 23, 21);
                }
                else
                {
                    return false;
                }
            }
            else if (slot.slotIndex == 26 || slot.slotIndex == 27 || slot.slotIndex == 29)
            {
                if (slot.slotIndex == 26)
                {
                    return SlotCheck(26, 27, 29);
                }
                else if (slot.slotIndex == 27)
                {
                    return SlotCheck(27, 26, 29);
                }
                else if (slot.slotIndex == 29)
                {
                    return SlotCheck(29, 26, 27);
                }
                else
                {
                    return false;
                }
            }
            else if (slot.slotIndex == 31 || slot.slotIndex == 32 || slot.slotIndex == 34)
            {
                if (slot.slotIndex == 31)
                {
                    return SlotCheck(31, 32, 34);
                }
                else if (slot.slotIndex == 32)
                {
                    return SlotCheck(32, 31, 34);
                }
                else if (slot.slotIndex == 34)
                {
                    return SlotCheck(34, 32, 31);
                }
                else
                {
                    return false;
                }
            }
            else if (slot.slotIndex == 37 || slot.slotIndex == 39)
            {
                if (slot.slotIndex == 37)
                {
                    return SlotCheck(37, 39, -1);
                }
                else if (slot.slotIndex == 39)
                {
                    return SlotCheck(39, 37, -1);
                }
                else
                {
                    return false;
                }
            }
            else if (slot.slotIndex == 5 || slot.slotIndex == 15 || slot.slotIndex == 25 || slot.slotIndex == 35)
            {
                if (stationAuction)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        bool SlotCheck(int checkSlot, int slot1, int slot2)
        {
            if (slot2 == -1)
            {
                if (_Table.getSlot(slot1).owner == myPlayer)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (_Table.getSlot(slot1).owner == myPlayer && _Table.getSlot(slot2).owner == myPlayer)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    public void JailSelection ()
    {
        if (myPlayer.getPlayerJailFreeCard() > 0)
        {
            _UIManager.OnClick_JailUseCard();
        }
        //else if (_Table)

        //if (myPlayer.getPlayerMoney() > 100)
        //{
        //    _UIManager.OnClick_JailPay();
        //}

        if (ShouldIGetOut())
        {
            if (myPlayer.getPlayerJailFreeCard() > 0)
            {
                _UIManager.OnClick_JailUseCard();
            }
            else
            {
                if (myPlayer.playerMoney > moneyBound)
                {
                    _UIManager.OnClick_JailPay();
                }
                else if (myPlayer.playerMoney < moneyBound && myPlayer.playerMoney > moneyBound / 2)
                {
                    if (myPlayer.timesNotGetDoubles < UnityEngine.Random.Range(1, 3))
                    {
                        _UIManager.OnClick_JailRollDouble();
                    }
                    else
                    {
                        _UIManager.OnClick_JailPay();
                    }
                }
                else if (myPlayer.playerMoney < moneyBound / 2)
                {
                    _UIManager.OnClick_JailRollDouble();
                }
            }
        }
        else
        {
            if (myPlayer.getPlayerJailFreeCard() > 0)
            {
                _UIManager.OnClick_JailUseCard();
            }
            else
            {
                _UIManager.OnClick_JailRollDouble();
            }
        }

        bool ShouldIGetOut()
        {
            int notMyProps = 0;

            if (_Table.getSlot(12).owner != null && _Table.getSlot(12).owner != myPlayer)
            {
                notMyProps++;
            }
            if (_Table.getSlot(13).owner != null && _Table.getSlot(13).owner != myPlayer)
            {
                notMyProps++;
            }
            if (_Table.getSlot(14).owner != null && _Table.getSlot(14).owner != myPlayer)
            {
                notMyProps++;
            }
            if (_Table.getSlot(15).owner != null && _Table.getSlot(15).owner != myPlayer)
            {
                notMyProps++;
            }
            if (_Table.getSlot(16).owner != null && _Table.getSlot(16).owner != myPlayer)
            {
                notMyProps++;
            }
            if (_Table.getSlot(18).owner != null && _Table.getSlot(18).owner != myPlayer)
            {
                notMyProps++;
            }
            if (_Table.getSlot(19).owner != null && _Table.getSlot(19).owner != myPlayer)
            {
                notMyProps++;
            }
            if (_Table.getSlot(21).owner != null && _Table.getSlot(21).owner != myPlayer)
            {
                notMyProps++;
            }

            if (notMyProps < 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void BankruptSelection()
    {
        if (myPlayer.slotOwned.Count == 0 || isAllMyPropsAbandoned()) //this is when we have no property or all props has
        {
            _UIManager.OnClick_Bankrupt();
        }
        else
        {
            _UIManager.OnClick_PayDebt();
            BankruptRecover();
        }

        bool isAllMyPropsAbandoned()
        {
            foreach (Slot slot in myPlayer.slotOwned)
            {
                if (!slot.isMortgaged)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public void BankruptRecover()
    {
        SortingSlot();

        int i = 0;

        IEnumerator delay()
        {
            yield return new WaitForSeconds(1f);
            do
            {
                if (unSetSlot.Count != 0) //ban dat k cung mau truoc 
                {
                    unSetSlot[0].Mortgage();
                    unSetSlot.RemoveAt(0);
                }
                else
                {
                    if (unHouseSlot.Count != 0) //sau do den ban dat cung mau k co nha
                    {
                        unHouseSlot[0].Mortgage();
                        unHouseSlot.RemoveAt(0);
                    }
                    else //sau do ban nha
                    {
                        if (houseSlot[i].slotAction == SlotAction.Sell)
                        {
                            houseSlot[i].Sell();
                            houseSlot.RemoveAt(i);
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
            while (myPlayer.playerMoney <= 0);

            //print("running slot" + unSetSlot[0].slotIndex);
            LiveUpdate.Instance.OptionsUpdate();
        }

        StartCoroutine(delay());
    }

    public void MainActionsConsidering()
    {
        IEnumerator wait()
        {
            SortingSlot();
            if (myPlayer.playerMoney > buildBudget && (unHouseSlot.Count > 0 || houseSlot.Count > 0)) //1. Bot se dung toan bo tien xay nha thua ra buildBudget (300) vang
            {
                _UIManager.OnClick_Build();
                if (unHouseSlot.Count != 0)
                {
                    foreach (Slot slot in unHouseSlot)
                    {
                        if (slot.slotAction == SlotAction.Build)
                        {
                            slot.Build();
                        }

                        if (myPlayer.PlayerMoney < buildBudget)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Slot slot in houseSlot)
                    {
                        if (slot.slotAction == SlotAction.Build)
                        {
                            slot.Build();
                        }

                        if (myPlayer.PlayerMoney < buildBudget)
                        {
                            break;
                        }
                    }
                }

                _UIManager.OnClick_ActionsClose();
                yield return new WaitForSeconds(UnityEngine.Random.Range(.5f, 1f));
                EndTurn();
            }
            else if (myPlayer.playerMoney > tradeBudget)
            {
                TradeSelection();
                yield return new WaitForSeconds(UnityEngine.Random.Range(.5f, 1f));
                EndTurn();
            }
            else
            {
                yield return new WaitForSeconds(UnityEngine.Random.Range(.5f, 1f));
                EndTurn();
            }
        }
        StartCoroutine(wait());
    }

    /// <summary>
    /// This function is for sorting Slot (UnColorSet, ColorSet, House Slot)
    /// </summary>
    public void SortingSlot()
    {
        mySlots = myPlayer.slotOwned;

        unSetSlot.Clear();
        unHouseSlot.Clear();
        houseSlot.Clear();

        foreach (Slot slot in mySlots)
        {
            if (!slot.isMortgaged && !slot.inSet && slot.numberOfHouse == 0)
            {
                unSetSlot.Add(slot);
            }
            else if (!slot.isMortgaged && slot.inSet && slot.numberOfHouse == 0)
            {
                unHouseSlot.Add(slot);
            }
            else if (!slot.isMortgaged && slot.inSet && slot.numberOfHouse != 0)
            {
                houseSlot.Add(slot);
            }
        }

        //Sort
        unSetSlot = unSetSlot.OrderBy(slot => slot.getMortgagePrice()).ToList();
        unHouseSlot = unHouseSlot.OrderBy(slot => slot.getMortgagePrice()).ToList();
        houseSlot = houseSlot.OrderBy(slot => slot.getMortgagePrice()).ToList();

    }

    public void TradeSelection()
    {
        myPlayer.wishedSlot = myPlayer.wishedSlot.OrderBy(x => Random.value).ToList();
        myPlayer.slotOwned = myPlayer.slotOwned.OrderBy(x => Random.value).ToList();
        if (myPlayer.playerMoney >= tradeBudget)
        {
            foreach (var opponent in _Table.player) //Trong tat ca player
            {
                if (opponent.gameObject.activeSelf) //Trong nhung player con choi
                {
                    foreach (var myWished in myPlayer.wishedSlot) //Trong tat ca nhung Wishedslot cua minh`
                    {
                        if (opponent.slotOwned.Find(x => x = myWished) && !myWished.isMortgaged) //Trong slotOwned cua doi thu do WishedSlot cua minh
                        {
                            foreach (var mySlot in myPlayer.slotOwned) //Trong slotOwned cua minh
                            {
                                if (opponent.wishedSlot.Find(x => x = mySlot) && !mySlot.isMortgaged) //Neu so WishedSlot cua doi phuong thi`
                                {
                                    PropertyCard[] myCard = new PropertyCard[1];
                                    myCard[0].TradeShowCard(mySlot.slotIndex);
                                    PropertyCard[] opponentCard = new PropertyCard[1];
                                    opponentCard[0].TradeShowCard(myWished.slotIndex);
                                    _UIManager.OnClick_Trade_Offer_Bot(opponentCard, myCard, 0, 0);
                                }
                                else if (!mySlot.inSet) //not in set Slot
                                {
                                    PropertyCard[] myCard = new PropertyCard[1];
                                    myCard[0].TradeShowCard(mySlot.slotIndex);
                                    PropertyCard[] opponentCard = new PropertyCard[1];
                                    opponentCard[0].TradeShowCard(myWished.slotIndex);
                                    _UIManager.OnClick_Trade_Offer_Bot(opponentCard, myCard, 0, 0);
                                }
                                else if (myPlayer.playerMoney > mySlot.getSlotPrice() / 2) //my money is larger than slot money / 2
                                {
                                    PropertyCard[] myCard = new PropertyCard[0];
                                    //myCard[0].TradeShowCard(mySlot.slotIndex);
                                    PropertyCard[] opponentCard = new PropertyCard[1];
                                    opponentCard[0].TradeShowCard(myWished.slotIndex);
                                    int myMoneyToTrade = (int)(mySlot.getSlotPrice() / UnityEngine.Random.Range(1.15f, 2f));
                                    _UIManager.OnClick_Trade_Offer_Bot(opponentCard, myCard, 0, myMoneyToTrade);
                                }
                                else //neu k du tien bang 1/2 slot do thi` lay 90% so tien ra doi
                                {
                                    PropertyCard[] myCard = new PropertyCard[0];
                                    //myCard[0].TradeShowCard(mySlot.slotIndex);
                                    PropertyCard[] opponentCard = new PropertyCard[1];
                                    opponentCard[0].TradeShowCard(myWished.slotIndex);
                                    int myMoneyToTrade = myPlayer.playerMoney / 100 * 90;
                                    _UIManager.OnClick_Trade_Offer_Bot(opponentCard, myCard, 0, myMoneyToTrade);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    
    public void EndTurn()
    {
        _UIManager.OnClick_EndTurn();
    }
}
