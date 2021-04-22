using Platformer2DStarterKit.Utility;
using UnityEngine;

public class CharacterRespawn : MonoBehaviour {
    public GameObject GameObject;
    public CharacterDeath CharacterDeath;
    public Transform Transform;

    private Vector2 pos;

    private void Awake() {
        pos = Transform.position;
        CharacterDeath.Died += CharacterDeath_Died;
    }

    private void CharacterDeath_Died(CharacterDeath source, CharacterDeadBody deadBody) {
        Transform.position = pos;
        GameObject.SetActive(true);
    }

}
