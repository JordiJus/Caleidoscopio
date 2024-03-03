using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

[CreateAssetMenu]
public class SceneObjectLoader : ScriptableObject
{
    [System.Serializable]
    public class Memories {
        public Dialogue dialogue;
        public Sprite background;
    }
    
    public int counter;
    public int maxCounter;
    public List<Memories> memories = new List<Memories>();

}
