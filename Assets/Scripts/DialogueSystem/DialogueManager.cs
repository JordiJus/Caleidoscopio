using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Button continueButton;
    public Sprite dialogueImageLeft;
    public Sprite dialogueImageRight;
    public GameObject dialogueBox;

    public Animator animator;

    

    private Queue<Dialogue.Sentence> sentences;

    private Decision currentDecision;
    private bool hasDecision = false;
    private Dialogue dialogueComun;

    public Button decisionButton1;
    public Button decisionButton2;
    public Button decisionButton3;
    public Button decisionButton4;

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

        if (dialogue.decision != null)
        {
            currentDecision = dialogue.decision;
            hasDecision = true;
        }
        
        DisplayNextSentence();

    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0 && hasDecision == false)
        {
            EndDialogue();
            return;
        } else if (sentences.Count == 0 && hasDecision == true)
        {
            DisplayDecision();
        } else
        {
            Dialogue.Sentence sentence = sentences.Dequeue();
            StopAllCoroutines();
            if(sentence.name == "Hollis"){
                dialogueBox.GetComponent<Image>().sprite = dialogueImageLeft;
            } else {
                dialogueBox.GetComponent<Image>().sprite = dialogueImageRight;
            }
            
            StartCoroutine(TypeSentence(sentence));
        }

        
    }

    public void DisplayDecision()
    {
        if (currentDecision != null && currentDecision.decisions.Count > 0)
        {
            List<Button> decisionButtons = new List<Button> { decisionButton1, decisionButton2, decisionButton3, decisionButton4 };
            nameText.text = currentDecision.keySentence;
            for (int i = 0; i < currentDecision.decisions.Count; i++)
            {
                if (i >= decisionButtons.Count) // Ensure we don't create more buttons than available
                    break;

                Button button = decisionButtons[i];
                Decision.Elections option = currentDecision.decisions[i];

                button.GetComponentInChildren<TMP_Text>().text = option.decisionSentence;
                button.onClick.RemoveAllListeners(); // Clear previous listeners
                button.onClick.AddListener(() => OnDecisionButtonClicked(option.dialogue));
                button.gameObject.SetActive(true);
                
                dialogueText.enabled = false;
                continueButton.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("Current decision or decision options are null or empty.");
            EndDialogue();
        }
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

    void OnDecisionButtonClicked(Dialogue nextDialogue)
    {
        // Start the next dialogue
        dialogueComun = currentDecision.dialogueComun;
        currentDecision = null;
        hasDecision = false;


        StartDialogue(nextDialogue);
        // Hide all decision buttons
        HideDecisionButtons();
    }

    void HideDecisionButtons()
    {
        Button[] decisionButtons = { decisionButton1, decisionButton2, decisionButton3, decisionButton4 };
        foreach (Button button in decisionButtons)
        {
            button.gameObject.SetActive(false);
        }
        dialogueText.enabled = true;
        continueButton.gameObject.SetActive(true);
    }

    void EndDialogue()
    {
        if (currentDecision != null)
        {
            currentDecision = null; // Reset currentDecision after handling it
            return;
        } else if (dialogueComun != null) 
        {
            StartDialogue(dialogueComun);
            dialogueComun = null;
            return;
        }
        else
        {
            Debug.Log("Textooo");
            animator.SetBool("IsOpen", false);
        }
        
    }

    
}
