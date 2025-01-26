using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject UIPanel;
    public GameObject PausePanel;
    public GameObject createPanel;
    public GameObject joinPanel;

    public bool isMenu = true;
    public bool isPause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isMenu)
        {
            isPause = !isPause;
            PausePanel.SetActive(isPause);

            if (isPause)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
            }
        }
    }

    public void CreateButton()
    {
        if (createPanel.activeSelf == true)
        {
            createPanel.SetActive(false);
        }
        else
        {
            createPanel.SetActive(true);
        }

        joinPanel.SetActive(false);
    }

    public void JoinButton()
    {
        if (joinPanel.activeSelf == true)
        {
            joinPanel.SetActive(false);
        }
        else
        {
            joinPanel.SetActive(true);
        }

        createPanel.SetActive(false);
    }

    public void OnJoinedGame()
    {
        UIPanel.SetActive(false);
        isMenu = false;
    }

    public void PlayerLeft()
    {
        UIPanel.SetActive(true);
        PausePanel.SetActive(false);
        createPanel.SetActive(false);
        joinPanel.SetActive(false);
        isMenu = true;
    }
}
