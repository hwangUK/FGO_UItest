using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wnd_NewServant : MonoBehaviour
{
    public GameObject DefaultCard;
    private GameObject CardNow = null;

    int Rand = 0;    

    void Start()
    {
        StartCoroutine(RotationCardAnimation(CardNow = Instantiate(DefaultCard, transform)));        
    }

    void SetRandom()
    {
        Rand = Random.Range(0, 9);
        Debug.Log(Rand);
    }

    IEnumerator RotationCardAnimation(GameObject gob)
    {
        SetRandom();
        int RotateCount = 120;
        for (int i = 0; i < RotateCount && gob; i++)
        {
            if (i * 1.5 > RotateCount);
            //anum
            else gob.transform.Rotate(Vector3.up * (RotateCount - i * 1.5f));
            yield return new WaitForSeconds(0.02f);
        }
        PickUpResult();
    }

    public void PickUpResult()
    {
        Instantiate(CanvasManagerAndStack.MainManager.servantList[Rand], GameObject.FindGameObjectWithTag("Player").transform);      //서번트생성  
        for (int i = 0; i < 2; i++)
        {
            CardNow.transform.GetChild(i).GetComponent<MeshRenderer>().material = CanvasManagerAndStack.MainManager.servantList[Rand].GetComponent<MakeServant>().m_materialCard;
        }
        Debug.Log(Rand + "<-RAND");        
        StartCoroutine(WaitAndDestory(3f));        
    }

    public void WaitAnD()
    {
        StartCoroutine(WaitAndDestory(3f));
    }

    IEnumerator WaitAndDestory(float value)
    {
        yield return new WaitForSeconds(value);        
        Destroy(gameObject);
        Canvas_PushPop.nowPopupIndex--;
        CanvasManagerAndStack.MainManager.Pop();
    }    
}