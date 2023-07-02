using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public Camera camera;

    public string LastClickedWord;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var wordIndex = TMPro.TMP_TextUtilities.FindIntersectingLine(text, Input.mousePosition, camera);

            Debug.Log("Go to settings");
            UnityEngine.Application.Quit();
            CutsceneManager.Instance.StartCutscene("to_settings");
        }
    }
}
