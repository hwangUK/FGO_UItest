using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeServant : MonoBehaviour {

    public string setName;
    public int setBasicHP;
    public int setBasicAtk;
    public SERVANTCLASS setServantClass;
    public CARDTYPE[] setFivecardtype = new CARDTYPE[6];
    public ACTIVESKILL[] setActiveSkill = new ACTIVESKILL[3];
    public Sprite setFaceSprite;
    public Sprite setCardSprite;
    public Sprite setIllustSprite;
    public Sprite setSelectFriendSprite;
    public Sprite setFormationSprite;

    public List<Sprite> ingameImg = new List<Sprite>();
    public Material m_materialCard;
	// Use this for initialization
	void Start () {
        MakeServantfunc();
    }
	
    void MakeServantfunc()
    {
        Servant NewServant = new Servant();
        NewServant.SetServant_Basic(setName, setBasicHP, setBasicAtk, setServantClass, setFivecardtype, setActiveSkill, setFaceSprite, setCardSprite, setIllustSprite, setSelectFriendSprite, setFormationSprite, ingameImg, m_materialCard);
        Player.MainPlayer.addNewServant(NewServant);
    }	
}
