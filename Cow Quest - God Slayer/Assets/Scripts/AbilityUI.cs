using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour {
	//private string ability;
	public Text abilText;
	public Transform lightSide;
	public Transform darkSide;
	public bool darkish = true;
	void Start (){
		
		abilText = GetComponent<Text>();
		abilText.text = "SUPER STRIKE";
		if (darkish == true) {
			darkSide.gameObject.SetActive (true);
			lightSide.gameObject.SetActive (false);
		} else {
			darkSide.gameObject.SetActive (false);
			lightSide.gameObject.SetActive (true);
		}
			

	}
		
	void Update () {
		
	}
}
