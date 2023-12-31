using System;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class ButtonController : MonoBehaviour
{
   public Button myButton;

   private void Start()
   {
      DisableButton();
   }

   private void SetButtonInteractable(bool isInteractable)
   {
      myButton.interactable = isInteractable;
   }
   
   public void DisableButton()
   {
      SetButtonInteractable(false);
   }
   
   public void EnableButton()
   {
      SetButtonInteractable(true);
   }
}

