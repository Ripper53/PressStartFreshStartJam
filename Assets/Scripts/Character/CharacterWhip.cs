using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.Utility;

public class CharacterWhip : MonoBehaviour {
    public FrameAnimator Animator;
    public SpriteAnimationBase DefaultAnimation;
    public SpriteAnimationBase WhipAnimation;
    public int HitIndex;
    public GetColliders HitGetColliders;
    public CharacterMovement CharacterMovement;
    public CharacterJump CharacterJump;
    public SpriteRenderer SpriteRenderer;
    public float HitOffsetX;

    [System.NonSerialized]
    public bool WhipRequest = false;

    private void FixedUpdate() {
        if (Animator.CurrentSpriteAnimation == WhipAnimation) {
            if (Animator.IsFinished) {
                SetValue(true);
                Animator.SetAnimation(DefaultAnimation);
            } else if (Animator.CurrentFrameIndex == HitIndex) {
                CharacterDeath.Kill(HitGetColliders);
            }
        } else if (WhipRequest) {
            SetValue(false);
            Animator.SetAnimation(WhipAnimation);
            HitGetColliders.ShapeParameter.Offset.x = SpriteRenderer.flipX ? -HitOffsetX : HitOffsetX;
        }
        WhipRequest = false;
    }

    private void SetValue(bool value) {
        CharacterMovement.enabled = value;
        CharacterJump.enabled = value;
    }

}
