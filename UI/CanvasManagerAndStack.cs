using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasManagerAndStack : MonoBehaviour {

    //모든팝업창을 스택에 넣었을 시 뒤로가기버튼을 전역으로 입력받기위한 싱글톤
  
    public static CanvasManagerAndStack MainManager = null;
    public static int arraySize = 15;
    private int             Top;
    public  GameObject[]    getPopUpArray      = new GameObject[arraySize];
    public  GameObject[]    getButtonArray      = new GameObject[arraySize];
    private GameObject[]    setStackBuffer     = new GameObject[arraySize *2];

   
    public GameObject menuBar;
    public GameObject portrait;

    public List<GameObject> servantList = new List<GameObject>();
    //public List<GameObject> setServantList = new List<GameObject>();    
    int a = 0;

    void Awake()
    {
        //싱글톤 인스턴스 설정과 초기화
        if (MainManager == null)
        {
            MainManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    private void Start()
    {
        //기본캐릭생성       

        portrait.GetComponent<Image>().sprite = Player.MainPlayer.myServantList[0].GetImage_illust();
    }

    public GameObject Push(GameObject InputPushPopup)
    {
        if (Top < arraySize)
        {
            setStackBuffer[Top] = InputPushPopup;
            Top++;
            Debug.Log("TOP  :" + Top);
            return setStackBuffer[Top - 1];
        }
        else
        {
            Debug.Log("Stack Is Full");
            return null;
        }
    }

    public GameObject Pop()
    {
        if (Top > 0)
        {
            Debug.Log(setStackBuffer[Top - 1]);
            Top--;
            Debug.Log("TOP  :" + Top);
            return setStackBuffer[Top];
        }
        else
        {
            Debug.Log("Stack is Empty");
            return null;
        }
    }
    //------------------------------------------------------------

    public void ClickMenuBar()
    {
        GameObject gob = Instantiate(menuBar, transform);
        gob.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        gob.GetComponent<RectTransform>().localPosition = new Vector3(1f, gob.transform.GetComponent<RectTransform>().localPosition.y - 40.0f, 1f);
    }

    public void ClickMainServant()
    {
        if (a >= Player.MainPlayer.myServantList.Count - 1)
            a = 0;
        else
            a += 1;

        if (Player.MainPlayer.myServantList[a] != null)
            portrait.GetComponent<Image>().sprite = Player.MainPlayer.myServantList[a].GetImage_illust();
        else
            return;
    }

    public void MovingDown_MainServant()
    {
        StartCoroutine(C_Moving_MainServant());
    }
    public void MovingUp_MainServant()
    {
        portrait.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    IEnumerator C_Moving_MainServant()
    {
        for (int i = 0; i < 5; i++)
        {
            portrait.transform.localScale = new Vector3(portrait.transform.localScale.x - (i * 0.002f), portrait.transform.localScale.y - (i * 0.002f), 1f);
            yield return new WaitForSeconds(0.01f);
        }

    }    
}
