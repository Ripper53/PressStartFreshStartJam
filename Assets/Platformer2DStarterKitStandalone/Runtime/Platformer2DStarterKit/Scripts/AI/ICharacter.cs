using UnityEngine;
using Platformer2DStarterKit.Utility;

namespace Platformer2DStarterKit.AI {
    public interface ICharacter {
        WanderAIAction Wander { get; }
        Transform Transform { get; }
        Rigidbody2D Rigidbody { get; }
        SpriteRenderer SpriteRenderer { get; }
        FrameAnimator Animator { get; }
        Character Character { get; }
        CharacterMovement Movement { get; }
        CharacterStun Stun { get; }
        CharacterJump Jump { get; }
        CharacterDeath Death { get; }
        MovementExecution MovementExecution { get; }
        GradientRate Speed { get; }
        AIActionList ActionList { get; }
        Vector2 Position { get; set; }
        float Angle { get; set; }
        void Hide();
        void Show();
    }
}
