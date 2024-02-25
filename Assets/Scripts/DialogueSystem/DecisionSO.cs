using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class Decision : ScriptableObject
{
    public string keySentence;

    [System.Serializable]
    public class Elections
    {
        [TextArea(3, 5)]
        public string decisionSentence;
        public Dialogue dialogue;
    }
    public Dialogue dialogueComun;
    public List<Elections> decisions = new List<Elections>();
}
