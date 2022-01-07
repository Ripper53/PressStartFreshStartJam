using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit {
    public class PredictionPlatformGroundType : PlatformGroundType {

        private readonly List<RaycastHit2D> hits = new List<RaycastHit2D>();

        public override void Initialize(PlatformGround platformGround) {
            hits.Clear();
        }

        public override Vector2 GetMovement(PlatformGround platformGround) {
            Vector2 diff = platformGround.MovementExecution.Movement;
            float dis = diff.magnitude;
            platformGround.MovementExecution.Rigidbody.Cast(diff, hits, dis);
            foreach (RaycastHit2D hit in hits) {
                if (hit.distance < dis) {
                    if (hit.distance < 0.01f)
                        return Vector2.zero;
                    else
                        return diff.normalized * hit.distance;
                }
            }
            hits.Clear();
            return diff;
        }

    }
}
