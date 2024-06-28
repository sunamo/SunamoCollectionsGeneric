namespace SunamoCollectionsGeneric;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal interface IIdentificatorT<T>
{
    T Id { get; set; }
    bool IsChecked { get; set; }
    bool IsSelected { get; set; }
}