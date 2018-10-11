using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFA.Domain.Models
{
    public class OperationResult
    {
        public OperationResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; private set; }
        public Exception Error { get; set; }
    }

    public class OperationResult<TEntity> : OperationResult
    {
        public OperationResult(bool isSuccess) : base(isSuccess) { }
        public TEntity Entity { get; set; }
    }


}
