using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class dialogueController : MonoBehaviour
{
    public bool dialogueActive;
    public dialogueObject[] dialogues;
    public int currentDialogueSOIndex;
    public Dialogue dialogueMonobehavior;
    public dialogueObject currentDialogueSO;
    public int currentLine;
    public UnityEvent onDialogueStarted;
    public UnityEvent onDialogueFinished;

    public void Start()
    {
        loadDialogue(0);
        currentLine++;
        printFirstLine();
    }
    void Update()
    {
        if (Input.GetButtonDown("Submit") && dialogueActive)
        {
            if (currentLine < 0)
            {
                currentLine++;
                printFirstLine();
            }
            else
            {
                printNextLine();
            }
        }
    }
    public void loadDialogue(int index)
    {
        dialogueActive = true;
        currentDialogueSO = dialogues[index];
        dialogueMonobehavior.dialogue = currentDialogueSO;
    }
    public void loadNextDialogue()
    {
        currentDialogueSOIndex += 1;
        currentDialogueSO = dialogues[currentDialogueSOIndex];
        dialogueMonobehavior.dialogue = currentDialogueSO;
    }
    public void printFirstLine()
    {
        currentLine = 0;
        onDialogueStarted.Invoke();
        dialogueMonobehavior.printLine(currentLine);
    }
    public void printNextLine()
    {
        clear();
        currentLine++;
        if (currentLine <= currentDialogueSO.textLines.Count-1)
        {
            dialogueMonobehavior.printLine(currentLine);
        }
        else
        {
            dialogueActive = false;
            onDialogueFinished.Invoke();
        }
    }
    public void clear()
    {
        if (dialogueMonobehavior.gameObject.transform.childCount > 0)
        {
            GameObject.Destroy(dialogueMonobehavior.gameObject.transform.GetChild(0).gameObject);
        }
    }
}