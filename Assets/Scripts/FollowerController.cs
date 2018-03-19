using UnityEngine;
using System.Collections;

public class FollowerController : MonoBehaviour {

	Rigidbody2D body;
	Transform target;
	Transform trans;
	CircleCollider2D playerCollider;
	CircleCollider2D followerCollider;
	Animator anim;

	private float speed;
	private float jumpHeight;
	private float airMovement;

	private float minDistance;

	private float jitter;
	private float jitterEnd;

	private bool isOnGround;
	private bool facingLeft;
	
	void Start () {

		body = GetComponent<Rigidbody2D>();
		target = GameObject.Find ("Player").transform;
		trans = GetComponent<Transform> ();
		playerCollider = GameObject.Find ("Player").GetComponent<CircleCollider2D> ();
		followerCollider = GetComponent<CircleCollider2D> ();
		anim = GetComponent<Animator> ();

		speed = 4.5f;
		jumpHeight = 16f;
		airMovement = .015f;

		minDistance = 5.5f;

		jitter = 0f;
		jitterEnd = .18f;

		isOnGround = false;
		facingLeft = false;
	}
	
	void FixedUpdate() {

		Physics2D.IgnoreCollision (playerCollider, followerCollider);
		Orient ();

		float airMoveLeft;
		float airMove;

		if (facingLeft) { 
			airMoveLeft = 0;
			airMove = airMovement;
		} else {
			airMoveLeft = airMovement;
			airMove = 0;
		}

		if (target.position.x > body.position.x + minDistance) {
			if (isOnGround) {
				if (Time.time > jitter + jitterEnd) {
					body.velocity = new Vector2 (speed, 0);
					facingLeft = false;
					anim.SetBool ("f_ddown", true);
				}
			} else {
				body.velocity = new Vector2 (body.velocity.x + airMove, body.velocity.y);
			}
		} else {
			anim.SetBool ("f_ddown", false);
		}

		if (target.position.x < body.position.x - minDistance) {
			if (isOnGround) {
				if (Time.time > jitter + jitterEnd) {
					body.velocity = new Vector2 (speed * -1, 0);
					facingLeft = true;
					anim.SetBool ("f_adown", true);
				}
			} else {
				body.velocity = new Vector2 (body.velocity.x - airMoveLeft, body.velocity.y);
			}
		} else {
			anim.SetBool ("f_adown", false);
		}
			
		if (!(target.position.x > body.position.x + minDistance) && !(target.position.x < body.position.x - minDistance)) {
			anim.SetBool ("f_stopped", true);
			jitter = Time.time;
		} else {
			anim.SetBool ("f_stopped", false);
		}


	}
		
	/// <summary>
	/// Fires when collision with another object exits.
	/// </summary>
	/// <param name="col">Collision 2D component.</param>
	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.tag == "Floor") {
			isOnGround = false;
		}
	}

	/// <summary>
	/// Fires while collision with another object is constant.
	/// </summary>
	/// <param name="col">Collision 2D component.</param>
	void OnCollisionStay2D(Collision2D col) { 
		if (col.gameObject.tag == "Floor") {
			isOnGround = true;
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