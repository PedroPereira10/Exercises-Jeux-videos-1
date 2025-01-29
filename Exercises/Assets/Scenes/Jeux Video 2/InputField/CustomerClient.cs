using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomerClient : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _image;
    
    public void UpdateCustumerInfo(string custumerName)
    {
        _text.text = custumerName;
        _image.color = Random.ColorHSV(0f, 1f);
    }

    public void DeleteCustomer()
    {
        Destroy(gameObject);
    }
}
