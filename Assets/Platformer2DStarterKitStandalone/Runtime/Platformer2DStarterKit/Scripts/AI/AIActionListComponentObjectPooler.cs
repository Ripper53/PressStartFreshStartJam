using Platformer2DStarterKit.AI;

namespace Platformer2DStarterKit.Utility {
    public class AIActionListComponentObjectPooler : ObjectPooler<AIActionListComponent> {
        public CharacterDeadBodyPooler CharacterDeadBodyPooler;

        protected override AIActionListComponent InstantiatePrefab() {
            AIActionListComponent ai = base.InstantiatePrefab();
            ai.Death.Initialize(CharacterDeadBodyPooler);
            return ai;
        }

    }
}
