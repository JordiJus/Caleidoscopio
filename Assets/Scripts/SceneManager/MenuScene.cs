using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public GameObject playerStats;
    public GameObject sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("PlayerStats");
        if(playerStats != null) {
            Destroy(playerStats);
        }
        sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader");
        if(sceneLoader != null) {
            Destroy(sceneLoader);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) {
            SceneManager.LoadScene(1);
        }
    }
}
