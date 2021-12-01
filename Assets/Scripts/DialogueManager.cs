using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public Queue<string> sentences;
	
	public Text textDisplay;
	public Text textHint;
	IEnumerator currentCoroutine;

	void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		sentences.Clear();
		if (currentCoroutine != null)
		{
			StopCoroutine(currentCoroutine);
		}
		textDisplay.text = "";
		textHint.enabled = true;
		
		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}
	IEnumerator TypeText(string sentence)
	{
		int charIndex = 0;
		while (charIndex < sentence.Length)
		{
			yield return new WaitForSeconds(0.07f);
			charIndex += 1;
			textDisplay.text = sentence.Substring(0, charIndex);
		}
	}
	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		if (currentCoroutine != null)
		{
			StopCoroutine(currentCoroutine);
		}
		textDisplay.text = "";
		string sentence = sentences.Dequeue();
		currentCoroutine = TypeText(sentence);
		StartCoroutine(currentCoroutine);
	}

	void EndDialogue()
	{
		Debug.Log("End of Message");
		if (currentCoroutine != null)
		{
			StopCoroutine(currentCoroutine);
		}
		textDisplay.text = "";
		textHint.enabled = false;
	}
	void Update()
	{
		if (Input.GetKeyDown("e"))
		{
			DisplayNextSentence();
		}
	}
}
