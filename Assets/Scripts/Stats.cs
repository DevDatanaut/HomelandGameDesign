using UnityEngine;
using System.Collections;

/// <summary>
/// Stats.
/// </summary>
public class Stats : MonoBehaviour {

	private static int maxhp = 100;
	private static int hp = 100;
	private static int att = 0;
	private static int def = 0;
	private static float kno = 0;
	private static float spe = 0;

	/// <summary>
	/// The HP is decreased by the specified amount of health.
	/// </summary>
	/// <param name="dmg">Damage dealt to the player.</param>
	public static void takeDamage(int dmg) {
		hp -= dmg;
	}

	/// <summary>
	/// The HP is increased by obtaining the percent of the user's currently equipped potion. Keep in mind that this function doesn't consume the potion used.
	/// </summary>
	public static void heal() {
		if (hp != maxhp) {
			int amountHealed = (int)(maxhp * Inventory.getCurrentPotion().getPercent());
			for (int i = hp; i < amountHealed; i++) {
				if (hp == maxhp) {
					break;
				}
				hp++;
			}
		}
	}
		
	/// <summary>
	/// Gets the hp.
	/// </summary>
	/// <returns>The hp.</returns>
	public static float getHp() {
		return hp;
	}

	/// <summary>
	/// Sets att to the specified int.
	/// </summary>
	/// <param name="catt">New attack value.</param>
	public static void setAtt(int catt) {
		att = catt;
	}

	/// <summary>
	/// Gets the att.
	/// </summary>
	public static int getAtt() {
		return att;
	}

	/// <summary>
	/// Sets def to the specified int.
	/// </summary>
	/// <param name="cdef">New defense value.</param>
	public static void setDef(int cdef) {
		def = cdef;
	}

	/// <summary>
	/// Gets the def.
	/// </summary>
	/// <returns>Defense value.</returns>
	public static int getDef() {
		return def;
	}

	/// <summary>
	/// Sets kno to the specified int.
	/// </summary>
	/// <param name="ckno">New knockback value.</param>
	public static void setKno(float ckno) {
		kno = ckno;
	}

	/// <summary>
	/// Gets the kno.
	/// </summary>
	/// <returns>Knockback value.</returns>
	public static float getKno() {
		return kno;
	}

	/// <summary>
	/// Sets spe to the specified int.
	/// </summary>
	/// <param name="cspe">New speed value.</param>
	public static void setSpe(float cspe) {
		spe = cspe;
	}

	/// <summary>
	/// Gets the spe.
	/// </summary>
	/// <returns>Speed value.</returns>
	public static float getSpe() {
		return spe;
	}


	private static void changeSpeed() {
		GameObject equippedWeapon = Inventory.getCurrentWeapon ();
		Weapons w = equippedWeapon.GetComponent<Weapons> ();
		float speed = w.getSpeed ();
		spe = speed;
	}

	private static void changeKnockback() {
		GameObject equippedWeapon = Inventory.getCurrentWeapon ();
		Weapons w = equippedWeapon.GetComponent<Weapons> ();
		float knockback = w.getKnockback ();
		kno = knockback;
	}

	private static void changeAttack() {
		GameObject equippedWeapon = Inventory.getCurrentWeapon ();
		Weapons w = equippedWeapon.GetComponent<Weapons> ();
		int attack = w.getDamage ();
		att = attack;
	}

	private static void changeDefense() {
		GameObject equippedSweater = Inventory.getCurrentSweater ();
		Sweaters s = equippedSweater.GetComponent<Sweaters> ();
		int defense = s.getDefense ();
		def = defense;
	}

	private static void changeHealth() {
		GameObject equippedSweater = Inventory.getCurrentSweater ();
		Sweaters s = equippedSweater.GetComponent<Sweaters> ();
		int addedHP = s.getAddedHP ();
		hp = hp + addedHP;
	}


}
