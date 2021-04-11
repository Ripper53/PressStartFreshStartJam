using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.Utility;

public class CharacterWhip : MonoBehaviour {
    public FrameAnimator Animator;
    public SpriteAnimationBase WhipAnimation;
    public int HitIndex;
    public GetColliders HitGetColliders;
    public CharacterAnimator CharacterAnimator;
    public CharacterFlipAnimator CharacterFlipAnimator;
    public SpriteRenderer SpriteRenderer;
    public float HitOffsetX;
    public float HitTime;

    private float hitTimer = 0f;

    [System.NonSerialized]
    public bool WhipRequest = false;
    private bool toHit = false;

    private void FixedUpdate() {
        if (hitTimer > 0f) {
            hitTimer -= Time.fixedDeltaTime;
        } else {
            if (toHit) {
                CharacterDeath.Kill(HitGetColliders);
                toHit = false;
            }
            if (Animator.CurrentSpriteAnimation == WhipAnimation) {
                if (Animator.IsFinished) {
                    SetValue(true);
                }
            } else if (WhipRequest) {
                SetValue(false);
                Animator.SetAnimation(WhipAnimation);
                HitGetColliders.ShapeParameter.Offset.x = SpriteRenderer.flipX ? -HitOffsetX : HitOffsetX;
                hitTimer = HitTime;
                toHit = true;
            }
        }
        WhipRequest = false;
    }

    private void SetValue(bool value) {
        CharacterAnimator.enabled = value;
        CharacterFlipAnimator.enabled = value;
    }

}
