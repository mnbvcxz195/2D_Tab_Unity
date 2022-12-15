using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.GetInstance().LoadData();


        /*if (GameManager.GetInstance().characterIdx == 0)
        {
            
        }
        else
        {
            characterName = GameManager.GetInstance().skeletoneImg;
            GameManager.GetInstance().totalHp = GameManager.GetInstance().skeletoneHp;
            GameManager.GetInstance().curHp = GameManager.GetInstance().skeletoneHp;
        }
*/
        int x = GameManager.GetInstance().characterIdx;
        var player = GameManager.GetInstance().SetPlayer(x);
        GameObject go = ObjectManager.GetInstance().CreateCharacter(player.playerName);
        go.transform.localScale = new Vector3(2, 2, 2);
        go.transform.localPosition = new Vector3(0, 1.1f, 0);

        UIManager.GetInstance().SetEventSystem();
        UIManager.GetInstance().OpenUI("UIProfile");
        UIManager.GetInstance().OpenUI("UIActionMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
