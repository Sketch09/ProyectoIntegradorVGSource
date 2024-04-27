using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        bool isJumping = Input.GetKeyDown(KeyCode.Space);

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isJumping", isJumping);
    }
}
