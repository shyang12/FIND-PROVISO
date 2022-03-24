using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject WalkS;
    GameObject RunS;
    GameObject JumpS;
    Animator _animator;
    // 스피드 조정 변수
    [SerializeField]
    private float walkSpeed;
    
    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private float crouchSpeed; 

    private float applySpeed;

    [SerializeField]
    private float jumpForce;

    // 상태 변수
    private bool IsRun = false;
    private bool isGround = true;
    private bool isCrouch = false;

    // 앉았을 때 얼마나 앉을지 결정하는 변수.
    [SerializeField]
    private float crouchPosY;
    private float originPosY;
    private float applyCrouchPosY;

    private CapsuleCollider capsuleCollider;

    [SerializeField]
    private float lookSensitivity;

    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0f;

    [SerializeField]
    private Camera theCamera;


    private Rigidbody myRigid;

    // Start is called before the first frame update
    void Start()
    {
        this.WalkS = GameObject.Find("Walk");
        this.RunS = GameObject.Find("Run");
        this.JumpS = GameObject.Find("Jump");
        _animator = this.GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        myRigid = GetComponent<Rigidbody>();
        applySpeed = walkSpeed;
        originPosY = theCamera.transform.localPosition.y;
        applyCrouchPosY = originPosY;
    }

    // Update is called once per frame
    void Update()
    {
        IsGround();
        TryJump();
        TryRun();
        TryCrouch();
        Move();
        CameraRotation();
        CharacterRotation();
    }

    private void TryCrouch()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
    }

    private void Crouch()
    {
        isCrouch = !isCrouch;
        if (isCrouch)
        {
            applySpeed = crouchSpeed;
            applyCrouchPosY = crouchPosY;
            transform.localScale = new Vector3(1, 0.5f, 1);
        }
        else
        {
            applySpeed = walkSpeed;
            applyCrouchPosY = originPosY;
            transform.localScale = new Vector3(1, 1, 1);
        }

        StartCoroutine(CrouchCoroutine());
    }
    IEnumerator CrouchCoroutine()
    {
        float _posY = theCamera.transform.localPosition.y;
        int count = 0;

        while(_posY != applyCrouchPosY)
        {
            _posY = Mathf.Lerp(_posY, applyCrouchPosY, 0.3f);
            theCamera.transform.localPosition = new Vector3(0, _posY, 0);
            yield return null;
            if (count > 15)
                break;
            yield return null;
        }
        theCamera.transform.localPosition = new Vector3(0, applyCrouchPosY, 0f);
    }

    private void Move()
    {
        bool move = false;

        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);


        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;
        Vector3 _moveDirection = forward * _moveDirX + right * _moveDirZ;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);


        if (_moveDirX == 0 && _moveDirZ == 0)
        {
            _animator.SetFloat("Blend", 0, 0.1f, Time.deltaTime);
            this.WalkS.GetComponent<AudioSource>().Stop();
        }
        else
        {
            _animator.SetFloat("Blend", 0.5f, 0.1f, Time.deltaTime);
            if (!this.WalkS.GetComponent<AudioSource>().isPlaying)
            {
                this.WalkS.GetComponent<AudioSource>().Play();
            }
        }
      
    }

    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;

        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _charactorRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_charactorRotationY));
        
    }

    private void TryRun()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Running();
            _animator.SetFloat("Blend", 1, 0.1f, Time.deltaTime);
            this.WalkS.GetComponent<AudioSource>().Stop();
            if (!this.RunS.GetComponent<AudioSource>().isPlaying)
            { 
                this.RunS.GetComponent<AudioSource>().Play();
            }
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancel();
            this.RunS.GetComponent<AudioSource>().Stop();
        }
    }

    private void Running()
    {
        IsRun = true;
        applySpeed = runSpeed;
    }

    private void RunningCancel()
    {
        IsRun = false;
        applySpeed = walkSpeed;
    }
    
    private void TryJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            jump();
            this.JumpS.GetComponent<AudioSource>().Play();
        }
    }

    private void jump()
    {
        myRigid.velocity = transform.up * jumpForce;
    }

    private void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.2f);
    }
}

