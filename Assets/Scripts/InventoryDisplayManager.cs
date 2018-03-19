using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

/// <summary>
/// Inventory display manager.
/// </summary>
public class InventoryDisplayManager : MonoBehaviour {

	private static GameObject currentItem;
	private static GameObject[] panels = sortArray (GameObject.FindGameObjectsWithTag ("Inventory Button"));

	public static void setCurrentItem(GameObject item) {
		currentItem = item;
		displayItemInfo ();
	}

	public static void setCurrentItemByID(int id) {
		if (Inventory.getItem (id) != null) {
			currentItem = Inventory.getItem (id);
		}
		displayItemInfo ();
	}

	public static GameObject getCurrentItem() {
		return currentItem;
	}

	public static void removeCurrentItem(){
		currentItem = null;
	}
		
	/// <summary>
	/// Displays the selected item's info the the inventory window.
	/// </summary>
	public static void displayItemInfo() {
		
		string name = "";
		string desc = "";
		string dam = "";
		string kno = "";
		string spe = "";
		if (currentItem != null) {
			name = currentItem.GetComponent<Items>().getItemName ();
			desc = currentItem.GetComponent<Items>().getItemDescription ();
			if (currentItem.GetComponent<Items>() is Weapons) {
				Weapons w = (Weapons) currentItem.GetComponent<Items>();
				dam = w.getDamage() + "";
				kno = w.getKnockback () + "";
				spe = w.getSpeed () + "";
			}
		}

		GameObject nameObj = getChildGameObject(GameObject.Find ("Inventory Canvas"), "Name");
		GameObject descObj = getChildGameObject(GameObject.Find ("Inventory Canvas"), "Description");
		GameObject damObj = getChildGameObject(GameObject.Find ("Inventory Canvas"), "Damage Value");
		GameObject knoObj = getChildGameObject(GameObject.Find ("Inventory Canvas"), "Knockback Value");
		GameObject speObj = getChildGameObject(GameObject.Find ("Inventory Canvas"), "Speed Value");

		nameObj.GetComponent<Text> ().text = name;
		descObj.GetComponent<Text> ().text = desc;
		damObj.GetComponent<Text> ().text = dam;
		knoObj.GetComponent<Text> ().text = kno;
		speObj.GetComponent<Text> ().text = spe;

		refresh ();
	}

	/// <summary>
	/// Refresh/update the inventory window's display.
	/// </summary>
	public static void refresh() {
		for (int i = 0; i < panels.Length; i++) {
			if (Inventory.getItem (i) != null) {
				string s = (Inventory.getItem (i).GetComponent<Items> ().getItemName ());
				s = s.ToLower ().Replace (" ", "_") + "_icon";;
				Sprite sprite = Resources.Load<Sprite> ("Icons/" + s);
				getChildGameObject (panels [i].gameObject, "Button").GetComponent<Image> ().sprite = sprite;
			} else {
				//Debug.Log (i + " NO");
			}
		}
	}

	/// <summary>
	/// Selection sort. Sorts the given GameObjects in ascending order.
	/// </summary>
	/// <returns>Sorted array.</returns>
	/// <param name="ar">Array to be sorted.</param>
	public static GameObject[] sortArray(GameObject[] ar) {
		GameObject[] newar = new GameObject[ar.Length];
		for (int i = 0; i < ar.Length; i++) {
			for (int j = 0; j < ar.Length; j++) {
				if (int.Parse(ar[j].name.Substring(0, 2)) == i) {
					newar [i] = ar [j];
					break;
				}
			}
		}
		return newar;
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
}