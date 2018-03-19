using UnityEngine;
using System.Collections;

	public class Weapons : MonoBehaviour, Items {

	public int damage;
	public float knockback;
	public float speed;
	public int wepType;
	public string itemName;
	public string itemDescription;

	/// <summary>
	/// Initializes a new instance of the <see cref="Weapons"/> class.
	/// </summary>
	/// <param name="itemNameIn">Item name in.</param>
	/// <param name="itemDescriptionIn">Item description in.</param>
	/// <param name="damageIn">Damage in.</param>
	/// <param name="knockbackIn">Knockback in.</param>
	/// <param name="speedIn">Speed in.</param>
	/// <param name="wepIn">Weapon type.</param>
	public Weapons (string itemNameIn, string itemDescriptionIn, int damageIn, float knockbackIn, float speedIn, int wepIn) {
		itemName = itemNameIn;
		itemDescription = itemDescriptionIn;
		damage = damageIn;
		knockback = knockbackIn;
		speed = speedIn;
		wepType = wepIn;
	}

	/// <summary>
	/// Deals the damage to the specified enemy and applies knockback.
	/// </summary>
	public void dealDamage (GameObject enemy) {
		//enemy.damage (Stats.getAtt(), Stats.getKno());
	}

	/// <summary>
	/// Fires when the weapon's hitbox enters the hitbox of an enemy.
	/// </summary>
	/// <param name="col">Collision 2D component.</param>
	void OnCollisionEnter2D(Collision2D col) { 
		if (col.gameObject.tag == "Enemy") {
			//dealDamage (col.gameObject);.
		}
	}

	/// <summary>
	/// Gets the name of the item.
	/// </summary>
	/// <returns>The item name.</returns>
	public string getItemName () {
		return itemName;
	}

	/// <summary>
	/// Gets the item description.
	/// </summary>
	/// <returns>The item description.</returns>
	public string getItemDescription () {
		return itemDescription;
	}

	/// <summary>
	/// Gets the damage.
	/// </summary>
	/// <returns>The damage.</returns>
	public int getDamage () {
		return damage;
	}

	/// <summary>
	/// Gets the knockback.
	/// </summary>
	/// <returns>The knockback.</returns>
	public float getKnockback () {
		return knockback;
	}

	/// <summary>
	/// Gets the speed.
	/// </summary>
	/// <returns>The speed.</returns>
	public float getSpeed () {
		return speed;
	}

	/// <summary>
	/// Gets the type of the wep.
	/// </summary>
	/// <returns>The weapon type.</returns>
	public int getWepType() {
		return wepType;
	}

}

