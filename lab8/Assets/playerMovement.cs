using UnityEngine.SceneManagement;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public playerController controller;
    public Animator animator;
    public float runSpeed = 30f;
    bool jump = false;
    float horizontalMove = 0f;

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    public void OnLanding()
    {
        Debug.Log("OnLanding()");
        animator.SetBool("IsJumping", false);
    }
}