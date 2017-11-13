using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour {
	private string ability;
	public Text abilText;
	public Transform lightSide;
	public Transform darkSide;

	void Start (){
		bool darkish = true;
		abilText = GetComponent<Text>();
		if (darkish == false) {
			darkSide.gameObject.SetActive (true);
			lightSide.gameObject.SetActive (false);
		} else {
			darkSide.gameObject.SetActive (false);
			lightSide.gameObject.SetActive (true);
		}
			
		abilText.text = "SUPER STRIKE";
	}
		
	void Update () {
		
	}
}
