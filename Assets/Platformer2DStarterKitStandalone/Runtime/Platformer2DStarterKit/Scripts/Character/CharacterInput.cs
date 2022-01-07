namespace Platformer2DStarterKit {
    [System.Serializable]
    public struct CharacterInput {
        public enum Direction { None = 0, Right = 1, Left = -1 };
        public Direction Dir;
        /// <summary>
        /// True if character wants to jump when it can, otherwise false.
        /// Reset every fixed frame.
        /// </summary>
        public bool JumpRequest;
    }
}
