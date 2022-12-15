using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public Button[] btnStart;

    void Start()
    {
        btnStart = GetComponentsInChildren<Button>();

        btnStart[0].onClick.AddListener(OnClickStart);    //���� ��ư
        btnStart[1].onClick.AddListener(OnClickStart_2);    //�ذ� ��ư
        btnStart[2].onClick.AddListener(OnClickStart_3);    //�ذ�2 ��ư
    }

    void OnClickStart()
    {
        GameManager.GetInstance().characterIdx = 0;
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }

    void OnClickStart_2()
    {
        GameManager.GetInstance().characterIdx = 1;
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }

    void OnClickStart_3()
    {
        GameManager.GetInstance().characterIdx = 2;
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
