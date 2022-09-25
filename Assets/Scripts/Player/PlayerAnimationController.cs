using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
	[SerializeField] private Animator animator;
    private float playerAbsSpeed;
    private void Update() {
        playerAbsSpeed = Mathf.Abs(playerController.HorInput);
        animator.SetFloat("PlayerSpeed", playerAbsSpeed);
        animator.SetBool("IsGrounded", playerController.IsGrounded);
        
        if (!playerController.DoubleJumpAble) {
            animator.SetTrigger("DoubleJump");
        }

        if (playerController.FireballAttack) {
            animator.SetTrigger("FireballAttack");
            playerController.FireballAttack = false;
        }
    }
}
