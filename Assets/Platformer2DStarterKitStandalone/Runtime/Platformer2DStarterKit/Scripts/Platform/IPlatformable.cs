namespace Platformer2DStarterKit {
    /// <summary>
    /// Rigidbody will move along with platforms.
    /// </summary>
    public interface IPlatformable {
        /// <summary>
        /// If true, move the object with the platform, otherwise do not!
        /// </summary>
        public bool IsMoveable { get; }
        /// <summary>
        /// MovementExecution to move along with platforms.
        /// </summary>
        MovementExecution MovementExecution { get; }
    }
}
