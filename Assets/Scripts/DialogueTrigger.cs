using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public Decision decision;

	public void TriggerDialogue ()
	{
		Debug.Log("Inside Trigger");
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		FindObjectOfType<DialogueManager>().SaveDecision(decision);
	}

}