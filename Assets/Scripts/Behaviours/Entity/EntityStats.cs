using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public int MaxHealthPoint;
    private int currentHealthPoint;
    public int CurrentHealthPoint {
        get {return currentHealthPoint;}
        set {currentHealthPoint = value < 0 ? 0 : value; }
    }
    public int MoveSpeed;
    public int JumpForce;
    private bool isAlive = true;
    public bool IsAlive {
        get {return isAlive;}
        set {isAlive = value;}
    }
}
