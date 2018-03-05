
namespace Сalculator.Operations
{
    public interface IOperation
    {
        char OperatorChar { get; }

        bool Run(params object[] args);
    }
}
