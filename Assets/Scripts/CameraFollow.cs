using UnityEngine;
using System.Collections;

/// <summary>
/// Advanced camera lock-on feature. Not created by the Homeland team, and is not planned to be used in the final product of Homneland.
/// </summary>
public class CameraFollow : MonoBehaviour {
	
	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;

	void Start () {
		targetPos = transform.position;
		target = GameObject.Find ("Player"); 
	}

	void Update () {
		if (target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;
			
			Vector3 targetDirection = (target.transform.position - posNoZ);
			
			interpVelocity = targetDirection.magnitude * 100f;
			
			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 
			
			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);
		}
	}
}