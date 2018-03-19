using UnityEngine;
using System.Collections;

/// <summary>
/// Main player controller.
/// </summary>
public class MainPlayerController : MonoBehaviour {

	private float speed;
	private float jumpHeight;
	private float airMovement;

	private float jumpwait, jumpwaitend;

	private bool isOnGround;
	private bool facingLeft;

	Rigidbody2D body;
	Collider2D col;
	Animator anim;
	Transform trans;
	GameObject equipped;
	
	void Start () {
		speed = 4.5f;
		jumpHeight = 17f;
		airMovement = .015f;

		jumpwait = 0;
		jumpwaitend = .1f;

		isOnGround = false;
		facingLeft = false;

		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		trans = GetComponent<Transform> ();
	}

	void Update() {

		equipped = Inventory.getCurrentWeapon ();

		float airMoveLeft;
		float airMove;

		if (facingLeft) { 
			airMoveLeft = 0;
			airMove = airMovement;
		} else {
			airMoveLeft = airMovement;
			airMove = 0;
		}

		//changes facingLeft only if the player is not moving
		if (body.velocity.x == 0) {
			anim.SetBool ("stopped", true);
		}

		//if A is pressed on the ground
		if (Input.GetKey (KeyCode.A)) {
			if (isOnGround) {
				body.velocity = new Vector2 (speed * -1, 0);
				anim.SetBool ("adown", true);
				facingLeft = true;
			} else {
				body.velocity = new Vector2 (body.velocity.x - airMoveLeft, body.velocity.y);
			}
		} else {
			anim.SetBool ("adown", false);
		}

		//if D is pressed on the ground
		if (Input.GetKey (KeyCode.D)) {
			if (isOnGround) {
				anim.SetBool ("ddown", true);
				body.velocity = new Vector2 (speed, 0);
				facingLeft = false;
			} else {
				body.velocity = new Vector2 (body.velocity.x + airMove, body.velocity.y);
			}
		} else {
			anim.SetBool ("ddown", false);
		}

		if (!Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A)) {
			anim.SetBool ("stopped", true);

			//Instantiate(

		} else {
			anim.SetBool ("stopped", false);
		}

		//Changes the player's direction accordingly
		Orient();

		//if Space is pressed on the ground
		if (Input.GetKey (KeyCode.Space) && isOnGround) {
			body.velocity = new Vector2 (body.velocity.x, jumpHeight);
			isOnGround = false;
		}

		//update the aiborne param for jumping to avoid studdering
		if (Time.time > jumpwait + jumpwaitend) {
			anim.SetBool ("airborne", !isOnGround);
		}
	}

	/// <summary>
	/// Fires when collision with another object exits.
	/// </summary>
	/// <param name="col">Collision 2D component.</param>
	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.tag == "Floor") {
			isOnGround = false;
			jumpwait = Time.time;
		}
	}

	/// <summary>
	/// Fires while collision with another object is constant.
	/// </summary>
	/// <param name="col">Collision 2D component.</param>
	void OnCollisionStay2D(Collision2D col) { 
		if (col.gameObject.tag == "Floor") {
			isOnGround = true;
			anim.SetBool ("airborne", false);
		}
	}

	/// <summary>
	/// Orients the player's instance depending on which direction they're facing.
	/// </summary>
	void Orient() {
		if (facingLeft && trans.localScale.x < 0 || !facingLeft && trans.localScale.x > 0) {
			Vector3 theScale = trans.localScale;
			theScale.x *= -1;
			trans.localScale = theScale;
		}
	}
}