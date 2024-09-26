using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rotationeSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
 
    [SerializeField] private Transform _groundCheckerTransform;
    [SerializeField] private GameObject _defeat;
    [SerializeField] private LayerMask _notPlayerMask;

    [SerializeField] public Slider _slider;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private float _radiusSphere = 0.3f;
    private CapsuleCollider _capsuleCollider;
    private bool _isGrounded;

    private int _maxLength = 1;
    private int _health = 100;

    private void Start()
    {
        _defeat.SetActive(false);
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _slider.maxValue = _health;
    }

    private void Update()
    {
        Move();
        CheckingPressedKey();

        if (Physics.CheckSphere(_groundCheckerTransform.position, _radiusSphere, _notPlayerMask))
        {
            _animator.SetBool("IsInAir", false);
            _isGrounded = true;
        }
        else
        {
            _animator.SetBool("IsInAir", true);
            _isGrounded = false;
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(horizontal, 0, vertical);

        if (directionVector.magnitude > Mathf.Abs(0.05f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * _rotationeSpeed);
        }

        _animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, _maxLength).magnitude);

        Vector3 moveDir = Vector3.ClampMagnitude(directionVector, _maxLength) * _speed;
        _rigidbody.velocity = new Vector3(moveDir.x, _rigidbody.velocity.y, moveDir.z);

        _rigidbody.angularVelocity = Vector3.zero; ;// вектор угловой скорости чтобы небыло вращения на месте 
    }

    private void CheckingPressedKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            UnCrouch();
        }
    }

    private void Jump()
    {
        if (_animator.GetBool("IsCrouching")) return;

        if (_isGrounded)
        {
            _animator.SetTrigger("Jump");
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void Crouch()
    {
        float heightCollayderCrouch = 1f;
        float sizeCollayderYCrouch = 0.39f;
        float dividerSpeedCrouch = 2;

        if (_isGrounded)
        {
            _animator.SetBool("IsCrouching", true);
            _speed = _speed / dividerSpeedCrouch;
            _capsuleCollider.height = heightCollayderCrouch;
            _capsuleCollider.center = new Vector3(_capsuleCollider.center.x, sizeCollayderYCrouch, _capsuleCollider.center.z);
        }
    }

    private void UnCrouch()
    {
        float speedStandart = 5;
        float heightCollayderOriginal = 1.306199f;
        float sizeCollayderYOriginal = 0.57f;

        _animator.SetBool("IsCrouching", false);
        _speed = speedStandart;
        _capsuleCollider.height = heightCollayderOriginal;
        _capsuleCollider.center = new Vector3(_capsuleCollider.center.x, sizeCollayderYOriginal, _capsuleCollider.center.z);
    }

    public void TakeDamage(int damage)
    {
        if (_health - damage > 0)
        {
            _health -= damage;
            _slider.value -= damage;
        }
        else
        {
            _slider.value -= damage;
            _defeat.SetActive(true);
            Time.timeScale = 0;
        }
    }
}