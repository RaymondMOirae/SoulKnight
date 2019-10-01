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

    // charactor components
    private Animator pAnimator;
    public WeaponManager wManager;
    public Weapon curWeapon;

    

    // Start is called before the first frame update
    void Start()
    {
        pAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        transform.Translate((Vector3.right * inputH + Vector3.up * inputV) * moveSpeed * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            curWeapon.Attack();
            pAnimator.Play("KnifeAttack");
        }
        else if(Input.GetMouseButtonDown(1))
        {
            wManager.SwitchWeapon();
        }
        else
        {
            pAnimator.SetBool("pressMouseL", false);
        }
    }
}
