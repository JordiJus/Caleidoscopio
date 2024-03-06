using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public Slider slider;
    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        slider.maxValue = playerStats.maxHealth;
        slider.value = playerStats.health;
        Debug.Log(playerStats.maxHealth);
        Debug.Log(playerStats.health);
        Debug.Log(slider.value);
        Debug.Log("Agresividad: " + playerStats.agresividad + " y Maldad: " + playerStats.maldad);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerStats.health;
        
        if (playerStats.health <= 0){
            Debug.Log("Died");
            playerDied();
        }
    }

    void playerDied(){
        SceneManager.LoadScene(3);
    }
}
