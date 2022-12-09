using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionMenu : MonoBehaviour
{
    public Button btnPractice;
    public Button btnHealing;
    public Button btnBattle;

    public UIProfile prifile;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ui = UIManager.GetInstance().GetUI("UIProfile");
        if (ui != null)
            prifile = ui.GetComponent<UIProfile>();

        btnBattle.onClick.AddListener(OnClickBattle);
    }

    // Update is called once per frame
    void OnClickBattle()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Battle);
    }
}
