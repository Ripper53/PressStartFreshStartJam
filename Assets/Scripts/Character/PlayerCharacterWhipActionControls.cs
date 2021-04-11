using Platformer2DStarterKit;

public class PlayerCharacterWhipActionControls : PlayerControls<PlayerActionControls> {
    public CharacterWhip CharacterWhip;

    protected override void AddListener(PlayerActionControls input) {
        input.Action.Whip.performed += Whip_performed;
    }

    protected override void RemoveListener(PlayerActionControls input) {
        input.Action.Whip.performed -= Whip_performed;
    }

    private void Whip_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        CharacterWhip.WhipRequest = true;
    }

}
