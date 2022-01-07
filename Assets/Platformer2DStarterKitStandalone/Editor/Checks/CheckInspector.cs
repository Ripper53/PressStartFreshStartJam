using UnityEditor;

namespace Platformer2DStarterKit.UnityEditor {
    [CustomEditor(typeof(Check), true)]
    public class CheckInspector : Editor {

        public override void OnInspectorGUI() {
            Check check = (Check)target;
            if (check is LayerCheck layerCheck && layerCheck.LayerMask.value == 0)
                EditorGUILayout.HelpBox("LayerMask is set to detect nothing.", MessageType.Info);

            if (check.ShapeParameter && check.ShapeParameter.Transform)
                EditorGUILayout.LabelField("Evaluation: " + check.Evaluate());
            else
                EditorGUILayout.HelpBox("Shape Parameter field or its Transform is not set!", MessageType.Info);

            base.OnInspectorGUI();
        }

    }
}
