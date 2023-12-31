using System;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class ButtonController : MonoBehaviour
{
   private Button button;

   private void Start()
   {
      button = GetComponent<Button>();
      DisableButton();
   }

   public void SetButtonInteractable(bool isInteractable)
   {
      button.interactable = isInteractable;
   }
   
   private void DisableButton()
   {
      SetButtonInteractable(false);
   }
   
   private void EnableButton()
   {
      SetButtonInteractable(true);
   }
}

