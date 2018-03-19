using UnityEngine;
using System.Collections;

public class Potions : MonoBehaviour {

	public double healPercent;
	public const float cooldown = 10f;

	/// <summary>
	/// Initializes a new instance of the <see cref="Potions"/> class.
	/// </summary>
	/// <param name="percentIn">Healing percent in.</param>
	/// <param name="imageIn">Image in.</param>
	public Potions(double percentIn, Sprite imageIn) {
		healPercent = percentIn;
	}

	/// <summary>
	/// Gets the healing percent.
	/// </summary>
	/// <returns>The healing percent.</returns>
	public double getPercent() {
		return healPercent;
	}

	/// <summary>
	/// Gets the cooldown.
	/// </summary>
	/// <returns>The cooldown.</returns>
	public float getCooldown() {
		return cooldown;
	}

	/*
	void Update() {
		if (Input.GetKeyDown ("q") && Time.time > nextHeal) {
			nextHeal = Time.time + playerPotion.cooldown;
			heal();
		}
	}

	public class heal() {
		currentHealth = currentHealth + (maxHealth * playerPotion.getPercent());
	}
	*/

}
