using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    [Header("Jump")]
    private bool _canDoubleJump;
    public float JumpForce;

    [Header("Components")]
    public Rigidbody2D theRB;

    [Header("Animator")]
    private Animator _anim;
    private SpriteRenderer _theSR;

    [Header("Grounded")]
    private bool _IsGrounded;
    public Transform groundCheckpoint;
    public LayerMask WhatIsGround;

    void Start()
    {
        
        _anim = GetComponent<Animator>();
        _theSR = GetComponent<SpriteRenderer> ();
        
        
       
    }

    void Update()
    {
        // Movimiento horizontal
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

        // Verificar si el personaje está en el suelo
        _IsGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, 0.2f, WhatIsGround);

        // Control de salto
        if (_IsGrounded)
        {
            _canDoubleJump = true; // Permitir doble salto cuando está en el suelo
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (_IsGrounded) 
            {
                theRB.velocity = new Vector2(theRB.velocity.x, JumpForce);
            }
            else if (_canDoubleJump) 
            {
                theRB.velocity = new Vector2(theRB.velocity.x, JumpForce);
                _canDoubleJump = false; // Deshabilitar doble salto
            }
        }

        // Actualizar animaciones
         if (theRB.velocity.x < 0)
        {
            _theSR.flipX = true;
        } else if (theRB.velocity.x > 0)

        { 
            _theSR.flipX = false;
        
        }
        
        _anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        _anim.SetBool("_IsGrounded", _IsGrounded);
    }
}

