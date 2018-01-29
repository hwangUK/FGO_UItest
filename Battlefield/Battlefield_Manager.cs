using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battlefield_Manager : MonoBehaviour {

    public Sprite[] SetCardImage_Masu = new Sprite[4];
    //
    //public GameObject[] SetBattleCharacter = new GameObject[6];
    //
    private Transform[] character_Spawnpoint =  new Transform[3];
    private Transform btn_Card_Spawnpoint;
    //
    private Servant[] ServantInstance = new Servant[6];
    //
	void Start () {
        DefaultSpawnSetting();

        for (int i = 0; i < 6 ; i++){
            ServantInstance[i] = Player.MainPlayer.BattleTeam[i];
        }

    }

    private void DefaultSpawnSetting()
    {
        for (int i = 0; i < 3; i++)
        {
            character_Spawnpoint[i] = transform.GetChild(1).GetChild(i).GetChild(0).transform; //캐릭 생성 위치 
            character_Spawnpoint[i].GetComponent<Image>().sprite = Player.MainPlayer.BattleTeam[i].GetImage_ingameImg(0);

        }
        btn_Card_Spawnpoint = transform.GetChild(3).transform; //카드 생성 위치
    }

    public void ClickAttack()
    {
        for(int i = 0; i < 9; i++)
            btn_Card_Spawnpoint.GetChild(i).gameObject.SetActive(true); //카드 활성화
        
        for(int j = 0; j < 9; j++)
        {
            int tmp = Random.Range(0, 4);
            if(j >0)
                btn_Card_Spawnpoint.GetComponentsInChildren<Image>()[j].sprite = SetCardImage_Masu[tmp]; //이미지 변경
        }
    }

    public void ClickCardSelect(string cardType)
    {
        for (int i = 0; i < 9; i++)
            btn_Card_Spawnpoint.GetChild(i).gameObject.SetActive(false); //카드 비활성화

        StartCoroutine(GotoAttack());
    }
    
    IEnumerator GotoAttack()
    {
        for(int t = 0; t < 30; t++)
        {
            character_Spawnpoint[0].transform.Translate(Vector3.left * 6f);
            GameObject.FindGameObjectWithTag("MainCamera").transform.Translate(Vector3.left * (6f + 1f));
            yield return new WaitForSeconds(0.01f);
        }    
        
        yield return new WaitForSeconds(1.5f);
        for (int t = 0; t < 30; t++)
        {
            character_Spawnpoint[0].transform.Translate(Vector3.right * 6f);
            GameObject.FindGameObjectWithTag("MainCamera").transform.Translate(Vector3.right * (6f + 1f));
            yield return new WaitForSeconds(0.01f);
        }
    }
   
}
