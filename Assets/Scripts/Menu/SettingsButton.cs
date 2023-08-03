using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    [SerializeField] private Camera _camera;

    public string LastClickedWord;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var findStatus = TMPro.TMP_TextUtilities.FindIntersectingLine(text, Input.mousePosition, _camera);
            if (findStatus != -1)
            {
                Debug.Log("Go to settings");
                CutsceneManager.Instance.StartCutscene("to_settings");
            }
        }
    }
}
