using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    private SceneObjectLoader sceneLoader;
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

    public Sprite HollisSprite;
    public Sprite LespereSprite;
    public Sprite ApplegateSprite;
    public Sprite DirectorSprite;
    public GameObject LeftSprite;
    public GameObject RightSprite;
    public GameObject background;
    

    // Use this for initialization
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneObjectLoader>();
        Debug.Log("1");
        
        RightSprite.SetActive(false);
        LeftSprite.SetActive(false);
        Debug.Log("2");
        sentences = new Queue<Dialogue.Sentence>();
        Debug.Log("3");
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Inside Dialogue");
        animator.SetBool("IsOpen", true);
        Debug.Log("Nuevo diálogo");

        
        background.GetComponent<Image>().sprite = dialogue.backgroundSprite;

        sentences.Clear();

        foreach (Dialogue.Sentence sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        if (dialogue.decision != null)
        {
            Debug.Log("Diálogo normal con decisión");
            currentDecision = dialogue.decision;
            hasDecision = true;
        } else {
            Debug.Log("Dialogo sin decisión");
            hasDecision = false;
        }
        DisplayNextSentence();

    }

    public void ShowSprite(string name){
        if (name == "Hollis") {
            LeftSprite.SetActive(true);
            LeftSprite.GetComponent<Image>().sprite = HollisSprite;
        } else {
            RightSprite.SetActive(true);
            if (name == "Director"){
                RightSprite.GetComponent<Image>().sprite = DirectorSprite;
            } else if (name == "Lespere") {
                RightSprite.GetComponent<Image>().sprite = LespereSprite;
            } else if (name == "Applegate") {
                RightSprite.GetComponent<Image>().sprite = ApplegateSprite;
            } else {
                RightSprite.SetActive(false);
            }
        }
    }

    public void DisplayNextSentence()
    {
        
        Debug.Log("Display Sentence");
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
            ShowSprite(sentence.name);
            StartCoroutine(TypeSentence(sentence));
        }

        
    }

    public void DisplayDecision()
    {
        if (currentDecision != null && currentDecision.decisions.Count > 0)
        {
            List<Button> decisionButtons = new List<Button> { decisionButton1, decisionButton2, decisionButton3, decisionButton4 };
            Dialogue.Sentence keySentence = new Dialogue.Sentence("Name", currentDecision.keySentence);
            StartCoroutine(TypeSentence(keySentence));
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
                
                continueButton.gameObject.SetActive(false);
                nameText.gameObject.SetActive(false);
            }
        }
        else
        {
            StartDialogue(currentDecision.dialogueComun);
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
        Dialogue dialogueNextCommon = currentDecision.dialogueComun;
        currentDecision = null;
        hasDecision = false;

        if (nextDialogue == null) {
            StartDialogue(dialogueNextCommon);
        } else {
            dialogueComun = dialogueNextCommon;
            StartDialogue(nextDialogue);
        }
        

        
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
        nameText.gameObject.SetActive(true);
    }

    void EndDialogue()
    {
        
        if (currentDecision != null)
        {
            Debug.Log("Resetting decision");
            currentDecision = null; // Reset currentDecision after handling it
            return;
        } else if (dialogueComun != null) 
        {
            Debug.Log("Dialogo común empezando");
            StartDialogue(dialogueComun);
            dialogueComun = null;
            return;
        }
        else
        {
            Debug.Log("Ending");
            sceneLoader.counter++;
            
            animator.SetBool("IsOpen", false);
            if(sceneLoader.counter >= sceneLoader.maxCounter) {
                SceneManager.LoadScene(4);
            } else {
                SceneManager.LoadScene(1);
            }
            
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2)) {
            sceneLoader.counter++;
        }
    }

    
}
