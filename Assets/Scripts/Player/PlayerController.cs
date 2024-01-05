using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputController _controller;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriter;

    private Vector2 _movementDirection = Vector2.zero;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        _controller = GetComponent<PlayerInputController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriter = GetComponentInChildren<SpriteRenderer>();
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

        if (_controller.moveInput.x != 0)
        {
            _spriter.flipX = _controller.moveInput.x < 0;
        }
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
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
    }
}
