//namespace SunamoCollectionsGeneric._sunamo;

//public class DictionaryHelper
//{
//    public static void AddOrPlus<T>(Dictionary<T, int> sl, T key, int p)
//    {
//        if (sl.ContainsKey(key))
//            sl[key] += p;
//        else
//            sl.Add(key, p);
//    }

//    public static void CopyTo<T, U>(List<KeyValuePair<T, U>> _d, KeyValuePair<T, U>[] array, int arrayIndex)
//    {
//        array = new KeyValuePair<T, U>[_d.Count - arrayIndex + 1];

//        int i = 0;
//        bool add = false;
//        foreach (var item in _d)
//        {
//            if (i == arrayIndex && !add)
//            {
//                add = true;
//                i = 0;
//            }

//            if (add)
//            {
//                array[i] = new KeyValuePair<T, U>(item.Key, item.Value);
//            }

//            i++;
//        }
//    }

//    public static Dictionary<T, U> ReturnsCopy<T, U>(Dictionary<T, U> slovnik)
//    {
//        Dictionary<T, U> tu = new Dictionary<T, U>();
//        foreach (KeyValuePair<T, U> item in slovnik)
//        {
//            tu.Add(item.Key, item.Value);
//        }

//        return tu;
//    }

//    public static void CopyTo<T, U>(Dictionary<T, U> _d, KeyValuePair<T, U>[] array, int arrayIndex)
//    {
//        array = new KeyValuePair<T, U>[_d.Count - arrayIndex + 1];

//        int i = 0;
//        bool add = false;
//        foreach (var item in _d)
//        {
//            if (i == arrayIndex && !add)
//            {
//                add = true;
//                i = 0;
//            }

//            if (add)
//            {
//                array[i] = new KeyValuePair<T, U>(item.Key, item.Value);
//            }

//            i++;
//        }
//    }
//}
