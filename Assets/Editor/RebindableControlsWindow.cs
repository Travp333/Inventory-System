using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RebindableControlsWindow : EditorWindow
{
    bool showWalkForward = false;
    bool showWalkBackward = false;
    bool showWalkLeft = false;
    bool showWalkRight = false;
    bool showJump = false;
    bool showCrouch = false;
    bool showFire = false;
    bool showReload = false;
    bool showOpenInventory = false;
    string walkForwardCurrent = "W";
    string walkBackwardCurrent = "S";
    string walkLeftCurrent = "A";
    string walkRightCurrent = "D";
    string jumpCurrent = "Space";
    string crouchCurrent = "Ctrl";
    string fireCurrent = "Left Click";
    string reloadCurrent = "R";
    string openInventoryCurrent = "Tab";
    string walkForwardNew = "null";
    string walkBackwardNew = "null";
    string walkLeftNew = "null";
    string walkRightNew = "null";
    string jumpNew = "null";
    string crouchNew = "null";
    string fireNew = "null";
    string reloadNew = "null";
    string openInventoryNew = "null";

    [MenuItem("Tools/RebindableControls")]
    public static void ShowRebindableControls(){
        GetWindow<RebindableControlsWindow>("RebindableControlsWindow");
    }
    //MAKE THIS A BOOL METHOD THAT DOES INPUT VALIDATION AND RETURNS TRUE OR FALSE
    private void UpdateBinding(string binding1, string binding2){
        //add input validation
        Debug.Log("Setting " + binding1 + " to " + binding2);
        binding1 = binding2;
    }
    //THIS IS BUGGED!!!!!
    //Cant do it in a method like this for some reason, need to copy+paste
    private void CreateBody(string newBind, string currentBind){
        //Beginning of horizontal group, containing one row for one keybind
        EditorGUILayout.BeginHorizontal();
        //Editing spacing
        EditorGUIUtility.labelWidth = 1;
            //Beginning of vertical group, allowing vertical stacking within horizontal groups. This way I can have a title above the interactable bit
            //This group covers the "New" row which lets the user edit the keybind
            EditorGUILayout.BeginVertical();
                //Title for this vertical group
                EditorGUILayout.LabelField("New", EditorStyles.boldLabel, GUILayout.ExpandWidth(false));
                //Actual content, editable text box to allow controls to be changed in the editor 
                newBind = GUILayout.TextField(newBind, 10, GUILayout.ExpandWidth(false));
            //End of current vertical group    
            EditorGUILayout.EndVertical();
            //Beginning of new vertical group, this one contains the button that chacks if the user's input was valid
            EditorGUILayout.BeginVertical();
                //Title for vertical group
                EditorGUILayout.LabelField("Update Binding", EditorStyles.boldLabel);
                //Button that calls a different method when pressed
                if(GUILayout.Button("Update", GUILayout.ExpandWidth(false))){
                    //this method will compare and see if the users input was valid, and if so it will update the binding.
                    UpdateBinding(currentBind, newBind);
                }
            //end of the vertical group
            EditorGUILayout.EndVertical();
            //beginning of another vertical group
            EditorGUILayout.BeginVertical();
                //Title for vertical group
                EditorGUILayout.LabelField("Current", EditorStyles.boldLabel);
                //box simply displaying the current active keybind
                GUILayout.Box(currentBind);
            //end of vertical group
            EditorGUILayout.EndVertical();
        // end of horizontal group
        EditorGUILayout.EndHorizontal();
    }

    void OnGUI()
    {
        
        //Title 
        GUILayout.Label("Rebindable Controls", EditorStyles.boldLabel);
        // Title for current Binding and beginning of dropdown menu
        showWalkForward = EditorGUILayout.Foldout(showWalkForward, "Walk Forward");
        // bool deciding if we are showing the dropdown or not
        if(showWalkForward){
            //Method handling the creation of the body of this menu
            CreateBody(walkForwardNew, walkForwardCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showWalkBackward = EditorGUILayout.Foldout(showWalkBackward, "Walk Backward");
        if(showWalkBackward){
            //Beginning of horizontal group, containing one row for one keybind
            EditorGUILayout.BeginHorizontal();
            //Editing spacing
            EditorGUIUtility.labelWidth = 1;
                //Beginning of vertical group, allowing vertical stacking within horizontal groups. This way I can have a title above the interactable bit
                //This group covers the "New" row which lets the user edit the keybind
                EditorGUILayout.BeginVertical();
                    //Title for this vertical group
                    EditorGUILayout.LabelField("New", EditorStyles.boldLabel, GUILayout.ExpandWidth(false));
                    //Actual content, editable text box to allow controls to be changed in the editor 
                    walkBackwardNew = GUILayout.TextField(walkBackwardNew, 10, GUILayout.ExpandWidth(false));
                //End of current vertical group    
                EditorGUILayout.EndVertical();
                //Beginning of new vertical group, this one contains the button that chacks if the user's input was valid
                EditorGUILayout.BeginVertical();
                    //Title for vertical group
                    EditorGUILayout.LabelField("Update Binding", EditorStyles.boldLabel);
                    //Button that calls a different method when pressed
                    if(GUILayout.Button("Update", GUILayout.ExpandWidth(false))){
                        //this method will compare and see if the users input was valid, and if so it will update the binding.
                        walkBackwardCurrent = walkBackwardNew;
                    }
                //end of the vertical group
                EditorGUILayout.EndVertical();
                //beginning of another vertical group
                EditorGUILayout.BeginVertical();
                    //Title for vertical group
                    EditorGUILayout.LabelField("Current", EditorStyles.boldLabel);
                    //box simply displaying the current active keybind
                    GUILayout.Box(walkBackwardCurrent);
                //end of vertical group
                EditorGUILayout.EndVertical();
            // end of horizontal group
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showWalkLeft = EditorGUILayout.Foldout(showWalkLeft, "Walk Left");
        if(showWalkLeft){
            CreateBody(walkLeftNew, walkLeftCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showWalkRight = EditorGUILayout.Foldout(showWalkRight, "Walk Right");
        if(showWalkRight){
            CreateBody(walkRightNew, walkRightCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showJump = EditorGUILayout.Foldout(showJump, "Jump");
        if(showJump){
            CreateBody(jumpNew, jumpCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showCrouch = EditorGUILayout.Foldout(showCrouch, "Crouch");
        if(showCrouch){
            CreateBody(crouchNew, crouchCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showReload = EditorGUILayout.Foldout(showReload, "Reload");
        if(showReload){
            CreateBody(reloadNew, reloadCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showFire = EditorGUILayout.Foldout(showFire, "Fire");
        if(showFire){
            CreateBody(fireNew, fireCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
    }

}
