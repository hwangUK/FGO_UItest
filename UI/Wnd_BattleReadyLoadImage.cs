using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wnd_BattleReadyLoadImage : MonoBehaviour {

    public Sprite defaultImg_ =  new Sprite();
	// Use this for initialization
	void Start () {
        DrawFormationImage();
    }
	
    public void DrawFormationImage()
    {
       for(int i = 0; i < 6;i++)
        {
           // transform.GetChild(1).GetComponent<Image>().sprite = Player.MainPlayer.BattleTeam[1].GetImage_formation();
            if (Player.MainPlayer.BattleTeam[i] == null)
                transform.GetChild(i + 1).GetComponent<Image>().sprite = defaultImg_;
            else
                transform.GetChild(i + 1).GetComponent<Image>().sprite = Player.MainPlayer.BattleTeam[i].GetImage_formation();            
        }
    }

}
