using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    PlayerInput playerInput;
    private Tween _tween;
    InputAction inputAction;   
    [SerializeField] private float speed;
    [SerializeField] private float angleRotete;
    [SerializeField] private float jumpForce;
    [SerializeField] private int amountJump;
    [SerializeField] private float timeJump;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        inputAction = playerInput.actions.FindAction("Move");
    }
    void Update()
    {
        Move();
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }
    }
    private void Move()
    {
        Vector2 dir  = inputAction.ReadValue<Vector2>();
        transform.position += new Vector3(dir.x, 0, dir.y) * speed * Time.deltaTime;
        transform.DORotateQuaternion(Quaternion.Euler(transform.rotation.x, transform.rotation.y + dir.x * angleRotete, transform.rotation.z), 1);
    }
    private void Jump()
    {
        transform.DOJump(transform.position, jumpForce, amountJump, timeJump);
    }
}
