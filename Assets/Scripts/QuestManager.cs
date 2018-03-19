using UnityEngine;
using System.Collections;

/// <summary>
/// Quest manager.
/// </summary>
public class QuestManager : MonoBehaviour {

	private static Quest[] quests;
	private static string[] followerNames;

	/// <summary>
	/// Initializes the quest list and player progress for each quest.
	/// </summary>
	void Awake() {
		quests = new Quest[] {
			new Quest("Tracking Down the Morgan Fox",
				new string[] {"Oh boy. A blood trail. Following it sounds like a great idea.",
					"Welp. We found what we were looking for.",
					"That was gross."
				},
				new string[] {"Blood? Maybe someone's hurt. We should check it out.",
					"Be careful. If we play our cards right, we can smash this thing together!",
					"Aha! We did it! Doesn't look like anyone needed our help, though."
				},
				new string[] {"I don't have a good feeling about this. Are you sure we should be following an ominous trail of blood?",
					"Eep! Be careful!",
					"Whew. That was a close one."
				},
				new string[] {"*sniff sniff* Grrr... (Nani looks at you, then ahead again, as if she wants you to be careful.)",
					"Grrr! Grrrruff!",
					"*Tired Whimper*"
				},
				3, -1, -1) 
		};

		followerNames = new string[] { "Darshana", "Garrong", "Korlan", "Nani" };

		PlayerPrefs.SetInt ("Follower", 0);
		PlayerPrefs.SetInt ("MorganFoxProgress", 0);
	}

	/// <summary>
	/// Gets the quest at the specified index.
	/// </summary>
	/// <returns>The quest at the specified index.</returns>
	/// <param name="id">Index of the quests array.</param>
	public static Quest getQuest(int id) {
		return quests [id];
	}

	/// <summary>
	/// Gets the follower name at the specified index.
	/// </summary>
	/// <returns>The follower at the specified index.</returns>
	/// <param name="id">Index of the followerNames array.</param>
	public static string getFollowerName(int id) {
		return followerNames [id];
	}
}
