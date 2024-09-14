using TMPro;
using UnityEngine;

public class ChatBubbleUI : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private TextMeshProUGUI contentTxt;

    public void SetContent(string content)
    {
        contentTxt.text = content;
    }
}