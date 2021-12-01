using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
	public Transform enemyContainer;
	public DialogueManager dialogueManager;
	bool enemiesDefeated;

	public Dialogue introDialogue;
	public Dialogue goal1Dialogue;
	public Dialogue goal2Dialogue;
	public Dialogue endDialogue;
	bool said;

	void Start()
    {
		dialogueManager.StartDialogue(introDialogue);
	}

    void Update()
    {
        if (enemyContainer.childCount == 0 && said == false)
		{
			said = true;
			enemiesDefeated = true;
			dialogueManager.StartDialogue(goal2Dialogue);
		}
    }
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (enemiesDefeated == true)
			{
				dialogueManager.StartDialogue(endDialogue);
			}
			else
			{
				dialogueManager.StartDialogue(goal1Dialogue);
			}
		}
	}
}
