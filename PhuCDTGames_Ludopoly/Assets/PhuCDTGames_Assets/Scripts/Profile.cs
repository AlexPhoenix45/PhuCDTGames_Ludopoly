using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameAdd_Ludopoly
{
    public class Profile : MonoBehaviour
    {
        public GameObject red;
        public GameObject green;
        public GameObject blue;
        public GameObject yellow;

        public void SetProfile(Player player)
        {
            if (player == Table.Instance.player[0])
            {
                red.SetActive(true);
                green.SetActive(false);
                blue.SetActive(false);
                yellow.SetActive(false);
            }
            else if (player == Table.Instance.player[1])
            {
                red.SetActive(false);
                green.SetActive(false);
                blue.SetActive(true);
                yellow.SetActive(false);
            }
            else if (player == Table.Instance.player[2])
            {
                red.SetActive(false);
                green.SetActive(true);
                blue.SetActive(false);
                yellow.SetActive(false);
            }
            else if (player == Table.Instance.player[3])
            {
                red.SetActive(false);
                green.SetActive(false);
                blue.SetActive(false);
                yellow.SetActive(true);
            }
        }

    }
}
