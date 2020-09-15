using System;
using InputOutputHandler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{   
    class Sender
    {
        IInputHandler InputHandler;
        IOutputHandler OutputHandler;
        public Sender(IInputHandler TargetInputParameter, IOutputHandler TargetOutputParameter)
        {
            InputHandler = TargetInputParameter;
            OutputHandler = TargetOutputParameter;
        }

        public List<string> ReadInputData()
        {
            return InputHandler.ReadInput();
        }

        public void WriteOuptutData(List<string> OutputDataParameter)
        {
            OutputHandler.WriteOutput(OutputDataParameter);
        }
    }
}
