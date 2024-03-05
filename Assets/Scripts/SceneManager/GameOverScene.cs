using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public TMP_Text final_text;
    private float start;
    // Start is called before the first frame update
    void Start()
    {
        start = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) {
            SceneManager.LoadScene(0);
        }
        if(Time.time-start >= 27.0f){
            final_text.gameObject.SetActive(true);
        }
    }
}
