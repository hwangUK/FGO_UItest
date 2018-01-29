using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Menubar : MonoBehaviour {
    

    private void Start()
    {
        MoveingUp();
    }

    public void MoveingUp()
    {       
        StartCoroutine(MovingUp());
    }
    public void MoveingDown()
    {
        StartCoroutine(MovingDown());
    }

    public IEnumerator MovingUp()
    {
        for(int i =0; i < 9; i++)
        {
            transform.Translate(Vector3.up * 0.2f);
            yield return new WaitForSeconds(0.01f);
        }                   
    }

    public IEnumerator MovingDown()
    {
        for (int i = 0; i < 9; i++)
        {
            transform.Translate(Vector3.down * 0.2f);
            yield return new WaitForSeconds(0.003f);
        }
        DestroyThis();
    }  

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
