using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI ;
using UnityEngine.EventSystems;

public class Memoria : MonoBehaviour
{
	public List<GameObject> cards= new List<GameObject>();
	private static System.Random rng = new System.Random(); 
	int control;
	bool firstCard;
	private Vector3 targetAngles;
	public static bool clicavel;
	public Sprite[] imgCards; 
	public Sprite ClosedCard;
	GameObject tempcard;
	Detect listener; 
	int namecontrol;
	Score score;
	public AudioClip risada; 
	public AudioClip ghost;
	float dimintime;
	public GameObject[] RemaningCards;
	// Use this for initialization
	void Start () {
		dimintime = 1;
		score = GetComponent<Score> ();
		namecontrol = 0;
		listener = GameObject.Find ("Canvas").GetComponent<Detect> ();
		clicavel = false; 
		firstCard = true; 
		control = 0;
		cards.AddRange(GameObject.FindGameObjectsWithTag ("Cards"));
		Shuffle (cards);
		
		for (int i = 0; i<cards.Count; i++) {
			if (control<2)
			{
				if (control%2==0) namecontrol++;
				cards[i].name ="Par"+namecontrol;
			}
			else if (control<4)
			{
				if (control%2==0) namecontrol++;
				cards[i].name ="Par"+namecontrol;
			}
			else if (control<6)
			{
				if (control%2==0) namecontrol++;
				cards[i].name ="Par"+namecontrol;
			}
			else if (control<8)
			{
				if (control%2==0) namecontrol++;
				cards[i].name ="Par"+namecontrol;
			}
			else if (control<10)
			{
				if (control%2==0) namecontrol++;
				cards[i].name ="Par"+namecontrol;
			}
			else if (control<12)
			{
				if (control%2==0) namecontrol++;
				cards[i].name ="Par"+namecontrol;
			}
			else if (control<14)
			{
				if (control%2==0) namecontrol++;
				cards[i].name ="Par"+namecontrol;
			}
			else if (control<16)
			{
				if (control%2==0) namecontrol++;
				cards[i].name ="Par"+namecontrol;
			}else if (control<18)
			{
				if (control%2==0) namecontrol++;
				cards[i].name ="Par"+namecontrol;
			}
			else if (control<20)
			{
				if (control%2==0) namecontrol++;
				cards[i].name ="Par"+namecontrol;
			}
			
			control++;
		}
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		RemaningCards = GameObject.FindGameObjectsWithTag ("Cards");
		if (RemaningCards.Length == 0) {		
			Application.LoadLevel(4);
		}
	}
	public void cardClick(GameObject obj)
	{
		
		//Debug.Log (obj.name);                           
		if (clicavel) {
			if (!firstCard&& obj!=tempcard) {
				
				for (int i = 0;i<namecontrol;i++)
				{
					
					if (obj.name =="Par"+(i+1))
						StartCoroutine (rotate (obj, imgCards [i]));
				}
				if (tempcard.name== obj.name) {
					StartCoroutine (waitAcerto (obj));
					clicavel = false; 
					dimintime = dimintime>2.2f ? 2.2f : dimintime+0.15f ;
					
				} else {
					StartCoroutine(waitApagar(obj));
					clicavel = false ; 
					dimintime = dimintime>2.2f? 2.2f : dimintime+0.05f;
				}
				
			} else if (firstCard) {
				
				
				tempcard = obj;
				
				for (int i = 0;i<namecontrol;i++)
				{
					
					if (obj.name =="Par"+(i+1))
						StartCoroutine (rotate (obj, imgCards [i]));
				}
				firstCard = false;
				
			}
		}
	}
	
	IEnumerator waitApagar(GameObject obj)
	{
		yield return new WaitForSeconds (3.5f-dimintime);
		//tempcard.GetComponent<Image>().sprite = null;				
		//obj.GetComponent<Image>().sprite = null;
		StartCoroutine (rotateback(tempcard));
		StartCoroutine(rotateback(obj));
		score.time -= 20f;
		Score.Playsound (risada);
		
	}
	IEnumerator waitAcerto( GameObject obj)
	{
		yield return new WaitForSeconds (3.5f-dimintime);
		Debug.Log("Foi");
		score.time += 10;
		StartCoroutine (DestroyAnim (obj));
		Score.Playsound (ghost);
		
	}
	
	/// <summary>
	/// Rotate the specified object and showCard
	/// </summary>
	/// <param name="Carta">Object.</param>
	/// <param name="Sprite da carta rodada">Card.</param>
	IEnumerator rotate( GameObject obj, Sprite card)
	{
		bool loop = true;
		
		while (loop) {
			if (obj.GetComponent<RectTransform>().eulerAngles.y>= 90)
			{
				obj.GetComponent<Image>().sprite = card ; 
				obj.GetComponent<RectTransform>().localScale = new Vector3(-1,1,1);
			}
			if (obj.GetComponent<RectTransform>().eulerAngles.y>=180)
			{
				loop = false ;
				obj.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
				obj.GetComponent<RectTransform>().eulerAngles = Vector3.zero;
			}
			else {obj.GetComponent<RectTransform>().eulerAngles += new Vector3(0,180*Time.deltaTime*dimintime,0);}
			
			yield return new  WaitForSeconds (Time.deltaTime);
			
		}
	}
	
	IEnumerator rotateback(GameObject obj)
	{
		bool loop = true;
		
		while (loop) {
			if (obj.GetComponent<RectTransform> ().eulerAngles.y >= 90) {
				obj.GetComponent<Image> ().sprite = ClosedCard; 
				obj.GetComponent<RectTransform>().localScale = new Vector3(-1,1,1);
			}
			if (obj.GetComponent<RectTransform> ().eulerAngles.y >= 180) {
				loop = false; 
				obj.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
				obj.GetComponent<RectTransform> ().eulerAngles = Vector3.zero;
				firstCard = true ;
				clicavel = true; 
			} else {
				obj.GetComponent<RectTransform> ().eulerAngles += new Vector3 (0, 180 * Time.deltaTime*dimintime, 0);
			}
			
			yield return new  WaitForSeconds (Time.deltaTime);
		}
		
		
	}
	IEnumerator DestroyAnim(GameObject obj)
	{
		bool loop = true;
		while (loop) {
			obj.GetComponent<RectTransform>().eulerAngles+= new Vector3(0,0, 360f*Time.deltaTime*dimintime);
			obj.GetComponent<RectTransform>().localScale -= new Vector3(0.5f*Time.deltaTime*dimintime,0.5f*Time.deltaTime*dimintime,0.5f*Time.deltaTime*dimintime);
			tempcard.GetComponent<RectTransform>().eulerAngles+=new Vector3(0,0, 360f*Time.deltaTime*dimintime);
			tempcard.GetComponent<RectTransform>().localScale -= new Vector3(0.5f*Time.deltaTime*dimintime,0.5f*Time.deltaTime*dimintime,0.5f*Time.deltaTime*dimintime);
			if (obj.GetComponent<RectTransform>().localScale.x<0&&tempcard.GetComponent<RectTransform>().localScale.x<0)
			{
				Destroy(tempcard);
				Destroy(obj);
				clicavel = true; 
				firstCard = true ;
				loop= false ; 
			}
			yield return new WaitForSeconds(Time.deltaTime);
			
		}
	}
	
	
	public void Shuffle<T>(this IList<T> list)  
	{  
		int n = list.Count;  
		while (n > 1) {  
			n--;  
			int k = rng.Next(n + 1);  
			T value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}
	public void enter(GameObject obj)
	{
		//GameObject obj = listener.CardEnter;
		if (clicavel) {
			Debug.Log ("true");
			obj.GetComponent<RectTransform>().localScale= new Vector3(1.2f, 1.2f, 1);
		}
	}
	public void exit(GameObject obj)
	{
		
		if (clicavel) {Debug.Log ("false");
			obj.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
		}
	}
	
	
}
