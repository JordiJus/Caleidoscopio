using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickHiddenObject : MonoBehaviour
{
    public int counter;

    public GameObject extendedObject;
    public GameObject text;
    public GameObject dialogueBox;
    private Button button;

    
    public float start = -1;

    
    // Start is called before the first frame update
    void Start() {
        start = -1;
        button = GetComponent<Button>();
        button.onClick.AddListener(HiddenObjectClicked);
    }
    public void HiddenObjectClicked()
    {
        extendedObject.SetActive(true);
        text.SetActive(true);
        dialogueBox.SetActive(false);
        start = Time.time;
    }

    void Update(){
        if(start != -1 && Time.time - start >5f){
            EndingClick();
        }
    }

    // Update is called once per frame
    void EndingClick()
    {
        extendedObject.SetActive(false);
        text.SetActive(false);
        dialogueBox.SetActive(true);
        button.onClick.RemoveListener(HiddenObjectClicked);
    }
}
