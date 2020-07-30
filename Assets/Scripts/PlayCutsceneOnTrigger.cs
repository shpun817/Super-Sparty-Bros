using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayCutsceneOnTrigger : MonoBehaviour {

	PlayableDirector playableDirector;

	void Awake() {
		playableDirector = GetComponent<PlayableDirector>();
		if (!playableDirector) {
			Debug.LogError("PlayableDirector component not found!");
		}
	}

    void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player" && playableDirector.state != PlayState.Playing) {
			playableDirector.Play();
		}
	}

}
