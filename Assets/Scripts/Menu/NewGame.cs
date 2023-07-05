using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    [SerializeField] private Camera _camera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var findStatus = TMPro.TMP_TextUtilities.FindIntersectingLine(text, Input.mousePosition, _camera);
            if (findStatus != -1)
            {
                Debug.Log("Start Vpiska Scene");
                SceneManager.LoadScene(1);
            }
        }
    }
}
