using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RebindableControlsWindow : EditorWindow
{
    bool showPosition = false;
    string walkForwardCurrent = "W";
    string walkBackwardCurrent = "S";
    string walkLeftCurrent = "A";
    string walkRightCurrent = "D";
    string jumpCurrent = "Space";
    string crouchCurrent = "Ctrl";
    string fireCurrent = "Left Click";
    string reloadCurrent = "R";
    string openInventoryCurrent = "Tab";
    string walkForwardNew = "W";
    string walkBackwardNew = "S";
    string walkLeftNew = "A";
    string walkRightNew = "D";
    string jumpNew = "Space";
    string crouchNew = "Ctrl";
    string fireNew = "Left Click";
    string reloadNew = "R";
    string openInventoryNew = "Tab";

    [MenuItem("Tools/RebindableControls")]
    public static void ShowRebindableControls(){
        GetWindow<RebindableControlsWindow>("RebindableControlsWindow");
    }
    void OnGUI()
    {
        
        //do a "new" and "current" optioin with an update button that updates the current one,, you can do data validation here
        
        GUILayout.Label("Rebindable Controls", EditorStyles.boldLabel);

        showPosition = EditorGUILayout.Foldout(showPosition, "Walk Forward");
        if(showPosition){

            EditorGUILayout.BeginHorizontal();
            //GUILayout.FlexibleSpace();
            EditorGUIUtility.labelWidth = 1;
                EditorGUILayout.BeginVertical();
                    EditorGUILayout.LabelField("New", EditorStyles.boldLabel, GUILayout.ExpandWidth(false));
                    walkForwardNew = GUILayout.TextField(walkForwardNew, 25, GUILayout.ExpandWidth(false));
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical();
                    EditorGUILayout.LabelField("Update Binding", EditorStyles.boldLabel);
                    if(GUILayout.Button("Update", GUILayout.ExpandWidth(false))){
                        //ADD INPUT VALIDATION HERE
                        walkForwardCurrent = walkForwardNew;
                    }
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical();
                    EditorGUILayout.LabelField("Current", EditorStyles.boldLabel);
                    GUILayout.Box(walkForwardCurrent);
                EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        //GUILayout.Space(5);
       // GUILayout.Box("Walk Backward", EditorStyles.boldLabel);
        //walkBackward = GUILayout.TextField(walkBackward, 25);
        //GUILayout.Space(20);
        //GUILayout.Box("Walk Left", EditorStyles.boldLabel);
       // walkLeft = GUILayout.TextField(walkLeft, 25);
        //GUILayout.Space(20);
      //  GUILayout.Box("Walk Right", EditorStyles.boldLabel);
      //  walkRight = GUILayout.TextField(walkRight, 25);
       // GUILayout.Space(20);
     //   GUILayout.Box("Jump", EditorStyles.boldLabel);
      //  jump = GUILayout.TextField(jump, 25);
       // GUILayout.Space(20);
      //  GUILayout.Box("Crouch", EditorStyles.boldLabel);
     //   crouch = GUILayout.TextField(crouch, 25);
       // GUILayout.Space(20);
     //   GUILayout.Box("Fire", EditorStyles.boldLabel);
     //   fire = GUILayout.TextField(fire, 25);
       // GUILayout.Space(20);
     //   GUILayout.Box("Reload", EditorStyles.boldLabel);
     //   reload = GUILayout.TextField(reload, 25);
      //  GUILayout.Space(20);
      //  GUILayout.Box("Open Inventory", EditorStyles.boldLabel);
      //  openInventory = GUILayout.TextField(openInventory, 25);
        
      //  if(GUILayout.Button("Change Binding?")){
      //      Debug.Log("Change binging?");
      //  }
        //GUILayout.EndArea();
    }

}
