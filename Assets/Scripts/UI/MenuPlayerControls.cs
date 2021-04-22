using Platformer2DStarterKit;

public class MenuPlayerControls : PlayerControls<PlayerActionControls> {
    public SettingsMenuUI Menu;

    protected override void AddListener(PlayerActionControls input) {
        input.Interface.Pause.performed += Pause_performed;
    }

    protected override void RemoveListener(PlayerActionControls input) {
        input.Interface.Pause.performed -= Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        Menu.Toggle();
    }

}
