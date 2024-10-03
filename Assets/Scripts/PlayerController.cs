using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject PlayerSpriteObject;
    [SerializeField] private GameObject GoalPanel;
    [SerializeField] private GameObject FailedPanel;

    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private float LimitTop;
    
    private InputAction moveAction;
    private bool isGround;
    private Vector2 moveInput;
    public new Rigidbody rigidbody;
    public float moveSpeed = 5f;  // 移動速度
    public float jumpForce = 130f;  // ジャンプ力

    void Start()
    {
        // アクションマップとアクションの初期化
        var playerActionMap = inputActions.FindActionMap("Player");
        rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        moveAction = playerActionMap.FindAction("Move");
        GoalPanel.SetActive(false);
        FailedPanel.SetActive(false);
        // アクションを有効化
        moveAction.Enable();
        Time.timeScale = 1f;
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
        if (isGround && moveInput.y > 0)
        {
        if(Physics.gravity == new Vector3(0, -9.81f, 0)){
        // ジャンプ処理
        
            // 一度だけジャンプ力を適用する
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;  // ジャンプ中は地面についていない
        
        }
        }else if(isGround && moveInput.y < 0){
            if(Physics.gravity == new Vector3(0, 9.81f, 0)){
        
            // 一度だけジャンプ力を適用する
            rigidbody.AddForce(Vector3.down * jumpForce, ForceMode.Impulse);
            isGround = false;  // ジャンプ中は地面についていない
        
        }
        }

        if(this.transform.position.y < -5||this.transform.position.y > LimitTop){
            FailedPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 接地判定: 地面に触れたときのみジャンプが可能
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;  // 接地したら再びジャンプ可能に
        }
        if (collision.gameObject.tag == "Death")
        {
            FailedPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }
     private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Goal")
        {
            GoalPanel.SetActive(true);
            Time.timeScale = 0f;
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

    public void OnRestartButtonClick(){
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    }
}
