using System;

namespace AutomationTest.Core.PlatformServices
{
    public interface IPopupService
    {
        void ShowMessage(string message);
        void Show(string title, string message, string firstButtonText, Action firstButtonAction, string secondButtonText, Action secondButtonAction);
    }
}