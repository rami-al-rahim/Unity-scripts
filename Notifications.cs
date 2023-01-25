using UnityEngine;

public class Notifications : MonoBehaviour
{
    void Start()
    {
        //Notifications
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);


        var notification = new AndroidNotification();
        notification.Title = "Earth need a hero";
        notification.Text = "Come! back and defense the earth";
        notification.FireTime = System.DateTime.Now.AddMinutes(1);//Time to to show a Notifications


        notification.SmallIcon = "Small";
        notification.LargeIcon = "Large";

        AndroidNotificationCenter.SendNotification(notification, "channel_id");

    }
}
