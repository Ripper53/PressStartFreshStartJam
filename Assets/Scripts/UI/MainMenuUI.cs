using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.UI;

public class MainMenuUI : MonoBehaviour {
    public PlayerMovementCharacterControls PlayerMovementCharacterControls;
    public PlayerJumpCharacterControls PlayerJumpCharacterControls;
    public PlayerCharacterWhipActionControls PlayerCharacterWhipActionControls;

    public CanvasGroup CanvasGroup;
    public AnimationUI[] OnAnimationUIs;
    public AnimationUI[] OffAnimationUIs;

    public void Begin() {
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
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
