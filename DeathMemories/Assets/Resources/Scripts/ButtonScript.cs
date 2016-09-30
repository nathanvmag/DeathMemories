using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public AudioClip Wood;

	public void ButtonScenesFunction(int scene)
	{
		Application.LoadLevel (scene);
	}

	public void ButtonQuitFunction()
	{
		Application.Quit ();
	}
	
	public void PlaySound()
	{
		Score.Playsound (Wood);
	}

	public void FoolButton()
	{
		Script_YouFool.StartHorror = true;
	}

}
