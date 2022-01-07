using UnityEngine;

namespace Platformer2DStarterKit {
    public abstract class LayerGetColliders : GetColliders {
        /// <summary>
        /// Layer(s) to detect.
        /// </summary>
        [Tooltip("Layer(s) to detect.")]
        public LayerMask LayerMask;
    }
}
