using UnityEngine;

namespace Platformer2DStarterKit.AI {
    public abstract class SideChecks : MonoBehaviour {
        public abstract CharacterInput.Direction Direction { get; }
        public Check GroundCheck;
        public Check WallCheck;
        public GetColliders WallGetColliders;
        /// <summary>
        /// If check is true, there is ground below, allow falling.
        /// </summary>
        [Tooltip("If check is true, there is ground below, allow falling.")]
        public Check FallCheck;
        /// <summary>
        /// If check is true, jump in the direction because there is ground above (not sure if it can be landed upon).
        /// </summary>
        [Tooltip("If check is true, jump in the direction because there is ground above (not sure if it can be landed upon).")]
        public Check JumpAboveCheck;
        /// <summary>
        /// If check is false, there is a place to land above.
        /// </summary>
        [Tooltip("If check is false, there is a place to land above.")]
        public Check FreeGroundAboveCheck;
        /// <summary>
        /// If check is true, jump in the direction because there is ground across a gap.
        /// </summary>
        [Tooltip("If check is true, jump in the direction because there is ground across a gap.")]
        public Check JumpAcrossCheck;
        /// <summary>
        /// If check is false, there is a place to land across.
        /// </summary>
        [Tooltip("If check is false, there is a place to land across.")]
        public Check FreeGroundAcrossCheck;
    }
}
