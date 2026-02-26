using UnityEngine;
using TMPro;
using UnityEngine.Playables;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    [TextArea(3, 10)]
    public string sentence;
}

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public float typingSpeed = 0.05f;

    public GameObject birdSelectionPanel; // Panel for bird selection dialogue
    public GameObject nextButton; 

    public PlayableDirector cutsceneDirector; 

    public List<DialogueLine> introDialogue; 
    public List<DialogueLine> introDialogue2; 
    public List<DialogueLine> introDialogue3; 
    public List<DialogueLine> introDialogue4; 

    public List<DialogueLine> Bird1Dialogue; 
    public List<DialogueLine> Bird2Dialogue; 
    public List<DialogueLine> Bird3Dialogue; 
    

    private Queue<DialogueLine> lines = new Queue<DialogueLine>();

   
    public void StartIntro() => StartDialogue(introDialogue);
    public void StartIntro2() => StartDialogue(introDialogue2);
    public void StartIntro3() => StartDialogue(introDialogue3);
    public void StartIntro4() => StartDialogue(introDialogue4);

    public void StartBird1Dialogue() => StartDialogue(Bird1Dialogue);
    public void StartBird2Dialogue() => StartDialogue(Bird2Dialogue);
    public void StartBird3Dialogue() => StartDialogue(Bird3Dialogue);
    
   
    public void StartDialogue(List<DialogueLine> dialogueGroup)
    {
           
        if (cutsceneDirector != null) cutsceneDirector.Pause();

        dialoguePanel.SetActive(true);

        if (nextButton != null) nextButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
        
        lines.Clear();

        foreach (DialogueLine line in dialogueGroup)
        {
            lines.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (lines.Count == 1 && birdSelectionPanel != null) // Show bird selection panel when we reach the last line of the dialogue
        {
            birdSelectionPanel.SetActive(true);
            //Deactivate Button When on Bird Selection Panel
            if (nextButton != null)
            {
                nextButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }
        }

        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();
        nameText.text = currentLine.characterName;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
            dialoguePanel.SetActive(false);
            
            if (birdSelectionPanel != null) {
                birdSelectionPanel.SetActive(false);
            }

            if (cutsceneDirector != null) cutsceneDirector.Resume();

            Debug.Log("End of conversation.");
    }
}


