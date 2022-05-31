using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public int MaxHealthPoint;
    public int CurrentHealthPoint {
        get {return CurrentHealthPoint;}
        set {CurrentHealthPoint = value < 0 ? 0 : value; }
    }
    public int MoveSpeed;
    public int JumpForce;
}
