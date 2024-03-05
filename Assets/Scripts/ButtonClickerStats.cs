using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickerStats : MonoBehaviour
{
    public PlayerStats playerStats;
    public bool maldad;
    public bool agresividad;
    
    Button decisionButton;
    void Start()
    {
        decisionButton = GetComponent<Button>();
        playerStats = FindObjectOfType<PlayerStats>();
        if(playerStats == null){
            Debug.Log("Error");
        }
        Debug.Log(playerStats.health);
        decisionButton.onClick.AddListener(updatePlayerStats);
    }

    void OnEnable(){
        decisionButton.onClick.AddListener(updatePlayerStats);
    }

    // Update is called once per frame
    public void updatePlayerStats()
    {
        if(maldad == true){
            Debug.Log("MALOOOOOO");
            playerStats.maldad++;
        }
        if(agresividad == true){
            Debug.Log("BRUTOOOOOOO");
            playerStats.agresividad++;
        }

        Debug.Log("Agresividad: " + playerStats.agresividad + " y Maldad: " + playerStats.maldad);
    }

    void OnDisable()
    {
        decisionButton.onClick.RemoveListener(updatePlayerStats);
    }
}
