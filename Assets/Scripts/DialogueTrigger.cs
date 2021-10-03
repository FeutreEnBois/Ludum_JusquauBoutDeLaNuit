using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

	IEnumerator Starting()
    {
		yield return new WaitForSeconds(7);
		TriggerDialogue();
    }

    private void Start()
    {
		StartCoroutine(Starting());
    }

}
