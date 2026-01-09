// variables names: ok
namespace SunamoCollectionsGeneric._sunamo.SunamoExceptions;

// © www.sunamo.cz. All Rights Reserved.
internal sealed partial class Exceptions
{
    #region Other
    internal static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

    internal static Tuple<string, string, string> PlaceOfException(
bool fillAlsoFirstTwo = true)
    {
        StackTrace st = new();
        var stackTraceText = st.ToString();
        var lines = stackTraceText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);
        var i = 0;
        string type = string.Empty;
        string methodName = string.Empty;
        for (; i < lines.Count; i++)
        {
            var item = lines[i];
            if (fillAlsoFirstTwo)
                if (!item.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(item, out type, out methodName);
                    fillAlsoFirstTwo = false;
                }
            if (item.StartsWith("at System."))
            {
                lines.Add(string.Empty);
                lines.Add(string.Empty);
                break;
            }
        }
        return new Tuple<string, string, string>(type, methodName, string.Join(Environment.NewLine, lines));
    }
    internal static void TypeAndMethodName(string stackTraceLine, out string type, out string methodName)
    {
        var methodCall = stackTraceLine.Split("at ")[1].Trim();
        var fullMethodName = methodCall.Split("(")[0];
        var methodParts = fullMethodName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = methodParts[^1];
        methodParts.RemoveAt(methodParts.Count - 1);
        type = string.Join(".", methodParts);
    }
    internal static string CallingMethod(int frameDepth = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(frameDepth)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }
    #endregion

    #region IsNullOrWhitespace
    internal readonly static StringBuilder AdditionalInfoInnerStringBuilder = new();
    internal readonly static StringBuilder AdditionalInfoStringBuilder = new();
    #endregion

    #region OnlyReturnString 
    internal static string? ArgumentOutOfRangeException(string before, string paramName, string message)
    {
        return CheckBefore(before) + $"{paramName} is out of range, another info: {message}";
    }
    internal static string? NotImplementedMethod(string before)
    {
        return CheckBefore(before) + "Not implemented method.";
    }
    #endregion
}