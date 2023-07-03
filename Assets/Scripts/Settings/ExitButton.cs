using UnityEngine;
using UnityEngine.UI;

public class ClickExample : MonoBehaviour
{
    public Button button;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("going to main menu");
        CutsceneManager.Instance.StartCutscene("to_main_menu");
    }
}