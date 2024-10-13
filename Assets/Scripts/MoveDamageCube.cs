using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDamageCube : MonoBehaviour
{
    [SerializeField] private GameObject CloseCube;
    [SerializeField] private GameObject MoveDamageObject;

    private bool OnOff = false;
    // Start is called before the first frame update
    void Start()
    {
        CloseCube.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (OnOff)
        {
            MoveDamageObject.transform.position += new Vector3(0f,0.05f,0f);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            CloseCube.SetActive(true);
            OnOff = true;
        }
    }
}
