using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Corner Slot", menuName = "Slot/Corner Slot")]
public class CornerSlot : ScriptableObject
{
    public Sprite slotImage;
    public enum Type
    {
        Go,
        VisitingJail,
        Parking,
        GoToJail
    }
    public Type slotType;
}
