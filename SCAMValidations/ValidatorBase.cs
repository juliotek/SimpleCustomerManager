using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAMValidations
{
    public class ValidatorBase
    {
        protected Lazy<List<string>> _errors;
        public ValidatorBase()
        {
            _errors = new Lazy<List<string>>(() => new List<string>());
        }
        public List<string> errors { get { return _errors.Value; } }
    }
}
