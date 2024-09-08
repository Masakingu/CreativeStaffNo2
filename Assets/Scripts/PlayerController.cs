using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject PlayerSpriteObject;
    [SerializeField] private InputActionAsset inputActions;
    public InputAction moveAction;
    private Vector2 moveInput;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        var playerActionMap = inputActions.FindActionMap("Player");
        rigidbody = this.GetComponent<Rigidbody>();
        moveAction = playerActionMap.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpriteObject.transform.LookAt(Camera.transform.position);
        moveInput = moveAction.ReadValue<Vector2>();
        // 取得したVector2の値でキャラクターを移動
        Vector3 movement = new Vector3(moveInput.x*5f, 0,0 );
        transform.Translate(movement * Time.deltaTime);
        rigidbody.AddForce(new Vector3(0f,moveInput.y*98f,0f));
    }
    private void FixedUpdate(){

    }
}
