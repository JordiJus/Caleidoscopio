using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsInitializer : MonoBehaviour
{
    public PlayerStats playerStats;
    public Transform initialPos;
    private void Awake()
    {
        
        if (playerStats == null)
        {
            playerStats = ScriptableObject.CreateInstance<PlayerStats>();
            playerStats.maxHealth = 10;
            playerStats.health = playerStats.maxHealth;


        }

        DontDestroyOnLoad(gameObject);
    }
}
