using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEventPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;
    public GameObject playerStatsPrefab;
    void Awake()
    {
        GameObject eventLoader = GameObject.FindGameObjectWithTag("SceneLoader");
        if(eventLoader == null) {
            Instantiate(myPrefab);
        }

        GameObject playerStats = GameObject.FindGameObjectWithTag("PlayerStats");
        if(playerStats == null) {
            Instantiate(playerStatsPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
