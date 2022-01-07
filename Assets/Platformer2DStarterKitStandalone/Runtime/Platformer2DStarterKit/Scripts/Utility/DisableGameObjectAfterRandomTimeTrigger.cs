using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public class DisableGameObjectAfterRandomTimeTrigger : MonoBehaviour {
        public float MinTime = 0f, MaxTime = 1f;
        public OneShotAudioEffectPooler OneShotAudioEffectPooler;
        public Vector2 Offset;

        private readonly List<TriggerObject> triggeredObjects = new List<TriggerObject>();

        public class TriggerObject {
            public readonly GameObject GameObject;
            public readonly Collider2D Collider;
            public float Timer;
            public TriggerObject(Collider2D collider, float time) {
                GameObject = collider.gameObject;
                Collider = collider;
                Timer = time;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.isTrigger)
                return;
            collision.enabled = false;
            triggeredObjects.Add(new TriggerObject(collision, Random.Range(MinTime, MaxTime)));
        }

        private void Update() {
            for (int i = 0; i < triggeredObjects.Count; i++) {
                TriggerObject triggerObject = triggeredObjects[i];
                if (triggerObject.Timer > 0f) {
                    triggerObject.Timer -= Time.deltaTime;
                } else {
                    ResetObj(triggerObject);
                    OneShotAudioEffect effect = OneShotAudioEffectPooler.Get();
                    effect.Set((Vector2)triggerObject.GameObject.transform.position + Offset);
                    effect.gameObject.SetActive(true);
                    triggeredObjects.RemoveAt(i--);
                    if (CharacterDeath.Kill(triggerObject.GameObject, out CharacterDeadBody characterDeadBody)) {
                        characterDeadBody.gameObject.SetActive(false);
                    } else {
                        triggerObject.GameObject.SetActive(false);
                    }
                }
            }
        }
        private static void ResetObj(TriggerObject triggerObject) {
            triggerObject.Collider.enabled = true;
        }

        public void Clear() {
            foreach (TriggerObject obj in triggeredObjects)
                ResetObj(obj);
            triggeredObjects.Clear();
        }

    }
}
