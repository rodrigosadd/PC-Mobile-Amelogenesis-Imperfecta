using Scriptable_Objects.Channels;
using UnityEngine;
using TMPro;

namespace Character
{
    public class Tooltip : MonoBehaviour
    {
        [SerializeField] private StringEventChannelSO _showTooltipStringEventChannel;
        [SerializeField] private VoidEventChannelSO _hideTooltipVoidEventChannel;
        [SerializeField] private TransformEventChannelSO _setPositionTransformEventChannel;
        [SerializeField] private GameObject _tooltipHolder;
        [SerializeField] private TMP_Text _tooltipText;
        [SerializeField] private Vector3 _offsetPosition;

        private void OnEnable()
        {
            _showTooltipStringEventChannel.OnStringRequested += ShowTooltip;
            _hideTooltipVoidEventChannel.OnVoidRequested += HideTooltip;
            _setPositionTransformEventChannel.OnTransformRequested += SetObjectPosition;
        }

        private void OnDisable()
        {
            _showTooltipStringEventChannel.OnStringRequested -= ShowTooltip;
            _hideTooltipVoidEventChannel.OnVoidRequested -= HideTooltip;
            _setPositionTransformEventChannel.OnTransformRequested -= SetObjectPosition;
        }

        private void ShowTooltip(string tooltipString)
        {
            _tooltipHolder.SetActive(true);

            _tooltipText.text = tooltipString;
        }
        
        private void HideTooltip()
        {
            _tooltipHolder.SetActive(false);
        }

        private void SetObjectPosition(Transform position)
        {
            transform.position = new Vector3(position.position.x + _offsetPosition.x, position.position.y + _offsetPosition.y, position.position.z + _offsetPosition.z);
        }
    }
}