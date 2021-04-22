using UnityEngine;

public class CameraClamp : MonoBehaviour {
    public Transform Transform;
    public Vector2 Min, Max;

    private void LateUpdate() {
        Vector3 pos = Transform.position;

        if (pos.x < Min.x)
            pos.x = Min.x;
        else if (pos.x > Max.x)
            pos.x = Max.x;

        if (pos.y < Min.y)
            pos.y = Min.y;
        else if (pos.y > Max.y)
            pos.y = Max.y;

        Transform.position = pos;
    }

}
