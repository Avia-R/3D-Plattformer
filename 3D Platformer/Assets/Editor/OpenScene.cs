using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class OpenScene : MonoBehaviour
{
    [MenuItem("OpenScene/Main Scene %M")]
  static void StartScreen()
  {
      EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
      EditorSceneManager.OpenScene("Assets/Scenes/Main.unity");
  }


}
