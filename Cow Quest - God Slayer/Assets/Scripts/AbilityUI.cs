using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour {
	private string ability;
	public Text abilText;
	//public Ability abil;

	void Start (){
		abilText = GetComponent<Text>();
		//ability = abil.getAbility ();
	}
		
	void Update () {
		abilText.text = "SUPER STRIKE";
	}
}
