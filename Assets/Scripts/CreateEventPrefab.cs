using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEventPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;
    void Start()
    {
        GameObject eventLoader = GameObject.FindGameObjectWithTag("SceneLoader");
        if(eventLoader == null) {
            Instantiate(myPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
