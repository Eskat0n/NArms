namespace NArms.AutoMapper
{
    using System.Collections.Generic;
    using global::AutoMapper;

    public static class MapExtensions
    {
        public static TDest MapTo<TDest>(this object source)
        {
            return (TDest) Mapper.Map(source, source.GetType(), typeof (TDest));
        }

        public static TDest MapTo<TSource, TDest>(this TSource source, TDest dest)
        {
            return Mapper.Map(source, dest);
        }

        public static IEnumerable<TDest> MapEachTo<TDest>(this IEnumerable<object> source)
        {
            return (IEnumerable<TDest>) Mapper.Map(source, source.GetType(), typeof (IEnumerable<TDest>));
        }
    }
}