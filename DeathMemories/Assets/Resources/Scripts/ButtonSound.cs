using UnityEngine;
using System.Collections;

public class ButtonSound : MonoBehaviour {

	public AudioClip Wood;

	public void PlaySound()
	{
		Score.Playsound (Wood);
	}

}
