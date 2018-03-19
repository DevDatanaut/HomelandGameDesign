using UnityEngine;
using System.Collections;

/// <summary>
/// Inventory.
/// </summary>
public class Inventory : MonoBehaviour {

	private static GameObject[] items;
	private static GameObject currentWeapon;
	private static Potions currentPotion;
	private static GameObject currentSweater;

	private static float hp = 100;

	public static void damage(float dmg) {
		hp -= dmg;
	}

	public static float getHp() {
		return hp;
	}

	public static void healPercent(float percent) {
		hp *= 1f + percent;
		if (hp > 100f) {
			hp = 100f;
		}
	}



	void Start () {
		items = new GameObject[15];
		GameObject item = (GameObject)Resources.Load ("Axe");
		GameObject item2 = (GameObject)Resources.Load ("Fancy Long Sword");
		GameObject item3 = (GameObject)Resources.Load ("Rusty Long Sword");
		addItem (item);
		addItem (item2);
		addItem (item3);
		InventoryDisplayManager.refresh ();

	}

	//returns next available slot, -1 if no slot available
	public static int nextOpenSlot(){
		for (int i = 0; i < items.Length; i++) {
			if (items [i] == null) {
				Debug.Log (i + " is the Next Open Slot");
				return i;
			}
		}
		return -1;
	}
	
	public static bool addItem(GameObject item){
		int s = nextOpenSlot ();
		if (s != -1) {
			items [s] = item;
			Debug.Log (item.GetComponent<Items>().getItemName() + " added to " + s);
			return true;
		}
		return false;
	}

	public static void removeItem(int slot){
		items [slot] = null;
	}

	public static GameObject getItem(int id) {
		return items [id];
	}


	public static void setCurrentWeaponByID(int slot) {
		if (items [slot].GetComponent<Items>() is Weapons) {
			currentWeapon = items [slot];
		}
	}

	public static void setCurrentWeapon(GameObject weapon) {
		currentWeapon = weapon;
	}

	public static GameObject getCurrentWeapon() {
		return currentWeapon;
	}

	public static Potions getCurrentPotion() {
		return currentPotion;
	}

	//add this in once sweaters are in the inventory
	//public static GameObject setCurrentSweaterById(int slot) {
		//if (items [slot].GetComponent<Items>() is Sweaters) {
		//	currentSweater = items [slot];
		//}
	//}

	public static void setCurrentSweater(GameObject sweater) {
		currentSweater = sweater;
	}

	public static GameObject getCurrentSweater() {
		return currentSweater;
	}

}
