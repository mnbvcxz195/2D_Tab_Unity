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

        btnStart[0].onClick.AddListener(OnClickStart);    //기존 버튼
        btnStart[1].onClick.AddListener(OnClickStart_2);    //해골 버튼
        btnStart[2].onClick.AddListener(OnClickStart_3);    //해골2 버튼
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
