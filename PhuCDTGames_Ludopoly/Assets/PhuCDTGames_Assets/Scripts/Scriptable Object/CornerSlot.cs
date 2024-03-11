using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameAdd_Ludopoly
{
    [CreateAssetMenu(fileName = "Corner Slot", menuName = "Slot/Corner Slot")]
    public class CornerSlot : ScriptableObject
    {
        public Sprite slotImage;
  
        public CornerSlot_Type slotType;
    }
}