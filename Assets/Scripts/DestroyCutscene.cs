using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCutscene : MonoBehaviour {

    public void DestroyCutsceneObject() {
		Destroy(transform.parent.gameObject);
	}

}
