using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Animator animator;

    private Queue<Dialogue.Sentence> sentences;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<Dialogue.Sentence>();
    }



    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Inside Dialogue");
        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (Dialogue.Sentence sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue.Sentence sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(Dialogue.Sentence sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

        nameText.text = "";
        foreach (char letter in sentence.name.ToCharArray())
        {
            nameText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    
}
