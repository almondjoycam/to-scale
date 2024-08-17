using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISelector : MonoBehaviour
{
    private TextMeshProUGUI selectedText;
    private int selectedIndex = 0;
    private Animator labelAnimator;

    [SerializeField]
    private List<string> options = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        Transform label = transform.Find("Label");
        selectedText = label.GetComponent<TextMeshProUGUI>();
        labelAnimator = label.GetComponent<Animator>();
        UpdateText();

        transform.Find(
            "Left Arrow"
        ).GetComponent<Button>().onClick.AddListener(LeftArrow);
        transform.Find(
            "Right Arrow"
        ).GetComponent<Button>().onClick.AddListener(RightArrow);
    }

    void LeftArrow()
    {
        selectedIndex = (selectedIndex + options.Count - 1) % options.Count;
        labelAnimator.SetTrigger("Left");
        UpdateText();
    }

    void RightArrow()
    {
        selectedIndex = (selectedIndex + 1) % options.Count;
        labelAnimator.SetTrigger("Right");
        UpdateText();
    }

    void UpdateText()
    {
        selectedText.text = options[selectedIndex];
    }

    public string GetValue()
    {
        return options[selectedIndex];
    }
}
