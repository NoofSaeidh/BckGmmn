using System.Collections;
using System.Collections.Generic;
using BckGmmn.App.Components;
using UnityEditor;
using UnityEngine;

namespace BckGmmn.Editor.Editors
{
    [CustomEditor(typeof(Game))]
    public class GameEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var game = (Game)target;
            EditorGUILayout.LabelField(nameof(game.Turn), game.Turn.ToString());
            EditorGUILayout.LabelField(nameof(game.Winner), game.Winner.ToString());
        }
    }
}
