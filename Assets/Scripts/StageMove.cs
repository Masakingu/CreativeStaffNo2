using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StageMove : MonoBehaviour
{ 
    [SerializeField] private float Times;
    private Vector3 defPosition; 
    float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        defPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var radius = 5f;
        var x =  radius * Mathf.Sin(Times +Time.time * speed);      //X軸の設定
        var y = radius * Mathf.Cos(Times +Time.time * speed);      //Z軸の設定

        transform.position = new Vector3(x+defPosition.x,y+defPosition.y, defPosition.z);  //自分のいる位置から座標を動かす。
    }
}
