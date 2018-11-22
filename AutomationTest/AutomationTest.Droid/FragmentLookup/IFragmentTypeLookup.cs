using System;
namespace AutomationTest.Droid.FragmentLookup
{
    public interface IFragmentTypeLookup
    {
        bool TryGetFragmentType(Type viewModelType, out Type fragmentType);
    }
}