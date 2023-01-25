using UnityEngine;

public class GetAdsId : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;
    private Vector3 velocity;
     private void Start()
    {
        string adsid = GetAndroidAdvertiserId();

        if (!string.IsNullOrEmpty(adsid))
        {
            //if user have a ads id
        }else {
          //if user don't have a ids id
        }

        
    }
    
    public static string GetAndroidAdvertiserId()
    {
        string advertisingID = "";
        try
        {
            AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass client = new AndroidJavaClass("com.google.android.gms.ads.identifier.AdvertisingIdClient");
            AndroidJavaObject adInfo = client.CallStatic<AndroidJavaObject>("getAdvertisingIdInfo", currentActivity);

            advertisingID = adInfo.Call<string>("getId").ToString();
        }
        catch (Exception)
        {
        }
        return advertisingID;
    }
}
