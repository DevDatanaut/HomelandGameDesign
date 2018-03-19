using UnityEngine;
using System.Collections;

/// <summary>
/// Sweaters.
/// </summary>
public class Sweaters : Items {

	public int defense;
	public int addedHP;
	public string itemName;
	public string itemDescription;

	/// <summary>
	/// Initializes a new instance of the <see cref="Sweaters"/> class.
	/// </summary>
	/// <param name="itemNameIn">Item name in.</param>
	/// <param name="itemDescriptionIn">Item description in.</param>
	/// <param name="defenseIN">Defense In.</param>
	/// <param name="addedHPIn">Added HP in.</param>
	public Sweaters (string itemNameIn, string itemDescriptionIn, int defenseIn, int addedHPIn) {
		itemName = itemNameIn;
		itemDescription = itemDescriptionIn;
		defense = defenseIn;
		addedHP = addedHPIn;
	}

	/// <summary>
	/// Gets the name of the item.
	/// </summary>
	/// <returns>The item name.</returns>
	public string getItemName () {
		return itemName;
	}

	/// <summary>
	/// Getitems the description.
	/// </summary>
	/// <returns>The description.</returns>
	public string getItemDescription () {
		return itemDescription;
	}

	/// <summary>
	/// Gets the defense.
	/// </summary>
	/// <returns>The defense.</returns>
	public int getDefense () {
		return defense;
	}

	/// <summary>
	/// Gets the added H.
	/// </summary>
	/// <returns>The added H.</returns>
	public int getAddedHP () {
		return addedHP;
	}
		
}