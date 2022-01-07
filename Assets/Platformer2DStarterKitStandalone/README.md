# Platformer2DStarterKit
 Head-start your game development!

## Getting Started

 #### Set-up
  Make sure the `MovementExecution (Platformer2DStarterKit.MovementExecution)` script is below `Default Time` in `Script Execution Order`.
 
 #### Examples
  Take a look at the `Player Character` prefab for reference, located in the 'Runtime/Platformer2DStarterKit/Prefabs' folder within the package.
 
  Checks are used to detect any colliders within a layer given by the `Shape Parameter`.
  `Get Colliders` gets the colliders within a layer given by the `Shape Parameter`.
 
  So, for example, if you wanted a platform that moves from side to side: add the `Platform Ground` component to the platform, then give it a `Shape Parameter` to know where to detect what colliders are on the platform. `MonoBehaviours` that implement the `IPlatformable` interface will move along with the platform.
 
  In the 'Tests/Runtime/Test1' folder, there is a scene which contains a working platform and player character.
