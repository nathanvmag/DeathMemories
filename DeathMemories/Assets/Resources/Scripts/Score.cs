using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {
	int score;
	public float time;
	public RectTransform timebar;
	bool start;
	public AudioClip shuffling;
	// Use this for initialization
	void Start () {
		time = 300f;
		start = false;
		Playsound (shuffling);
	}
	
	// Update is called once per frame
	void Update () {
		if (Memoria.clicavel) {
			start = true;
		}
		if (start) {
			time -= Time.deltaTime;
			timebar.localScale = new Vector3 (time / 300, timebar.localScale.y, timebar.localScale.z);
		}
		if ( time <= 0 )
	    {
		    Debug.Log("Perdeu");
			    Application.LoadLevel(3);
	    }
}

	public static void Playsound(AudioClip clip)
	{ 
		AudioSource audio = Object.FindObjectOfType <AudioSource>() as AudioSource;
		audio.PlayOneShot (clip);
	}
}
