using static System.Net.Mime.MediaTypeNames;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class TextButton : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public Camera camera;

    public string LastClickedWord;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var findStatus = TMPro.TMP_TextUtilities.FindIntersectingLine(text, Input.mousePosition, camera);
            if (findStatus != -1)
            {
                Debug.Log("Exit Game");
                UnityEngine.Application.Quit();
            }
            
        }
    }
}