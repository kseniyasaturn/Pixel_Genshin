using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitConfirmation : MonoBehaviour
{
    [SerializeField] GameObject confirmationPanel;
    public void OnExitButtonClick()
    {
        confirmationPanel.SetActive(true);
    }

    public void OnYesButtonClick()
    {
        Application.Quit();
        // ���� ���� � ���������:
        //#if UNITY_EDITOR
        //UnityEditor.EditorApplication.isPlaying = false;
        //#endif
    }

    public void OnNoButtonClick()
    {
        confirmationPanel.SetActive(false);
    }
}
