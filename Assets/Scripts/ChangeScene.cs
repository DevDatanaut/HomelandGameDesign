using UnityEngine;
using System.Collections;

public class ChangeScene0 : MonoBehaviour {

	public void ChangeToScene (int sceneIndex) {
		Application.LoadLevel (sceneIndex);
	}
}
