using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private JHCharacterController _controller;
    private Rigidbody2D _rigidbody;

    private Vector2 _movementDirection = Vector2.zero;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        _controller = GetComponent<JHCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();        
    }

    private void Start()
    {
        _controller.OnMoveEvent += PlayerMove;
        _controller.OnFireEvent += PlayerFire;
        _controller.OnJumpEvent += PlayerJump;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void PlayerMove(Vector2 direction)
    {
        _movementDirection = direction;
    }
    
    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * _movementSpeed;

        _rigidbody.velocity = direction;
    }

    private void PlayerFire()
    {
        CreateBomb();
    }

    private void CreateBomb()
    {
        GameObject bomb = ObjectPoolManager.Instance.GetGameObject(ObjectPoolType.Bomb);
        bomb.transform.position = this.transform.position;
        bomb.SetActive(true);
    }

    private void PlayerJump()
    {

    }
}
