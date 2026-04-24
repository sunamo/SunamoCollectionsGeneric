namespace SunamoCollectionsGeneric._sunamo.SunamoExceptions;

internal partial class ThrowEx
{
    internal static bool ArgumentOutOfRangeException(string parameterName, string message = "")
    {
        return ThrowIsNotNull(Exceptions.ArgumentOutOfRangeException(FullNameOfExecutedCode(), parameterName, message));
    }

    internal static bool NotImplementedMethod()
    {
        return ThrowIsNotNull(Exceptions.NotImplementedMethod);
    }

    #region Other
    internal static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> placeOfException = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(placeOfException.Item1, placeOfException.Item2, true);
        return fullName;
    }

    static string FullNameOfExecutedCode(object type, string methodName, bool isFromThrowEx = false)
    {
        if (methodName == null)
        {
            int frameDepth = 2;
            if (isFromThrowEx)
            {
                frameDepth++;
            }

            methodName = Exceptions.CallingMethod(frameDepth);
        }
        string typeFullName;
        if (type is Type specificType)
        {
            typeFullName = specificType.FullName ?? "Type could not be retrieved when type is Type";
        }
        else if (type is MethodBase methodBase)
        {
            typeFullName = methodBase.ReflectedType?.FullName ?? "Type could not be retrieved when type is MethodBase";
            methodName = methodBase.Name;
        }
        else if (type is string)
        {
            typeFullName = type.ToString() ?? "Type could not be retrieved when type is string";
        }
        else
        {
            Type objectType = type.GetType();
            typeFullName = objectType.FullName ?? "Type could not be retrieved via type.GetType()";
        }
        return string.Concat(typeFullName, ".", methodName);
    }

    internal static bool ThrowIsNotNull(string? exceptionMessage, bool isReallyThrowing = true)
    {
        if (exceptionMessage != null)
        {
            Debugger.Break();
            if (isReallyThrowing)
            {
                throw new Exception(exceptionMessage);
            }
            return true;
        }
        return false;
    }

    #region For avoid FullNameOfExecutedCode
    internal static bool ThrowIsNotNull(Func<string, string?> exceptionFactory)
    {
        string? exceptionMessage = exceptionFactory(FullNameOfExecutedCode());
        return ThrowIsNotNull(exceptionMessage);
    }
    #endregion
    #endregion
}