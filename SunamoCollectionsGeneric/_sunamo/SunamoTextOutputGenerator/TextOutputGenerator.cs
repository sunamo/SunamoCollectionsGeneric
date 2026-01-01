namespace SunamoCollectionsGeneric._sunamo.SunamoTextOutputGenerator;

/// <summary>
///     In Comparingresharper how to remove dead code in defined folder
/// </summary>
internal class TextOutputGenerator //: ITextOutputGenerator
{
    // při převádění na nugety jsem to změnil na ITextBuilder Builder = TextBuilder.Create();
    // ale asi to byla blbost, teď mám v _sunamo Create() která je ale null místo abych použil ctor
    // takže vracím nazpět.
    //internal TextBuilder Builder = new TextBuilder();
    internal StringBuilder Builder = new();

    //internal string prependEveryNoWhite
    //{
    //    get => stringBuilder.prependEveryNoWhite;
    //    set => stringBuilder.prependEveryNoWhite = value;
    //}

    public override string ToString()
    {
        var ts = Builder.ToString();
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
        Builder.Append(text);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void AppendLine(string text)
    {
        Builder.AppendLine(text);
    }



    #endregion

    #region Other adding methods



    #endregion

    #region List




    internal void List<TValue>(IList<TValue> items, string delimiter = "\r\n", string whenNoEntries = "")
    {
        if (items.Count() == 0)
            Builder.AppendLine(whenNoEntries);
        else
            foreach (var item in items)
                Append(item + delimiter);
        //Builder.AppendLine();
    }


    internal void List(IList<string> items, string header)
    {
        List(items, header, new TextOutputGeneratorArgs { IsHeaderWrappedEmptyLines = true, ShouldInsertCount = false });
    }


    /// <summary>
    ///     Use DictionaryHelper.CategoryParser
    /// </summary>
    /// <typeparam name="THeader"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="items"></param>
    /// <param name="header"></param>
    /// <param name="args"></param>
    internal void List<THeader, TValue>(IList<TValue> items, THeader header, TextOutputGeneratorArgs args)
        where THeader : IEnumerable<char>
    {
        if (args.ShouldInsertCount)
        {
            //throw new Exception("later");
            //header = (THeader)((IList<char>)CA.JoinIList<char>(header, " (" + items.Count() + ")"));
        }

        if (args.IsHeaderWrappedEmptyLines) Builder.AppendLine();
        Builder.AppendLine(header + ":");
        if (args.IsHeaderWrappedEmptyLines) Builder.AppendLine();
        List(items, args.Delimiter, args.WhenNoEntries);
    }

    #endregion

    #region Paragraph


    
    #endregion

    #region Dictionary







    #endregion
}