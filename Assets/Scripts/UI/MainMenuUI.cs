using UnityEngine;
using UnityEngine.UI;
using Platformer2DStarterKit;
using Platformer2DStarterKit.UI;

public class MainMenuUI : MonoBehaviour {
    public PlayerMovementCharacterControls PlayerMovementCharacterControls;
    public PlayerJumpCharacterControls PlayerJumpCharacterControls;
    public PlayerCharacterWhipActionControls PlayerCharacterWhipActionControls;

    public Selectable[] Selectables;
    public AnimationUI[] OnAnimationUIs;
    public AnimationUI[] OffAnimationUIs;

    public void Begin() {
        foreach (Selectable selectable in Selectables)
            selectable.enabled = false;
        foreach (AnimationUI ui in OnAnimationUIs)
            ui.enabled = true;
        foreach (AnimationUI ui in OffAnimationUIs)
            ui.enabled = true;
        PlayerMovementCharacterControls.enabled = true;
        PlayerJumpCharacterControls.enabled = true;
        PlayerCharacterWhipActionControls.enabled = true;
    }

    public void Quit() {
        Application.Quit();
    }

}
