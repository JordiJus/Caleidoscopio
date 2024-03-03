using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneGameplay : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerStats playerStats;
    void Start(){
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.F1)) {
            SceneManager.LoadScene(2);
        }
        
    }
}
