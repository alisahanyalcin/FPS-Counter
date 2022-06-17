using UnityEngine;
using UnityEditor;

namespace alisahanyalcin
{
    
    public class FPSCounterCreator : EditorWindow
    {
        public Color textColor = Color.white;
        public float updateInterval = 0.5f;
        public new string name = "FPS Counter";
        public FPSCounterPosition fpsPosition = FPSCounterPosition.BottomLeft;
        
        [MenuItem("Tools/FPS Counter Creator")]
        private static void CreateFolderList() => GetWindow<FPSCounterCreator>("FPS Counter Creator");
        
        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            GUILayout.Space(5);
            
            name = EditorGUILayout.TextField("Name", name);
            GUILayout.Space(5);
            
            textColor = EditorGUILayout.ColorField("Text Color", textColor);
            GUILayout.Space(5);
            
            updateInterval = EditorGUILayout.FloatField("Update Interval", updateInterval);
            GUILayout.Space(5);
            
            fpsPosition = (FPSCounterPosition) EditorGUILayout.EnumPopup("Position", fpsPosition);
            GUILayout.Space(10);
            
            if (GUILayout.Button("Create Counter"))
                CounterCreator();
            
            GUILayout.Space(5);
            EditorGUILayout.EndVertical();
        }

        private void CounterCreator()
        {
            GameObject temp = new GameObject(name, typeof(FPSCounter));

            if (!temp) return;
            temp.GetComponent<FPSCounter>().textColor = textColor;
            temp.GetComponent<FPSCounter>().updateInterval = updateInterval;
            temp.GetComponent<FPSCounter>().fpsPosition = fpsPosition;
            Selection.activeGameObject = temp.gameObject;
        }
    }
}