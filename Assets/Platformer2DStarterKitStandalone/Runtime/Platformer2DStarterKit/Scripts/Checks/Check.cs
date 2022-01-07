using UnityEngine;

namespace Platformer2DStarterKit {
    public abstract class Check : MonoBehaviour {
        public abstract ShapeParameter ShapeParameter { get; }
        /// <returns>True if evaluation is true, otherwise false.</returns>
        public abstract bool Evaluate();
    }
}
