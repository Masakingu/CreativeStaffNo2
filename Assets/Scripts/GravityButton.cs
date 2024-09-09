using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityButton : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private Rigidbody rigidbody;
    private bool isgravity = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = Player.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnGravityButtonClick(){
        if(isgravity){
             Physics.gravity = new Vector3(0, 9.8f, 0); 
             isgravity = false;
        }else{
             Physics.gravity = new Vector3(0, -9.8f, 0);
             isgravity = true;
        }
    }
}
