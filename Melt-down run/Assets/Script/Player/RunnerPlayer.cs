using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class RunnerPlayer : MonoBehaviour
{
    [SerializeField]
    float Jump;
    private Rigidbody2D rb2D;

    [SerializeField]
    private bool isGrounded;


    public UIMenu _menu;

    private void Awake()
    {
        rb2D= GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2D.AddForce(Vector2.up * Jump);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            ShowPanel(_menu.Mainmenu);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

        }
    }

    private void OnTriggerEnter2D(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void HidePanel(VisualElement panelToHide)
    {
        panelToHide.style.display = DisplayStyle.None;
        panelToHide.style.visibility = Visibility.Hidden;
    }
    public void ShowPanel(VisualElement panelToShow)
    {
        panelToShow.style.display = DisplayStyle.Flex;
        panelToShow.style.visibility = Visibility.Visible;
    }
}
