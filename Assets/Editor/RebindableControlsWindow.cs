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
    string jumpCurrent = "SPACE";
    string crouchCurrent = "CTRL";
    string fireCurrent = "LEFT CLICK";
    string reloadCurrent = "R";
    string openInventoryCurrent = "TAB";
    string walkForwardNew = "";
    string walkBackwardNew = "";
    string walkLeftNew = "";
    string walkRightNew = "";
    string jumpNew = "";
    string crouchNew = "";
    string fireNew = "";
    string reloadNew = "";
    string openInventoryNew = "";

    Vector2 scrollPosition;

    [MenuItem("Tools/RebindableControls")]
    public static void ShowRebindableControls(){
        GetWindow<RebindableControlsWindow>("RebindableControlsWindow");
    }
    private bool UpdateBinding(string binding1, string binding2){
        //add input validationm ie is it a valid key. also ignore case
        if(binding1 != binding2){
            Debug.Log("Updating Binding!");
            return true;
        }
        else{
            return false;
        }
        
    }
    private void CreateBody1(string newBind, string currentBind){
        
        //Beginning of horizontal group, containing one row for one keybind
        EditorGUILayout.BeginHorizontal();
        //Editing spacing
        EditorGUIUtility.labelWidth = 1;
            //Beginning of vertical group, allowing vertical stacking within horizontal groups. This way I can have a title above the interactable bit
            //This group covers the "New" row which lets the user edit the keybind
            EditorGUILayout.BeginVertical();
                //Title for this vertical group
                EditorGUILayout.LabelField("New", EditorStyles.boldLabel, GUILayout.ExpandWidth(false));
                 
    }
        private void CreateBody2(string newBind, string currentBind){
            //End of current vertical group    
            EditorGUILayout.EndVertical();
            //Beginning of new vertical group, this one contains the button that chacks if the user's input was valid
            EditorGUILayout.BeginVertical();
                //Title for vertical group
                EditorGUILayout.LabelField("Update Binding", EditorStyles.boldLabel);
                //Button that calls a different method when pressed
    }
        private void CreateBody3(string newBind, string currentBind){
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
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);

        // Title for current Binding and beginning of dropdown menu
        showWalkForward = EditorGUILayout.Foldout(showWalkForward, "Walk Forward");
        // bool deciding if we are showing the dropdown or not
        if(showWalkForward){
            //Method handling part of the creation of the body of this menu
            //for some reason this stuff does not like being within a method, so i have it broken uop like this to minimalize copypasta
            CreateBody1(walkForwardNew, walkForwardCurrent);
            //Actual content, editable text box to allow controls to be changed in the editor
            walkForwardNew = GUILayout.TextField(walkForwardNew, 10);
            CreateBody2(walkForwardNew, walkForwardCurrent);
                if(GUILayout.Button("Update", GUILayout.ExpandWidth(false))){
                    //this method will compare and see if the users input was valid, and if so it will update the binding.
                    if(UpdateBinding(walkForwardCurrent, walkForwardNew)){
                        walkForwardCurrent = walkForwardNew.ToUpper();
                        walkForwardNew = "";
                    }
                }
            CreateBody3(walkForwardNew, walkForwardCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showWalkBackward = EditorGUILayout.Foldout(showWalkBackward, "Walk Backward");
        if(showWalkBackward){
            CreateBody1(walkBackwardNew, walkBackwardCurrent);
            walkBackwardNew = GUILayout.TextField(walkBackwardNew, 10);
            CreateBody2(walkBackwardNew, walkBackwardCurrent);
                if(GUILayout.Button("Update", GUILayout.ExpandWidth(false))){
                    //this method will compare and see if the users input was valid, and if so it will update the binding.
                    if(UpdateBinding(walkBackwardCurrent, walkBackwardNew)){
                        walkBackwardCurrent = walkBackwardNew.ToUpper();
                        walkBackwardNew = "";
                    }
                }
            CreateBody3(walkBackwardNew, walkBackwardCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showWalkLeft = EditorGUILayout.Foldout(showWalkLeft, "Walk Left");
        if(showWalkLeft){
            CreateBody1(walkLeftNew, walkLeftCurrent);
            walkLeftNew = GUILayout.TextField(walkLeftNew, 10);
            CreateBody2(walkLeftNew, walkLeftCurrent);
                if(GUILayout.Button("Update", GUILayout.ExpandWidth(false))){
                    //this method will compare and see if the users input was valid, and if so it will update the binding.
                    if(UpdateBinding(walkLeftCurrent, walkLeftNew)){
                        walkLeftCurrent = walkLeftNew.ToUpper();
                        walkLeftNew = "";
                    }
                }
            CreateBody3(walkLeftNew, walkLeftCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showWalkRight = EditorGUILayout.Foldout(showWalkRight, "Walk Right");
        if(showWalkRight){
            CreateBody1(walkRightNew, walkRightCurrent);
            walkRightNew = GUILayout.TextField(walkRightNew, 10);
            CreateBody2(walkRightNew, walkRightCurrent);
                if(GUILayout.Button("Update", GUILayout.ExpandWidth(false))){
                    //this method will compare and see if the users input was valid, and if so it will update the binding.
                    if(UpdateBinding(walkRightCurrent, walkRightNew)){
                        walkRightCurrent = walkRightNew.ToUpper();
                        walkRightNew = "";
                    }
                }
            CreateBody3(walkRightNew, walkRightCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showJump = EditorGUILayout.Foldout(showJump, "Jump");
        if(showJump){
            CreateBody1(jumpNew, jumpCurrent);
            jumpNew = GUILayout.TextField(jumpNew, 10);
            CreateBody2(jumpNew, jumpCurrent);
                if(GUILayout.Button("Update", GUILayout.ExpandWidth(false))){
                    //this method will compare and see if the users input was valid, and if so it will update the binding.
                    if(UpdateBinding(jumpCurrent, jumpNew)){
                        jumpCurrent = jumpNew.ToUpper();
                        jumpNew = "";
                    }
                }
            CreateBody3(jumpNew, jumpCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showCrouch = EditorGUILayout.Foldout(showCrouch, "Crouch");
        if(showCrouch){
            CreateBody1(crouchNew, crouchCurrent);
            crouchNew = GUILayout.TextField(crouchNew, 10);
            CreateBody2(crouchNew, crouchCurrent);
                if(GUILayout.Button("Update", GUILayout.ExpandWidth(false))){
                    //this method will compare and see if the users input was valid, and if so it will update the binding.
                    if(UpdateBinding(crouchCurrent, crouchNew)){
                        crouchCurrent = crouchNew.ToUpper();
                        crouchNew = "";
                    }
                }
            CreateBody3(crouchNew, crouchCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showReload = EditorGUILayout.Foldout(showReload, "Reload");
        if(showReload){
            CreateBody1(reloadNew, reloadCurrent);
            reloadNew = GUILayout.TextField(reloadNew, 10);
            CreateBody2(reloadNew, reloadCurrent);
                if(GUILayout.Button("Update", GUILayout.ExpandWidth(false))){
                    //this method will compare and see if the users input was valid, and if so it will update the binding.
                    if(UpdateBinding(reloadCurrent, reloadNew)){
                        reloadCurrent = reloadNew.ToUpper();
                        reloadNew = "";
                    }
                }
            CreateBody3(reloadNew, reloadCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showFire = EditorGUILayout.Foldout(showFire, "Fire");
        if(showFire){
            CreateBody1(fireNew, fireCurrent);
            fireNew = GUILayout.TextField(fireNew, 10);
            CreateBody2(fireNew, fireCurrent);
                if(GUILayout.Button("Update", GUILayout.ExpandWidth(false))){
                    //this method will compare and see if the users input was valid, and if so it will update the binding.
                    if(UpdateBinding(fireCurrent, fireNew)){
                        fireCurrent = fireNew.ToUpper();
                        fireNew = "";
                    }
                }
            CreateBody3(fireNew, fireCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        showOpenInventory = EditorGUILayout.Foldout(showOpenInventory, "Open Inventory");
        if(showOpenInventory){
            CreateBody1(openInventoryNew, openInventoryCurrent);
            openInventoryNew = GUILayout.TextField(openInventoryNew, 10);
            CreateBody2(openInventoryNew, openInventoryCurrent);
                if(GUILayout.Button("Update", GUILayout.ExpandWidth(false))){
                    //this method will compare and see if the users input was valid, and if so it will update the binding.
                    if(UpdateBinding(openInventoryCurrent, openInventoryNew)){
                        openInventoryCurrent = openInventoryNew.ToUpper();
                        openInventoryNew = "";
                    }
                }
            CreateBody3(openInventoryNew, openInventoryCurrent);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        GUILayout.EndScrollView();
    }

}
