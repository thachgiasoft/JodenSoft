using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;

namespace SAF.EntityFramework.SqlGenerators
{
    public static class DefaultValues
    {
        public const string UserId = ":UserId";
        public const string UserName = ":UserName";
        public const string UserFullName = ":UserFullName";

        public const string GetDate = ":GetDate()";
    }

    public static class DefaultValueHelper
    {
        public static bool IsPredefined(object value)
        {
            return value != null && value.ToString().In(DefaultValues.UserId, DefaultValues.UserName, DefaultValues.UserFullName, DefaultValues.GetDate);
        }

        public static object GetValue(object value)
        {
            if (value == null)
                return "null";
            switch (value.ToStringEx())
            {
                case DefaultValues.UserId:
                    return "{0}".FormatWith(Session.UserInfo.UserId);
                case DefaultValues.UserName:
                    return "'{0}'".FormatWith(Session.UserInfo.UserName);
                case DefaultValues.UserFullName:
                    return "'{0}'".FormatWith(Session.UserInfo.UserFullName);
                case DefaultValues.GetDate:
                    return "GETDATE()";
                default:
                    return "'{0}'".FormatWith(value);
            }
        }
    }
}
