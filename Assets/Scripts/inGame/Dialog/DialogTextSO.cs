using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NpcType
{
    Chef,
    Gardener,
    Servant,
    Guard
}

[CreateAssetMenu(menuName = "Dialog/New Dialog", fileName = "NewDialogText")]
public class DialogTextSO : ScriptableObject
{
    public NpcType npcType;

    [TextArea(2, 10)]
    public string[] dialogParagraphs;
}
