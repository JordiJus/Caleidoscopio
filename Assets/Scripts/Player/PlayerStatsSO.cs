using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class PlayerStats : ScriptableObject{
    public int health;
    public int maxHealth;
    public Transform position;
    public int maldad;
    public int agresividad;
}
