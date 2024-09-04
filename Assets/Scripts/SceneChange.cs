using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    
    [SerializeField] private string SceneName;
    public void OnClick(){
        SceneManager.LoadScene(SceneName);
    }
}
