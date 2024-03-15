using GameAdd_Ludopoly;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public UIManager _UIManager;
    public Table _Table;
    public void RollDice()
    {
        IEnumerator action()
        {
            yield return new WaitForSeconds(.5f);
            _UIManager.OnClick_RollDice();
        }
        StartCoroutine(action());
    }

    public void BuyOrAuction(Player myPlayer)
    {
        IEnumerator action()
        {
            yield return new WaitForSeconds(1f);
            if (myPlayer.playerMoney >= _Table.getSlot(myPlayer.currentSlot).getSlotPrice()) //neu du tien mua property do
            {
                _UIManager.OnClick_Buy();
            }
            else
            {
                _UIManager.OnClick_Auction();
            }
        }
        StartCoroutine(action());
    }

    public void AuctionSelection(Player myPlayer)
    {
        IEnumerator action()
        {
            yield return new WaitForSeconds(1);
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
            StartCoroutine(action());
        }
    }

    public void JailSelection (Player myPlayer)
    {
        if (myPlayer.getPlayerMoney() > 100)
        {
            _UIManager.OnClick_JailPay();
        }
    }

    public void EndTurn()
    {
        IEnumerator action()
        {
            yield return new WaitForSeconds(.5f);
            _UIManager.OnClick_EndTurn();
        }
        StartCoroutine(action());
    }
}
