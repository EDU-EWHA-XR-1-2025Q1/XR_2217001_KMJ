using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D04_Scripting : MonoBehaviour
{
    // Start is called before the first frame update
    //시작하기 전 초기에 세팅해야 할 것들
    void Start()
    {
        print("hello world");
        Debug.Log(gameObject.name);
    }

    // Update is called once per frame
    //시작 후 계속해서 반복해 확인해야 할 것들
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) //위쪽 방향키를 꾹 누르고 있다면
        {
            transform.Translate(0, 0, 0.5f);
        }
        if (Input.GetKey(KeyCode.DownArrow)) //아래쪽 방향키를 꾹 누르고 있다면
        {
            transform.Translate(0, 0, -0.5f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -1, 0); //유니티는 360degree 값을 씀
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 1, 0); 
        }
    }
}
