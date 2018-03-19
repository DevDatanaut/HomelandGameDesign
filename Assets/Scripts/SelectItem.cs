using UnityEngine;
using System.Collections;

/// <summary>
/// Select item.
/// </summary>
public class SelectItem : MonoBehaviour {
	
	public int slot;

	/// <summary>
	/// Fires when clicked.
	/// </summary>
	public void onClick() {
		Debug.Log ("clicked");
		InventoryDisplayManager.setCurrentItemByID (slot);
		Inventory.setCurrentWeaponByID(slot);
	}
}
