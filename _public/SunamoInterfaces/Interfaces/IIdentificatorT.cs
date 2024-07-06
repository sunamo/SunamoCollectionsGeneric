namespace SunamoCollectionsGeneric._public.SunamoInterfaces.Interfaces;


public interface IIdentificatorT<T>
{
    T Id { get; set; }
    bool IsChecked { get; set; }
    bool IsSelected { get; set; }
}
