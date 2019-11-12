#if (UNITY_EDITOR) 

using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Action))]
public class ActionEditor : Editor {
    public string[] choices = new [] { "Project", "AboutMe" };
    public int choiceIndex = 0;

    private string ActualChoice = "";
    private int _ActualChoice = 0;
 
    new Action target;
     void OnEnable(){
        target = (Action)base.target;
     }

   public override void OnInspectorGUI ()
   {

     _ActualChoice = target.GetComponent<Sign>().content;

     switch (_ActualChoice){
         
      case 0: 
          ActualChoice = "Project";
          break;
      case 1:
          ActualChoice = "AboutMe";
          break;

        default:
          break;
     }

    DrawDefaultInspector();
    EditorGUILayout.LabelField("Actual renderer:", ActualChoice);
    choiceIndex = EditorGUILayout.Popup(choiceIndex, choices);
    

    if(GUILayout.Button("Valid")){
      target.GetComponent<Sign>().content = choiceIndex;
    }
  
   }

            
        
}

#endif