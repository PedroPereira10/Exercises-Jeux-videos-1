using UnityEngine;

public class CustumerManager : MonoBehaviour
{
    [SerializeField] private CustomerClient _custumerInfo;
    [SerializeField] private Transform _customerListParent;

    public void CreateNewCustumer (string custumerName)
    {
        CustomerClient custumerInfo = Instantiate (_custumerInfo, _customerListParent);
        custumerInfo.transform.SetAsFirstSibling ();
        custumerInfo.UpdateCustumerInfo(custumerName);
    }
}
