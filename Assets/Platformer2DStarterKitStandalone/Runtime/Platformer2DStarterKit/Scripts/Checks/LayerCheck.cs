using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit {
    public abstract class LayerCheck : Check {
        [Space]
        /// <summary>
        /// Layer(s) to detect.
        /// </summary>
        [Tooltip("Layer(s) to detect.")]
        public LayerMask LayerMask;
    }
}
