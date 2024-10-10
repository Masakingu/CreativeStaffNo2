using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAction : MonoBehaviour
{
    [SerializeField]private GameObject KeyFilter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            Destroy(KeyFilter);
            Destroy(this.gameObject);
        }
    }
}
