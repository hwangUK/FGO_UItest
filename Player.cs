using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ACTIVESKILL { SKILL_01, SKILL_02, SKILL_03, DEFAULT };
public enum CARDTYPE { BUSTER, ARTS, QUIK, B_ULT, A_ULT, Q_ULT, DEFAULT };
public enum SERVANTCLASS { SABER, ARCHER, LANCER, BERSERKER, RIDER, ASSESIN, CASTER, SHIELDER, RULELER, DEFAULT };

public enum SERVANTNAME { JAN, MASU };

public class Player : MonoBehaviour {

    public static Player MainPlayer = null;
    
    public List<Servant> myServantList = new List<Servant>();
    public Servant[] BattleTeam = new Servant[6];    

    private void Awake()
    {
        if (MainPlayer == null)
        {
            MainPlayer = this;
        }
        else
            Destroy(gameObject);        
    }

    public void addNewServant(Servant _servant)        
    {
        myServantList.Add(_servant);       
    }    

    void ExpUp(int selectServant, int expAmount)
    {
        //myServantList[selectServant].ServantExpUp(expAmount);
    }

    void ShowFriend()
    {
       // myFriend.GetFriend();
    } 

    void ShowItem()
    {
       // myItem.GetItem();
    } 

    void PrintNowState()
    {
        Debug.Log("My SERVANT Count  :  " + myServantList.Count);
        if (myServantList.Count != 0) ;
            //Debug.Log("My SERVANT name  :  " + myServantList[myServantList.Count-1].Getname());
    }
}
