using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _loadingScreen;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var findStatus = TMPro.TMP_TextUtilities.FindIntersectingLine(text, Input.mousePosition, _camera);
            if (findStatus != -1)
            {
                _loadingScreen.SetActive(true);

                Debug.Log("Start Vpiska Scene");

                StartCoroutine(LoadAsync());
            }
        }
    }

    IEnumerator LoadAsync()
    {
        yield return new WaitForSecondsRealtime(1);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
