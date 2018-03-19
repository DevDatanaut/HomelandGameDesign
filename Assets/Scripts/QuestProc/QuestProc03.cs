using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestProc03 : MonoBehaviour {

	private int questID;
	private int progressStep;

	void Start () {
		questID = 0;
		progressStep = 3;
	}

	void OnTriggerEnter2D(Collider2D other){
		Quest quest = QuestManager.getQuest (questID);
		int followerID = PlayerPrefs.GetInt ("Follower");
		if (other.gameObject.tag == "Player" && quest.getProgress() == progressStep - 1) {
			StartCoroutine (displayTimedMessage (createDialogueTime (quest.getPrompt(progressStep)), 
				QuestManager.getFollowerName (followerID), quest.getPrompt (progressStep)));
		}
	}

	float createDialogueTime(string str) {
		return 2f + str.Length * .04f;
	}

	IEnumerator displayTimedMessage(float seconds, string nameText, string dialogueText) {
		DialogueManager.setName (nameText);
		DialogueManager.setDialogue (dialogueText);
		DialogueManager.toggleMessageDisplay (true);
		QuestManager.getQuest (questID).increaseProgress (progressStep);
		yield return new WaitForSeconds (seconds);
		DialogueManager.toggleMessageDisplay (false);
	}
}