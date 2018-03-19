using UnityEngine;
using System.Collections;

/// <summary>
/// Camera attached to each player client-side by following CameraTarget.
/// </summary>
public class CameraScript : MonoBehaviour {

	private Transform player;

	void Start () {
		player = GameObject.Find ("Player").transform;
	}
	
	void Update () {
		transform.position = new Vector3 (player.position.x, 6, -10);
	}
}
