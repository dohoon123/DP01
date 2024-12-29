using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public const float kTYPE_SPEED = 0.1f;

    public IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";
        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(kTYPE_SPEED);
        }
    }

    // 
    public void StartTyping(string dialogue)
    {
        StartCoroutine(TypeDialogue(dialogue));
    }

}
