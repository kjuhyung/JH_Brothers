using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator _anim;
    private PlayerInputController _controller;

    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Down = Animator.StringToHash("Down");
    private static readonly int Dash = Animator.StringToHash("Dash");
    private static readonly int Fire = Animator.StringToHash("Fire");


    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        _controller = GetComponent<PlayerInputController>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += OnWalkAnim;
        _controller.OnJumpEvent += OnJumpAnim;
        _controller.OnDownEvent += OnDownAnim;
        _controller.OnDashEvent += OnDashAnim;
        _controller.OnFireEvent += OnFireAnim;
    }    

    private void OnWalkAnim(Vector2 vector)
    {
        _anim.SetBool(Run, vector.magnitude > 0.5f);
    }

    private void OnJumpAnim()
    {
        _anim.SetTrigger(Jump);
    }

    private void OnDownAnim()
    {
        _anim.SetBool(Down, _controller.IsDown);
    }
    private void OnDashAnim()
    {
        _anim.SetTrigger(Dash);
    }

    private void OnFireAnim()
    {
        _anim.SetTrigger(Fire);
    }

}
