using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    private int currentlyChanging = -1;
    public Text[] hotkeysText;
    private void Update()
    {
        if (currentlyChanging >= 0)
        {
            string changeTo = updateHotkey();
            if (changeTo != null)
            {
                hotkeysText[currentlyChanging].text = changeTo;
                EventSystem.current.SetSelectedGameObject(null);
                currentlyChanging = -1;
            }
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                currentlyChanging = -1;
            }
        }
    }
    private string[] keys = new string[] { "ChangePivot", "UseAbility" };
    private string updateHotkey()
    {
        string entered = Input.inputString.ToUpper();
        string pressed = entered;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { pressed = "LeftArrow"; }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { pressed = "RightArrow"; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { pressed = "DownArrow"; }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { pressed = "UpArrow"; }
        if (Input.GetKeyDown(KeyCode.Space)) { pressed = "Space"; }

        if (pressed != "" & pressed != "\n" & pressed != "\r" & pressed != "\b")
        {
            PlayerPrefs.SetString(keys[currentlyChanging], pressed);
            return pressed;
        }
        return null;
    }
    public void changeHotkey(int ind)
    {
        currentlyChanging = ind;
    }
    public Animator transition;
    private float transitionPeriod = 0.5f;
    public void Back()
    {
        StartCoroutine(GoScene(0));
    }
    private IEnumerator GoScene(int sceneIndex)
    {
        transition.SetTrigger("StartTrans");
        yield return new WaitForSeconds(transitionPeriod);
        SceneManager.LoadScene(sceneIndex);
    }
    private string[] defaultKeys = new string[] { "X", "Z" };
    void Start()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            hotkeysText[i].text = PlayerPrefs.GetString(keys[i], defaultKeys[i]);
        }
    }
}
