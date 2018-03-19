using UnityEngine;
using System.Collections;

public class PlayerCombatManager : MonoBehaviour {

	bool isBlocking;
	bool isHitStunned;

	GameObject player;
	ArrayList enemies; //An array of all of the enemies.

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) {
			attack ();
		} 
		if (Input.GetMouseButtonDown(1)) {
			//Block Behavior: Player blocks a portion of damage, does not become hit-stunned, and is knocked back as normal.
			StartCoroutine(block());
		}
	}

	/// <summary>
	/// What do when hit.
	/// </summary>
	/// <param name="coll">This is the collision event.</param>
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy" && !isHitStunned) {
			Debug.Log ("Collision with enemy!");
			Stats.takeDamage (10);
			Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
			//rigidBody.AddForce (transform.right * 10000f);
			rigidBody.velocity = new Vector2 (10, 0);
		}
	}

	//Runs when the player is damaged.
	IEnumerator onPlayerHit() {
		isHitStunned = true;
		Debug.Log ("Is hit stunned: " + isHitStunned);
		yield return new WaitForSeconds (1);
		isHitStunned = false;
		Debug.Log ("Is hit stunned: " + isHitStunned);
	}

	//Returns the current percentage of damage that the player can take based on whether or not he is blocking or not. He also cannot take damage while hit-stunned.
	float getDamageRatio() {
		float baseValue;
		if (isHitStunned) { //Player takes no damage.
			baseValue = 1F;
		} else if (isBlocking) { //Blocking reduces damage by 70%
			baseValue = 0.7F;
		} else { //Player has no special state to modify damage taken.
			baseValue = 0F;
		} 

		//TODO: Add block in that allows for the player to have armor or special damage reducing items. Their value can be added to the final value.
		float armorValue = 0F;

		float totalRatio = armorValue + baseValue;
		
		if (totalRatio > 1F) { //Value cannot be more than 1 or the player would be healed.
			totalRatio = 1F;
		}

		return totalRatio;
	}

	//Plays the animation for the player to attack and swings the hitbox in the direction the player is facing. Collision is handles within the enemy's combat manager.
	void attack() {
		//Temporarily this summons a sword in front of the player that does damage.

	}

	//Puts the player's defenses up for 1 second, reducing damage taken by 70% and preventing hit-stun.
	IEnumerator block() {
		//TODO: Play block animation
		isBlocking = true;
		Debug.Log ("Block Status: " + isBlocking);
		//Play animation for blocking.
		yield return new WaitForSeconds(1);
		isBlocking = false; //After 1 second the player is no longer blocking.
		Debug.Log("Block Status: " + isBlocking);
		//End animation for blocking.
	}
}

