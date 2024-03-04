using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class Dialogue : ScriptableObject
{

    [System.Serializable]
    public class Sentence
    {
        public string name;
        [TextArea(3, 10)]
        public string text;

        public Sentence(String n, String t){
            this.name = n;
            this.text = t;
        }
    }

    public List<Sentence> sentences = new List<Sentence>();

    public Decision decision;

    public Sprite backgroundSprite;

}