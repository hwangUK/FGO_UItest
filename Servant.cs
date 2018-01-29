using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Servant {    

    string  m_name;
    int     m_hp;
    int     m_atk;
    int     m_exp;
    int     m_servantLevel;

    SERVANTCLASS    m_servantClass = new SERVANTCLASS();
    CARDTYPE[]      m_fiveCardType = new CARDTYPE[6];
    ACTIVESKILL[]   m_activeSkill = new ACTIVESKILL[6];

    //Sprite[] m_image_illust;
    Sprite m_sprite_Face = new Sprite();
    Sprite m_sprite_Card = new Sprite();
    Sprite m_sprite_Illust = new Sprite();
    Sprite m_sprite_Selectfriend = new Sprite();
    Sprite m_sprite_Formation = new Sprite();

    List<Sprite> m_sprite_IngameImage = new List<Sprite>();
    Material m_mat_card;
    //Sprite[] m_image_face = new Sprite[4];
    //Sprite[] m_image_ingame;

    //Animation[] m_servantAnim;
    //TextAsset[] m_dialogue;
    //GameObject[] m_servantModel;

    //float[] m_fortuneRate =  new float[6];
 
    public Servant()
    {
        m_name = "default";
        m_hp = 0;
        m_atk = 0;
        m_exp = 0;
        m_servantLevel = 0;
        m_servantClass = SERVANTCLASS.DEFAULT;
        
        for (int i = 0; i < 6; i++)
        {
            m_fiveCardType[i] = CARDTYPE.DEFAULT;
            m_activeSkill[i] = ACTIVESKILL.DEFAULT;
            //m_image_illust[i] = null;
            //m_image_face[i] = null;
            //m_image_ingame[i] = null;
            //m_servantAnim[i] = null;
            //m_dialogue[i] = null;
            //m_servantModel[i] = null;
            //m_fortuneRate[i] = 0f;
        }      
        
    }

    public void SetServant_Basic(string servant_Name, int Basic_HP, int Basic_Atk, SERVANTCLASS ServantClass, 
        CARDTYPE[] fivecardType, ACTIVESKILL[] setActiveSkill, Sprite face, Sprite card, Sprite illust, Sprite selectfriend_, Sprite formation_, List<Sprite> ingameImg_, Material matCard_)
        //Sprite[] illustSprite, Sprite[] faceSprite, Sprite[] ingameSprite, Animation[] animation, TextAsset[] dialogue)
    {
        m_name = servant_Name;
        m_hp = Basic_HP;
        m_atk = Basic_Atk;
        m_servantLevel = 1;
        m_servantClass = ServantClass;

        m_fiveCardType = fivecardType;
        m_activeSkill = setActiveSkill;

        m_sprite_Face = face;
        m_sprite_Card = card;
        m_sprite_Illust = illust;
        m_sprite_Selectfriend = selectfriend_;
        m_sprite_Formation = formation_;
        m_sprite_IngameImage = ingameImg_;
        m_mat_card = matCard_;
        //m_image_illust = illustSprite;
        //m_image_face = faceSprite;
        //m_image_ingame = ingameSprite;
        //m_servantAnim = animation;
        //m_dialogue = dialogue;           
    }


    public void IsWeekClass(SERVANTCLASS input)
    {

    }

    public void ServantExpUp(int InputExp)
    {
        m_exp += InputExp; //경험치 업 
        if (m_exp >= 100) ServantLevlUp(); 
    }

    private void ServantLevlUp()
    {
        m_servantLevel += 1;
        m_activeSkill[0] += 1;
        //레벨업, 스킬레벨업,이미지변경
    }
    

    public Sprite GetImage_face()
    {
        return m_sprite_Face;
    }
    public Sprite GetImage_card()
    {
        return m_sprite_Card;
    }
    public Sprite GetImage_illust()
    {
        return m_sprite_Illust;
    }
    public Sprite GetImage_selectfriend()
    {
        return m_sprite_Selectfriend;
    }
    public Sprite GetImage_formation()
    {
        return m_sprite_Formation;
    }
    public Sprite GetImage_ingameImg(int num)
    {
        return m_sprite_IngameImage[num];
    }
    public Material GetImage_cardMaterial()
    {
        return m_mat_card;
    }
    public string Getname()
    {
        return m_name;
    }
    /*public Sprite GetImage_illust()
    {
        return m_image_illust[m_servantLevel];       
    }
    public Sprite GetImage_face()
    {
        return m_image_face[m_servantLevel];
    }
    public Sprite Getimage_ingame()
    {
        return m_image_ingame[m_servantLevel];
    }*/

}
