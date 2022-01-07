using Platformer2DStarterKit.Utility;

namespace Platformer2DStarterKit.AI {
    public interface IAIAction {
        bool Execute(AIActionList.Token token);

        /// <summary>
        /// Uses a different execution if conditional! Only executes if condition is true!
        /// </summary>
        public interface IConditional {
            bool Condition(Token token);
            public class Token {
                public readonly ICharacter Source;
                public Token(ICharacter source) {
                    Source = source;
                }
            }
        }
        public interface IReinitialize {
            void Reinitialize(Token token);
            public class Token {
                public readonly ICharacter Source;
                public Token(ICharacter source) {
                    Source = source;
                }
            }
        }
        public interface IInitialize {
            void Initialize(Token token);
            public class Token {
                public readonly ICharacter Source;
                public readonly PoolerRepository PoolerRepository;
                public Token(ICharacter source, PoolerRepository poolerRepository) {
                    Source = source;
                    PoolerRepository = poolerRepository;
                }
            }
        }
        public interface IRemove {
            void Remove();
        }
        public interface IStartable {
            void Start(Token token);
            public class Token {
                public readonly ICharacter Source;
                public Token(ICharacter source) {
                    Source = source;
                }
            }
        }
        public interface ICancelable {
            void Cancel(Token token);
            public class Token {
                public readonly ICharacter Source;
                public Token(ICharacter source) {
                    Source = source;
                }
            }
        }

    }
}
