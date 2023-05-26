using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIMenu : MonoBehaviour
{
    private Button _StartButton;
    private Button _EndButton;
    public VisualElement Mainmenu;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<VisualElement>();

        _StartButton = root.Q<Button>("Startbutton");
        _EndButton = root.Q<Button>("Exitbutton");

        _StartButton.clicked += playButtonCilcked; // ->Using for restart or begin the game
        _EndButton.clicked += endButtonCilcked; // -> Using for end the game
    }

    private void playButtonCilcked()
    {
        SceneManager.LoadScene("Testing Lab Run");
    }

    private void endButtonCilcked()
    {
        Application.Quit();
        Debug.Log("Closing the game");
    }
}
