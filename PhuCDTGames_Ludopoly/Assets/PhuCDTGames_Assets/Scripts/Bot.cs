using GameAdd_Ludopoly;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public UIManager _UIManager;
    public Table _Table;
    public Player myPlayer;
    public LiveUpdate _liveUpdate;

    public void Execute()
    {
        IEnumerator delay()
        {
            float random = UnityEngine.Random.Range(.5f, 1.2f);
            yield return new WaitForSeconds(random);

            if (_liveUpdate.NotUIExecute) //Do 3 options (end turn, done, main actions)
            {
                if (_liveUpdate.ReadyRollDice && _liveUpdate.ReadyMainActions) //Roll Dice & Main Actions
                {
                    RollDice();
                }
                else if (_liveUpdate.ReadyEndTurn && _liveUpdate.ReadyMainActions) //End Turn & Main Actions
                {
                    EndTurn();
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
        _UIManager.OnClick_RollDice();
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
        print(int.Parse(_UIManager.ai_currentPrice.text) + " auction max");
        print(_Table.getSlot(myPlayer.currentSlot).getSlotPrice() + " slot price");

        if (int.Parse(_UIManager.ai_currentPrice.text) > _Table.getSlot(myPlayer.currentSlot).getSlotPrice())
        {
            _UIManager.OnClick_Auction_Withdraw();
        }
        else
        {
            int random = UnityEngine.Random.Range(0, 2);

            if (random == 0)
            {
                _UIManager.OnClick_Auction_SmallBid();
            }
            else
            {
                _UIManager.OnClick_Auction_BigBid();
            }
        }
    }

    public void JailSelection ()
    {
        if (myPlayer.getPlayerMoney() > 100)
        {
            _UIManager.OnClick_JailPay();
        }
    }

    public void EndTurn()
    {
        _UIManager.OnClick_EndTurn();
    }
}
