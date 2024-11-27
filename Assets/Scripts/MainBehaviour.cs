using GoogleMobileAds.Ump.Api;
using UnityEngine;

public class MainBehaviour : MonoBehaviour
{
    void Start()
    {
        ConsentRequestParameters request = new();
        ConsentInformation.Update(request, OnConsentInfoUpdated);
    }

    void OnConsentInfoUpdated(FormError consentError)
    {
        if (consentError != null)
        {
            Debug.LogError("Consent error: " + consentError.Message);
            return;
        }

        ConsentForm.LoadAndShowConsentFormIfRequired((formError) =>
        {
            if (formError != null)
            {
                Debug.LogError("Consent form error: " + formError.Message);
                return;
            }
        });
    }
}
