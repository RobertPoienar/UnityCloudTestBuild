using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AltCopyTextOnClick : MonoBehaviour, IPointerClickHandler
{
    public Text Text;

    public void OnPointerClick(PointerEventData eventData)
    {
        AltConsoleLogViewer.Instance.ShowClipboardNotification(AltConsoleLogViewer.GetMousePosition());

#if UNITY_WEBGL && !UNITY_EDITOR
    AltConsoleLogViewer.Instance.Copy(Regex.Replace(Text.text, "<.*?>", string.Empty));
#else
        GUIUtility.systemCopyBuffer = Regex.Replace(Text.text, "<.*?>", string.Empty);
#endif
    }
}
