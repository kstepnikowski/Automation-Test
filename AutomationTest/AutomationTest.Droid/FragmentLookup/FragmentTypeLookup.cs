using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platform.IoC;

namespace AutomationTest.Droid.FragmentLookup
{
    public class FragmentTypeLookup : IFragmentTypeLookup
    {
        private readonly IDictionary<string, Type> _fragmentLookup = new Dictionary<string, Type>();

        public FragmentTypeLookup()
        {
            _fragmentLookup =
                (from type in GetType().Assembly.ExceptionSafeGetTypes()
                    where !type.IsAbstract
                          && !type.IsInterface
                          && typeof(MvxFragment).IsAssignableFrom(type)
                          && type.Name.EndsWith("View")
                    select type).ToDictionary(GetStrippedName);
        }

        public bool TryGetFragmentType(Type viewModelType, out Type fragmentType)
        {
            var strippedName = GetStrippedName(viewModelType);

            if (!_fragmentLookup.ContainsKey(strippedName))
            {
                fragmentType = null;

                return false;
            }

            fragmentType = _fragmentLookup[strippedName];

            return true;
        }

        private string GetStrippedName(Type type)
        {
            return type.Name
                .TrimEnd("View".ToCharArray())
                .TrimEnd("ViewModel".ToCharArray());
        }
    }
}