using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
	
	public Text dialogueText;
	public string ourScene;
	private Queue<string> sentences;

	void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		
		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
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

		string sentence = sentences.Dequeue();
		
		StartCoroutine(TypeSentence(sentence));
		StartCoroutine(NextOne());
	}

	IEnumerator NextOne()
    {
		yield return new WaitForSeconds(5);
		DisplayNextSentence();
    }

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(0.1f);
		}
	}

	void EndDialogue()
	{
		new WaitForSeconds(3);
		SceneManager.LoadScene(ourScene);
	}
}
