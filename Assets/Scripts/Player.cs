using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator m_anim;
    private Rigidbody2D m_rigidbody;
    private bool m_isJumping;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (m_isJumping)
        {
            return;
        }
        m_isJumping = true;
        m_anim.SetTrigger("Jump");
        m_rigidbody.AddForce(new Vector2(0, 500));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_isJumping = false;
    }
}
