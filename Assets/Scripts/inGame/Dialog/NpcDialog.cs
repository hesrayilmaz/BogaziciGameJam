using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class NpcDialog : MonoBehaviour,IA_Interactable
{
    [SerializeField] private DialogTextSO dialogSO;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Image interactImage;
    [SerializeField]private bool facingright=true;
    public bool isLocked=false;
    private Transform player;
    private float interactDistance = 2f;
    private bool isDialogEnded = false;
    private bool isTyping = false;
    private const string HTML_ALPHA = "<color=#00000000>";

    private float typeSpeed = 10f;
    private const float MAX_TYPE_TIME = 0.1f;

    private List<string> paragraphs = new List<string>();
    private int paragraphIndex = 0;

    private Coroutine typeDialogCoroutine;

    void Start()
    {
        
        foreach (string paragraph in dialogSO.dialogParagraphs)
        {
            paragraphs.Add(paragraph);
        }

        
    }

    private void Update()
    {
        if (player==null)
        {
            Debug.Log(GameManager.Instance?.PlayerRef.transform);
           player= GameManager.Instance?.PlayerRef.transform;
           return;
        }
        if (IsWithinDialogRange())
        {
            interactImage.gameObject.SetActive(true);
            
            if(transform.position.x-player.position.x>0&&facingright||transform.position.x-player.position.x<0&&facingright==false)
            Flip();



            if (Input.GetKeyDown(KeyCode.Return) && !isDialogEnded)
            {
                if (!isTyping && (paragraphIndex < paragraphs.Count - 1))
                    NextDialog();
                else if (isTyping)
                    FinishParagraphEarly();
                else
                    EndDialog();
            }

        }
        else
        {
            interactImage.gameObject.SetActive(false);
        }

    }
    void Flip()
    {
        GetComponent<SpriteRenderer>().flipX=facingright;
        facingright=!facingright;
    }

    private bool IsWithinDialogRange()
    {
        if (Vector2.Distance(player.position, transform.position) < interactDistance)
            return true;
        else
            return false;
    }

    private void StartDialog()
    {
         CameraMovement.Instance.zoomActive=true;
        isDialogEnded = false;
        dialogPanel.SetActive(true);
        paragraphIndex = 0;
        dialogText.text = paragraphs[paragraphIndex];
    }

    private void NextDialog()
    {
        paragraphIndex++;
        typeDialogCoroutine = StartCoroutine(TypeDialog(paragraphs[paragraphIndex]));
    }

    private void EndDialog()
    {
         CameraMovement.Instance.zoomActive=false;
        isDialogEnded = true;
        dialogPanel.SetActive(false);
        dialogText.text = "";

    }

    private IEnumerator TypeDialog(string dialog)
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
            AudioManager.Instance.PlaySFX("chef");
            yield return new WaitForSeconds(MAX_TYPE_TIME/typeSpeed);
        }
        isTyping = false;
    }

    private void FinishParagraphEarly()
    {
        StopCoroutine(typeDialogCoroutine);
        dialogText.text = paragraphs[paragraphIndex];
        isTyping = false;
    }

    public void Interact()
    {
       if(isLocked==false)
       StartDialog();
    }
}
