using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Script_YouFool : MonoBehaviour {

	public static bool StartHorror;
	public GameObject BG, BG2,BB;
	public Button Button1,Button2;
	public Text VictoryText;
	public AudioClip Laugh;
	private float CurrentFoolTime, CurrentSceneTime;
	private int FoolTime, SceneTime;
	bool canplay;

	void Start () {
		canplay = true; 
		BG.SetActive (true);
		BG2.SetActive (false);
		Button1.gameObject.SetActive (true);
		Button2.gameObject.SetActive (true);
		VictoryText.gameObject.SetActive (true);
		StartHorror = false;
		FoolTime = 2;
	}
	

	void Update () {
		Debug.Log (StartHorror);
		CurrentFoolTime += Time.deltaTime;
		Color  colorBG = BG.GetComponent<Image> ().color;
		Color colorBG2 = BG2.GetComponent<SpriteRenderer> ().color;
		Color colorBB = BB.GetComponent<SpriteRenderer> ().color;

		if (CurrentFoolTime >= FoolTime && StartHorror) {

			SceneTime = 18;
			CurrentSceneTime += 0.1f;
			Debug.Log(CurrentSceneTime);
			BG2.SetActive(true);
			Button1.GetComponent<Image>().color = new Color(126, 0, 0, 255f);
			Button1.GetComponent<Button>().interactable = false;

			Button2.GetComponent<Image>().color = new Color(100, 0, 0, 255f);
			Button2.GetComponent<Button>().interactable = false;

			Button1.GetComponent<Button>().enabled = false;
			Button2.GetComponent<Button>().enabled = false;

			colorBG.a -= 0.005f;
			BG.GetComponent<Image>().color = colorBG;

			colorBG2.a += 0.008f;
			BG2.GetComponent<SpriteRenderer>().color = colorBG2;

			VictoryText.gameObject.GetComponent<Text>().color = new Color(126,0,0,255f);
			if(colorBG2.a >= 1)
			{
				VictoryText.text = "Now, lets play...";
				if (canplay)StartCoroutine(WaitMusic());
			}

			if(CurrentSceneTime >= SceneTime)
			{
				colorBB.a += 0.005f;
				BB.GetComponent<SpriteRenderer>().color = colorBB;
			}

			/*if(colorBB.a >= 1)
			{
				Application.LoadLevel(0);
			}*/

		}

	}
	IEnumerator WaitMusic()
	{	
		Score.Playsound(Laugh);
		canplay = false; 
		yield return new WaitForSeconds (Laugh.length);
		Application.LoadLevel(0);

	}
}
