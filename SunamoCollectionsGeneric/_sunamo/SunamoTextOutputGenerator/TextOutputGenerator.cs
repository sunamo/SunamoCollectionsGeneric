// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoCollectionsGeneric._sunamo.SunamoTextOutputGenerator;

/// <summary>
///     In Comparingresharper how to remove dead code in defined folder
/// </summary>
internal class TextOutputGenerator //: ITextOutputGenerator
{
    private static readonly string s_znakNadpisu = "*";

    // při převádění na nugety jsem to změnil na ITextBuilder stringBuilder = TextBuilder.Create();
    // ale asi to byla blbost, teď mám v _sunamo Create() která je ale null místo abych použil ctor
    // takže vracím nazpět.
    //internal TextBuilder stringBuilder = new TextBuilder();
    internal StringBuilder stringBuilder = new();

    //internal string prependEveryNoWhite
    //{
    //    get => stringBuilder.prependEveryNoWhite;
    //    set => stringBuilder.prependEveryNoWhite = value;
    //}

    public override string ToString()
    {
        var ts = stringBuilder.ToString();
        return ts;
    }


    #region Static texts



    #endregion

    #region Templates



    #endregion

    #region AppendLine



    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void Append(string text)
    {
        stringBuilder.Append(text);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void AppendLine(string text)
    {
        stringBuilder.AppendLine(text);
    }



    #endregion

    #region Other adding methods



    #endregion

    #region List



    
    internal void List<Value>(IList<Value> files1, string deli = "\r\n", string whenNoEntries = "")
    {
        if (files1.Count() == 0)
            stringBuilder.AppendLine(whenNoEntries);
        else
            foreach (var item in files1)
                Append(item + deli);
        //stringBuilder.AppendLine();
    }

    
    internal void List(IList<string> files1, string header)
    {
        List(files1, header, new TextOutputGeneratorArgs { headerWrappedEmptyLines = true, insertCount = false });
    }


    /// <summary>
    ///     Use DictionaryHelper.CategoryParser
    /// </summary>
    /// <typeparam name="Header"></typeparam>
    /// <typeparam name="Value"></typeparam>
    /// <param name="files1"></param>
    /// <param name="header"></param>
    /// <param name="a"></param>
    internal void List<Header, Value>(IList<Value> files1, Header header, TextOutputGeneratorArgs a)
        where Header : IEnumerable<char>
    {
        if (a.insertCount)
        {
            //throw new Exception("later");
            //header = (Header)((IList<char>)CA.JoinIList<char>(header, " (" + files1.Count() + ")"));
        }

        if (a.headerWrappedEmptyLines) stringBuilder.AppendLine();
        stringBuilder.AppendLine(header + ":");
        if (a.headerWrappedEmptyLines) stringBuilder.AppendLine();
        List(files1, a.delimiter, a.whenNoEntries);
    }

    #endregion

    #region Paragraph


    
    #endregion

    #region Dictionary







    #endregion
}