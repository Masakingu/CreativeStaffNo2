using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManagement : MonoBehaviour
{
    [SerializeField] private List<GameObject> Buttons = new List<GameObject>();

    static public List<bool> Cleared = new List<bool>()//クリアしたステージのリスト、Stage1から
    {
        false,false,false
    };

    static public List<string> SceneName = new List<string>()//シーン名Clearedと照らし合わせる用
    {
        "Stage1","Stage2","Stage3"
    };

    // Start is called before the first frame update
    void Awake()
    {
        // 常に Stage1 のボタンは表示
        if (Buttons.Count > 0 && Buttons[0] != null)
        {
            Buttons[0].SetActive(true);
        }

        // Stage1 がクリア済みなら Stage2 のボタンを表示、というように順番に処理
        for (int i = 0; i < Mathf.Min(Cleared.Count, Buttons.Count - 1); i++)
        {
            if (Cleared[i] && Buttons[i + 1] != null)
            {
                Buttons[i + 1].SetActive(true);
            }
            else if (Buttons[i + 1] != null)
            {
                Buttons[i + 1].SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
