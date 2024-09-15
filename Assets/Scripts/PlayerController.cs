using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rotationeSpeed =  10f;
    [SerializeField] private float _speed = 4f;
    [SerializeField] private Transform _groundCheckerTransform;
    [SerializeField] private LayerMask _notPlayerMask;
    [SerializeField] private float _jumpForce = 2f;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private float _raycastDistance = 0.2f;
    private CapsuleCollider _capsuleCollider;
    private bool _isGrounded;
   
    private int maxLength = 1;

    private void Start()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        CheckingPressedKey();

        if (Physics.CheckSphere(_groundCheckerTransform.position, 0.3f, _notPlayerMask))
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

        _animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, maxLength).magnitude);

        Vector3 moveDir = Vector3.ClampMagnitude(directionVector, maxLength) * _speed;// теперь ограничиваем движение и двигаемся с 1
        _rigidbody.velocity = new Vector3(moveDir.x, _rigidbody.velocity.y, moveDir.z);

        _rigidbody.angularVelocity = Vector3.zero;// вектор угловой скорости чтобы небыло вращения на месте 
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
        float sizeCollayderYCrouch = 0.48f;
        float dividerSpeedCrouch =  2;

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
        float heightCollayderOriginal = 1.24834f;
        float sizeCollayderYOriginal = 0.6217127f;

        _animator.SetBool("IsCrouching", false);
        _speed = speedStandart;
        _capsuleCollider.height = heightCollayderOriginal;
        _capsuleCollider.center = new Vector3(_capsuleCollider.center.x, sizeCollayderYOriginal, _capsuleCollider.center.z);
    }
}
