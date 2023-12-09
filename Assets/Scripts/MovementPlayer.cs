using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float movSpeed;
    private Vector2 moveDir;
    private Animator animator;
    public SpriteRenderer playerRender;
    public SpriteRenderer weaponRender;
    Vector3 mousePosition;
    public Transform weapon;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movSpeedX = Input.GetAxisRaw("Horizontal") * movSpeed ;
        float movSpeedY = Input.GetAxisRaw("Vertical") * movSpeed ;
        moveDir = new Vector2(movSpeedX, movSpeedY);
        rb.velocity = moveDir.normalized * movSpeed;


        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("Run", true);
        }
        else if (Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        Vector3 aimDir = weapon.position - mousePosition ;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg ;
        weapon.rotation = Quaternion.Euler(0f, 0f, angle - 180);

        if (Mathf.Abs(angle) > 90)
        {
            weaponRender.flipY = false;
            playerRender.flipX = false;
        }

        else
        {
            weaponRender.flipY = true;
            playerRender.flipX = true;
        }
            

        
    }
}
