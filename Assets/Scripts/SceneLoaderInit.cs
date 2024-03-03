using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class SceneLoaderInit : MonoBehaviour
{
    public SceneObjectLoader sceneLoader;
    public int counter;
    public int maxCounter;
    public List<SceneObjectLoader.Memories> memories;
    void Start()
    {
        
        if (sceneLoader == null) {
            sceneLoader = ScriptableObject.CreateInstance<SceneObjectLoader>();
            sceneLoader.memories = memories;
            sceneLoader.counter = counter;
            sceneLoader.maxCounter = maxCounter;
            
            
        }
        DontDestroyOnLoad(gameObject);
        
    }
}
