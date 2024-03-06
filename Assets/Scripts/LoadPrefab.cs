using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPrefab : MonoBehaviour
{
    public GameObject prefab;
    public AudioSource hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = Instantiate(prefab, this.transform);
        
    }
}
