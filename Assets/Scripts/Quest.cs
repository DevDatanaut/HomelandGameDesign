using UnityEngine;
using System.Collections;

/// <summary>
/// Quest.
/// </summary>
public class Quest {

	private string questName;
	private string[][] prompts;

	private int stages;

	private int previousQuestID;
	private int nextQuestID;

	private int progress;
	private int maxProgress;
	private bool completed;

	/// <summary>
	/// Initializes a new instance of the <see cref="Quest"/> class.
	/// </summary>
	/// <param name="cname">Quest name. Example: "Tracking Down the Morgan Fox"</param>
	/// <param name="cdp">Array of darshana's prompts for each stage of the quest.</param>
	/// <param name="cgp">Array of Garrong's prompts for each stage of the quest.</param>
	/// <param name="ckp">Array of Korlan's prompts for each stage of the quest.</param>
	/// <param name="cnp">Array of Nani's prompts for each stage of the quest.</param>
	/// <param name="stages">Stages.</param>
	/// <param name="cprevqID">ID of the previous quest if this quest exists in a series. If this quest does not exist in a series, pass -1.</param>
	/// <param name="cnextqID">ID of the next quest if this quest exists in a series. If this quest does not exist in a series, pass -1.</param>
	public Quest(string cname, string[] cdp, string[] cgp, string[] ckp, string[] cnp,
		int stages, int cprevqID, int cnextqID) {

		questName = cname;
		prompts = new string[4][];
		prompts [0] = cdp;
		prompts [1] = cgp;
		prompts [2] = ckp;
		prompts [3] = cnp;

		previousQuestID = cprevqID;
		nextQuestID = cnextqID;

		maxProgress = stages;
		progress = 0;
		completed = false;
	}

	/// <summary>
	/// Gets the follower prompt for the current stage of the quest.
	/// </summary>
	/// <returns>The prompt.</returns>
	/// <param name="stage">Stage.</param>
	public string getPrompt(int stage) {
		Debug.Log (stage + "" + progress);
		return prompts [PlayerPrefs.GetInt ("Follower")] [progress]; 
	}

	public bool increaseProgress(int stage) {
		bool increased = false;
		if (progress == 0) {
			if (previousQuestID == -1 || QuestManager.getQuest (previousQuestID).isComplete ()) { 
				progress += 1;
				increased = true;
			}
		} else if (progress == stage - 1) {
			progress += 1;
			increased = true;
		}

		if (progress == maxProgress) {
			completed = true;
		}
			
		PlayerPrefs.SetInt (questName, progress);
		return increased;
	}

	/// <summary>
	/// Gets the name of the quest.
	/// </summary>
	/// <returns>The quest name.</returns>
	public string getName() {
		return questName;
	}

	/// <summary>
	/// Gets the progress that the player completed of this quest.
	/// </summary>
	/// <returns>The progress value </returns>
	public int getProgress() {
		return progress;
	}

	/// <summary>
	/// Returns true if the player completed the quest, false if not.
	/// </summary>
	/// <returns><c>true</c>, if quest has been completed by the player, <c>false</c> otherwise.</returns>
	public bool isComplete() {
		return completed;
	}

	/// <summary>
	/// Gets the previous quest ID, -1 if nonexistant
	/// </summary>
	/// <returns>The ID of the previous quest, if present.</returns>
	public int getPreviousQuestID() {
		return previousQuestID;
	}

	/// <summary>
	/// Gets the next quest ID, -1 if nonexistant
	/// </summary>
	/// <returns>The ID of the next quest, if present.</returns>
	public int getNextQuestID() {
		return nextQuestID;
	}
}

