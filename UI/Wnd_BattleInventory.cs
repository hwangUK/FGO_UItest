using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wnd_BattleInventory : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ShowInventory();
    }

    public void DestroyCanvas()
    {
        Destroy(this.gameObject);
    }

    public void ClickAndRegisterBattleServant(int number)
    {
        for (int i = 0; i < 6; i++)
        {
            if (this.gameObject.name == "Wnd_BattleInventory_" + i.ToString() + "(Clone)")
            {
                Player.MainPlayer.BattleTeam[i] = Player.MainPlayer.myServantList[number];
            }
        }
        GameObject.Find("Wnd_BattleReady(Clone)").GetComponent<Wnd_BattleReadyLoadImage>().DrawFormationImage();
    }

    public void ShowInventory()
    {
        for (int i = 0; i < transform.GetChild(2).childCount; i++)
        {
            transform.GetChild(2).GetChild(i).gameObject.SetActive(false);
        }
        if (Player.MainPlayer.myServantList.Count != 0)
        {
            int Index = Player.MainPlayer.myServantList.Count;

            for (int j = 0; j < Index; j++)
            {
                transform.GetChild(2).GetChild(j).gameObject.SetActive(true);
                transform.GetChild(2).GetChild(j).GetComponent<Image>().sprite = Player.MainPlayer.myServantList[j].GetImage_face();
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
