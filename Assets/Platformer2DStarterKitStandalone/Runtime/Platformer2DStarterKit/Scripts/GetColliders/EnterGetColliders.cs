using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit {
    public class EnterGetColliders : GetColliders {
        public GetColliders GetColliders;
        public override ShapeParameter ShapeParameter => GetColliders.ShapeParameter;

        private HashSet<Collider2D> sets = new HashSet<Collider2D>(), allOn = new HashSet<Collider2D>();
        private readonly HashSet<Collider2D> newCols = new HashSet<Collider2D>();

        public override IEnumerable<Collider2D> Get() {
            newCols.Clear();
            allOn.Clear();
            foreach (Collider2D col in GetColliders.Get()) {
                allOn.Add(col);
                if (sets.Add(col))
                    newCols.Add(col);
            }
            HashSet<Collider2D> temp = sets;
            sets = allOn;
            allOn = temp;
            return newCols;
        }

        public override bool Get(out Collider2D collider) {
            foreach (Collider2D col in Get()) {
                collider = col;
                return true;
            }
            collider = null;
            return false;
        }

    }
}
