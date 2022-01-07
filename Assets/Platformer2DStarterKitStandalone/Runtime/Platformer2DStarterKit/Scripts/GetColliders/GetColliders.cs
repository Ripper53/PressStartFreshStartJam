using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit {
    /// <summary>
    /// Gets colliders using a LayerMask.
    /// </summary>
    public abstract class GetColliders : MonoBehaviour {
        public abstract ShapeParameter ShapeParameter { get; }
        public abstract IEnumerable<Collider2D> Get();
        /// <param name="collider">The gotten collider.</param>
        /// <returns>True if a collider was gotten, otherwise false.</returns>
        public abstract bool Get(out Collider2D collider);
    }
}
