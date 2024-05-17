using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum NpcType
{
    Chef,
    Gardener,
    Servant,
    Guard
}

public class NpcDialog : MonoBehaviour
{
    [SerializeField] private NpcType npcType;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Image interactImage;
    private Transform player;
    private float interactDistance = 2f;
    private bool isDialogActive = false;
    private bool isTyping = false;
    private const string HTML_ALPHA = "<color=#00000000>";

    private float typeSpeed = 10f;
    private const float MAX_TYPE_TIME = 0.1f;

    private Dictionary<string, string[]> dialogs = new Dictionary<string, string[]>()
    {
        { "Chef", new string[] { "Hello", "I am the chef. fkksdlgkdþlgkdslþklþdlþ"} },
        { "Gardener", new string[] { "Hello" , "I am the gardener"} },
        { "Servant", new string[] { "Hello", "I am the servant"} },
        { "Guard", new string[] { "Hello", "I am the guard"} }
    };

    private int dialogIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartDialog();
        //for (int i = 0; i < dialogs[npcType.ToString()].Length; i++)
        //{
        //    dialogText.text = dialogs[npcType.ToString()][dialogIndex];
        //    Debug.Log(dialogs[npcType.ToString()][i]);
        //}
    }

    private void Update()
    {
        if (IsWithinDialogRange())
        {
            interactImage.gameObject.SetActive(true);
            
            if(Input.GetKeyDown(KeyCode.E))
            {
                interactImage.gameObject.SetActive(false);
                StartDialog();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextDialog();
        }

    }

    private bool IsWithinDialogRange()
    {
        if (Vector2.Distance(player.position, transform.position) < interactDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void StartDialog()
    {
        isDialogActive = true;
        dialogPanel.SetActive(true);
        dialogIndex = 0;
        dialogText.text = dialogs[npcType.ToString()][dialogIndex];
    }

    private void NextDialog()
    {
        dialogIndex++;
        if (isDialogActive)
        {
            if(!isTyping)
            {
                StartCoroutine(TypeDialogCoroutine(dialogs[npcType.ToString()][dialogIndex]));
            }
            else
            {
                FinishParagraphEarly();
            }
        }
        else if(!isDialogActive && !isTyping)
        {
            EndDialog();
        }
    }

    private void EndDialog()
    {
        isDialogActive = false;
        dialogPanel.SetActive(false);
        dialogText.text = "";
    }

    private IEnumerator TypeDialogCoroutine(string dialog)
    {
        isTyping = true;
        dialogText.text = "";

        string originalText = dialog;
        string displayedText = "";
        int alphaIndex = 0;

        foreach (char letter in dialog.ToCharArray())
        {
            alphaIndex++;
            dialogText.text = originalText;

            displayedText = dialogText.text.Insert(alphaIndex, HTML_ALPHA);
            dialogText.text = displayedText;
            yield return new WaitForSeconds(MAX_TYPE_TIME/typeSpeed);
        }
        isTyping = false;
    }

    private void FinishParagraphEarly()
    {
        StopCoroutine(TypeDialogCoroutine(""));
        dialogText.text = dialogs[npcType.ToString()][dialogIndex];
        isTyping = false;
    }
}
