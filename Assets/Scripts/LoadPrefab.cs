using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPrefab : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefab, this.transform);
    }
}
