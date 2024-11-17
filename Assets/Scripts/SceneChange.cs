using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    
    [SerializeField] private string SceneName;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ClickSE;
    public void OnClick(){
        audioSource.PlayOneShot(ClickSE);
        SceneManager.LoadScene(SceneName);
    }
}
