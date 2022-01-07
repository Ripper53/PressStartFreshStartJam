using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit {
    /// <summary>
    /// Same as BoxGetColliders, but excludes a GameObject from being detected!
    /// Useful for not detecting the player itself!
    /// </summary>
    public class ExclusiveBoxGetColliders : BoxGetColliders {
        public GameObject ToExclude;

        public override IEnumerable<Collider2D> Get() {
            int savedLayer = ToExclude.layer;
            ToExclude.layer = 2; // Ignores raycasts!
            IEnumerable<Collider2D> cols = base.Get();
            ToExclude.layer = savedLayer;
            return cols;
        }

    }
}
