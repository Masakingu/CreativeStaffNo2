using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject PlayerSpriteObject;
    [SerializeField] private InputActionAsset inputActions;
    
    private InputAction moveAction;
    private bool isGround;
    private Vector2 moveInput;
    private Rigidbody rigidbody;
    public float moveSpeed = 5f;  // 移動速度
    public float jumpForce = 130f;  // ジャンプ力

    void Start()
    {
        // アクションマップとアクションの初期化
        var playerActionMap = inputActions.FindActionMap("Player");
        rigidbody = this.GetComponent<Rigidbody>();
        moveAction = playerActionMap.FindAction("Move");

        // アクションを有効化
        moveAction.Enable();
    }

    void Update()
    {
        // キャラクターの向きをカメラに常に向ける
        PlayerSpriteObject.transform.LookAt(Camera.transform.position);

        // 入力の取得
        moveInput = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // 水平方向の移動
        Vector3 movement = new Vector3(moveInput.x * moveSpeed, rigidbody.velocity.y, 0);
        rigidbody.velocity = movement;

        // ジャンプ処理
        if (isGround && moveInput.y > 0)
        {
            // 一度だけジャンプ力を適用する
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;  // ジャンプ中は地面についていない
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 接地判定: 地面に触れたときのみジャンプが可能
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;  // 接地したら再びジャンプ可能に
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // 地面から離れたときはジャンプ不可にする
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
}
