using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace RealEstate.HtmlHelpers
{
    public class LocalizedDisplayNameAttribute : DisplayNameAttribute //DisplayNameAttribute teki özellikleri kullanabilmek için inherite ettik
    {
        PropertyInfo _nameProperty;
        Type _resorceType;
        public string _displayName { get; set; }

        public LocalizedDisplayNameAttribute(string displayNameKey) : base(displayNameKey)
        {
            _displayName = displayNameKey;
        }

        public Type NameResourceType
        {
            get
            {
                return _resorceType;
            }
            set
            {
                _resorceType = value;
                _nameProperty = _resorceType.GetProperty(_displayName, BindingFlags.Static | BindingFlags.NonPublic);

            }
        }
        public override string DisplayName
        {
            get
            {
                if (_nameProperty==null)
                {
                    return base.DisplayName;
                }
                return (string)_nameProperty.GetValue(_nameProperty.DeclaringType, null);
            }
        }
    }
}