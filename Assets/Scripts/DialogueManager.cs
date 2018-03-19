using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Dialogue Manager.
/// </summary>
public class DialogueManager : MonoBehaviour {
	
	private static string npcName = "";
	private static string dialogue = "";

	/// <summary>
	/// Turns the dialogue window on or off when called.
	/// </summary>
	/// <param name="on">If set to <c>true</c>, show the dialogue window in its current state.
	/// If <c>false</c>, retract the dialogue window.</param>
	public static void toggleMessageDisplay(bool on) {

		GameObject Canvas = GameObject.Find ("Dialogue Canvas");
		GameObject nameObj = getChildGameObject(GameObject.Find ("Name Text Panel"), "Name Text");
		GameObject dialogueObj = getChildGameObject(GameObject.Find ("Dialogue Text Panel"), "Dialogue Text");

		if (nameObj != null && dialogueObj != null) {
			if (on && !npcName.Equals("") && !dialogue.Equals("")) {
				nameObj.GetComponent<Text> ().text = npcName;
				dialogueObj.GetComponent<Text> ().text = dialogue;
				Canvas.GetComponent<Canvas> ().targetDisplay = 0;
			} else {
				Canvas.GetComponent<Canvas> ().targetDisplay = 5;
			}
		}
	}

	/// <summary>
	/// Script used to fetch a child of specified name of a specified parent.
	/// </summary>
	/// <returns>The child game object.</returns>
	/// <param name="parent">Parent GameObject.</param>
	/// <param name="name">Name of the child to be found.</param>
	public static GameObject getChildGameObject(GameObject parent, string name) {
		Transform[] transforms = parent.transform.GetComponentsInChildren<Transform>();
		foreach (Transform transform in transforms) {
			if (transform.gameObject.name == name) {
				return transform.gameObject;
			}
		}
		return null;
	}

	/// <summary>
	/// Sets the name and dialogue of the currently speaking NPC, turns the dialogue window on or off.
	/// </summary>
	/// <param name="on">If set to <c>true</c>, show the dialogue window in its current state.
	/// <param name="cnpcname">Name of the NPC who is currently speaking.</param>
	/// <param name="cdialogue">Dialogue of the NPC who is currently speaking.</param>
	public static void displayMessage(bool on, string cnpcname, string cdialogue) {
		npcName = cnpcname;
		dialogue = cdialogue;
		toggleMessageDisplay (on);
	}

	/// <summary>
	/// Sets the name of the NPC who is currently speaking.
	/// </summary>
	/// <param name="cname">Name of the NPC.</param>
	public static void setName(string cname) {
		npcName = cname;
	}

	/// <summary>
	/// Sets the dialogue of the NPC who is currently speaking.
	/// </summary>
	/// <param name="cname">Dialogue of the NPC.</param>
	public static void setDialogue(string cdialogue) {
		dialogue = cdialogue;
	}
}
