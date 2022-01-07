using Platformer2DStarterKit.Utility;

namespace Platformer2DStarterKit.Utility {
    public class OneShotAudioEffectPooler : ObjectPooler<OneShotAudioEffect> {
        public OneShotAudioPooler OneShotAudioPooler;

        protected override OneShotAudioEffect InstantiatePrefab() {
            OneShotAudioEffect oneShotAudioEffect = base.InstantiatePrefab();
            oneShotAudioEffect.Initialize(OneShotAudioPooler);
            return oneShotAudioEffect;
        }

    }
}
