using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas_PushPop : MonoBehaviour {

    //어떤팝업창에서나 같은 팝업클론객체를 가리켜야하기때문에 static // 프리팹 인스펙터창에서 클릭 이벤트 연결을 해야하기 때문에 
    private static GameObject[]  popUpClone     = new GameObject[CanvasManagerAndStack.arraySize *2]; 
    public static int           nowPopupIndex = 0;
    public bool menuBtn_onoff = true;
    public bool backBtn_onoff = true;

    private void MakePopupWind(int _inputIndex)
    {
        //팝업오브젝트를 스택에 PUSH, 인스턴스 생성 
        popUpClone[nowPopupIndex] = Instantiate(CanvasManagerAndStack.MainManager.Push(CanvasManagerAndStack.MainManager.getPopUpArray[_inputIndex]), transform);

        // 생성 위치 캔버스의 자식이 되도록
        popUpClone[nowPopupIndex].transform.SetParent(GameObject.Find("Canvas_Main").transform.GetChild(2).transform);
        popUpClone[nowPopupIndex].GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);        
        nowPopupIndex++;
    }

    private void MakePopupBtn(int _inputIndex)
    {
        //버튼 오브젝트를 스택에 PUSH, 인스턴스 생성 
        popUpClone[nowPopupIndex] = Instantiate(CanvasManagerAndStack.MainManager.Push(CanvasManagerAndStack.MainManager.getButtonArray[_inputIndex]), transform);

        // 생성 위치 캔버스의 자식이 되도록
        //칼데아게이트 위치
        popUpClone[nowPopupIndex].transform.SetParent(GameObject.Find("Canvas_Main").transform.GetChild(1).GetChild(0).transform);
        //popUpClone[nowPopupIndex].transform.SetParent(GameObject.Find("Canvas_Main").transform.GetChild(1).transform);
        
        popUpClone[nowPopupIndex].GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);

        nowPopupIndex++;
    }

    //index 매개변수를 통해서 원하는 팝업창 호출
    public void Click_Open(int index)
    {
        if (nowPopupIndex == 0)
        {
            MakePopupWind(index);
        }
        //바로 전에 저장된 팝업창과 이름을 비교하여 중복이면 새로만들지 않는다 popUpClon[nowPopupIndex - 1].gameObject.name != MyStack.mystackInstance.getPopUpArray[index].gameObject.name + "(Clone)"
        else if (nowPopupIndex > 0 && nowPopupIndex < CanvasManagerAndStack.arraySize && popUpClone[nowPopupIndex - 1].gameObject.name != CanvasManagerAndStack.MainManager.getPopUpArray[index].gameObject.name + "(Clone)")
        {
            MakePopupWind(index);
        }
        else
        {
            Debug.Log("PopUp Already Made or Stack Is Full");           
        }            
    }
    //버튼
    public void Click_Open_Btn(int index)
    {
        if (nowPopupIndex == 0)
        {
            MakePopupBtn(index);
        }
        //바로 전에 저장된 팝업창과 이름을 비교하여 중복이면 새로만들지 않는다 popUpClon[nowPopupIndex - 1].gameObject.name != MyStack.mystackInstance.getPopUpArray[index].gameObject.name + "(Clone)"
        else if (nowPopupIndex > 0 && nowPopupIndex < CanvasManagerAndStack.arraySize && popUpClone[nowPopupIndex - 1].gameObject.name != CanvasManagerAndStack.MainManager.getButtonArray[index].gameObject.name + "(Clone)")
        {
            MakePopupBtn(index);
        }
        else
        {
            Debug.Log("PopUp Already Maked or Stack Is Full");
            ;
        }
    }

    public void Click_Close()
    {
        if(nowPopupIndex == 0)
        {
            Debug.Log("No Exist Open PopUP");
        }
        else if(nowPopupIndex > 0)
        { 
            //팝업오브젝트를 POP 인스턴스 삭제
            Destroy(popUpClone[nowPopupIndex - 1].gameObject);
            CanvasManagerAndStack.MainManager.Pop();
            nowPopupIndex--;            
        }             
    }        

    public void Click_MenuButton()
    {
        CanvasManagerAndStack.MainManager.ClickMenuBar();
    }

    public void GoNextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
