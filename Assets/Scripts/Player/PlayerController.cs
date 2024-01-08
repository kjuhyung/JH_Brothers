using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputController _controller;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriter;

    private Vector2 _movementDirection = Vector2.zero;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _dashForce;

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
        _controller.OnDownEvent += PlayerDown;
        _controller.OnDashEvent += PlayerDash;
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

        if (_movementDirection.x != 0)
        {
            _spriter.flipX = _movementDirection.x < 0;
        }
    }

    private void PlayerFire()
    {
        // TODO 공격 타입 변경 시 다른걸로 ex / if(attackType.Bomb) CreateBomb  // switch?
        CreateBomb();
    }

    private void CreateBomb()
    {
        GameObject bomb = ObjectPoolManager.Instance.GetGameObject(ObjectPoolType.Bomb);
        bomb.transform.position = this.transform.position; // TODO - 스폰 포지션 플레이어 살짝 앞에 정해줘야할듯
        bomb.SetActive(true);
    }

    private void PlayerJump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
    }

    private void PlayerDown()
    {
        _rigidbody.velocity = Vector2.zero;
    }

    private void PlayerDash()
    {
        Vector2 direction = _spriter.flipX ? Vector2.left : Vector2.right;

        _rigidbody.AddForce(direction * _dashForce, ForceMode2D.Force);        
    }
}
