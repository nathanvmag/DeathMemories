using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Detect : MonoBehaviour,IPointerClickHandler,
IPointerDownHandler,
IPointerUpHandler,
IPointerEnterHandler,
IPointerExitHandler,
ISelectHandler {
	[HideInInspector] public GameObject CardClicked; 
	[HideInInspector] public GameObject CardEnter; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerEnter (PointerEventData evd)
	{

		if (evd.pointerCurrentRaycast.gameObject.tag == "Cards") {
			CardEnter = evd.pointerCurrentRaycast.gameObject;
		}
	}
	public void OnPointerExit (PointerEventData evd)
	{

	}
	public void OnPointerClick (PointerEventData evd)
	{
		Debug.Log ("OnPointerClick");
		Debug.Log (evd.pointerPress.gameObject);
	}
	public void OnPointerUp (PointerEventData evd)
	{
		Debug.Log ("OnPointerUp");
	}
	public void OnSelect (BaseEventData evd)
	{
		Debug.Log ("OnSelect");
	}
	public void OnPointerDown (PointerEventData eventData) 
	{
		//Grab the number of consecutive clicks and assign it to an integer varible.
		int i = eventData.clickCount;
		//Display the click count.
		Debug.Log (i);
	}public void Endanim ()
	{
		Memoria.clicavel = true; 
	}

}
