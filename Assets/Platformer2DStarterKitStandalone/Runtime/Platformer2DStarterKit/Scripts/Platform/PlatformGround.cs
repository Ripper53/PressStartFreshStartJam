using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit {
    /// <summary>
    /// IPlatformables will move along with this object.
    /// </summary>
    public class PlatformGround : MonoBehaviour {
        public MovementExecution MovementExecution;
        public GetColliders GetColliders;

        public PlatformGroundType Type;

        private HashSet<IPlatformable> alreadyOn = new HashSet<IPlatformable>();
        private HashSet<IPlatformable> newOn = new HashSet<IPlatformable>();

        private void OnEnable() {
            Type.Initialize(this);
        }

        private void FixedUpdate() {
            Vector2 diff = Type.GetMovement(this);

            foreach (IPlatformable platformable in Get()) {
                // If NOT already on, don't make position change from last fixed update!
                // This will not make the platformables that have just entered to move, useful for when moving along great distances.
                // Don't want to move a great distance underneath something, and then have the thing we go underneath be moved away from us because it's now on the platform!
                // Excluding the platformable that just entered will get rid of this behavior!
                if (platformable.IsMoveable && !alreadyOn.Add(platformable)) {
                    platformable.MovementExecution.AddPosition(diff);
                }
                newOn.Add(platformable);
            }

            alreadyOn.Clear();
            HashSet<IPlatformable> tempAlreadyOn = alreadyOn;
            alreadyOn = newOn;
            newOn = tempAlreadyOn;
        }

        private readonly List<IPlatformable> platformables = new List<IPlatformable>();
        public IEnumerable<IPlatformable> Get() {
            platformables.Clear();
            foreach (Collider2D col in GetColliders.Get()) {
                IPlatformable platformable = col.GetComponent<IPlatformable>();
                if (platformable == null) continue;
                platformables.Add(platformable);
            }
            return platformables;
        }

    }
}
