using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // input parameters
    private float inputH;
    private float inputV;

    // charactor property values
    [SerializeField]
    private float moveSpeed;
    public bool knifeFight;

    // charactor components
    private Animator pAnimator;
    public WeaponManager wManager;
    public Weapon curWeapon;

    public float NextFire;
    

    // Start is called before the first frame update
    void Start()
    {
        pAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        curWeapon.RotateToAimCursor();
    }

    void HandleInput()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        transform.Translate((Vector3.right * inputH + Vector3.up * inputV) * moveSpeed * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            curWeapon.Attack();
        }
        else
        {
            ReturnIdle();
        }
    }

    void ReturnIdle()
    {
        pAnimator.SetBool("pressMouseL", false);
    }

    void KnifeFight()
    {
        pAnimator.SetBool("pressMouseL", true);
    }
}
