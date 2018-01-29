using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_OnOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public static void OnOff_MenuBtn (bool OnOff) {
        if (OnOff == true)
            GameObject.FindGameObjectWithTag("Btn_Menu").transform.Translate(Vector3.down * 100);
        else
            GameObject.FindGameObjectWithTag("Btn_Menu").transform.Translate(Vector3.up * 100);
    }

    public static void OnOff_backBtn(bool OnOff)
    {
        if (OnOff == true)
            GameObject.FindGameObjectWithTag("Btn_back").transform.Translate(Vector3.down * 100);
        else
            GameObject.FindGameObjectWithTag("Btn_back").transform.Translate(Vector3.up * 100);
    }
}
