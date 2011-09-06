namespace NArms.Gunbarrel.Implementation
{
    public interface IFunctionHandler<out TRet, in T1, in T2>
    {
        TRet Execute(T1 arg1, T2 arg2);
    }
}