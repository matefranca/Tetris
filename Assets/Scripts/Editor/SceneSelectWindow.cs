using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;


public class SceneSelectWindow : MonoBehaviour
{
    [MenuItem("Tetris/Play Game %0")]
    public static void PlayScene()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Menu.unity");
        EditorApplication.isPlaying = true;
    }

    [MenuItem("Tetris/Scenes/Menu Scene %1")]
    public static void OpenMenuScene()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Menu.unity");
    }

    [MenuItem("Tetris/Scenes/Single Player Scene %1")]
    public static void Open1PScene()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Game1P.unity");
    }
}