using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{

    public string tagFilter;
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Asteroid in");
        if (other.CompareTag(tagFilter)){
            Destroy(gameObject);
        }
    }
}
