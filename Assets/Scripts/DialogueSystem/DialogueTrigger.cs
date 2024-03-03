using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

	private SceneObjectLoader sceneLoader;
	public Dialogue dialogue;
	public GameObject background;

	public void Start ()
	{
		sceneLoader = FindObjectOfType<SceneObjectLoader>();
		background.GetComponent<Image>().sprite = sceneLoader.memories[sceneLoader.counter].background;
		Debug.Log("INSIDE TRIGGER");
		FindObjectOfType<DialogueManager>().StartDialogue(sceneLoader.memories[sceneLoader.counter].dialogue);
	}

}