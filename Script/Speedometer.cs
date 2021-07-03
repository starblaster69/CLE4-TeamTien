using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Speedometer : MonoBehaviour
{
   public Rigidbody target;

   public float maxSpeed = 0.0f; // the maximum speed of the target in km/h

   public float minSpeedArrowAngle;
   public float maxSpeedArrowAngle;

   [Header("UI")]
   public TMP_Text speedLabel; // the label that displays the speed
   public RectTransform arrow; //the arrow in the speedometer

   private float speed = 0.0f;
   private void Update()
   {
       // 3.6f to convert to kilometers
       // ** the speed must be clamped by the controller **
       speed = target.velocity.magnitude * 3.6f;

        if (speedLabel != null)
            speedLabel.text = ((int)speed) + " km/uur";
        if (arrow != null)
            arrow.localEulerAngles = 
                new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
   }
}
