using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToggleExclusiveModeGUI
{
    public class AdvOptionsArrays
    {
        public string[] GenerateLatBuffArray()
        {
            string[] latBuffOptions = { "1", "2", "3", "4" };
            return latBuffOptions;
        }
        public string[] GenerateUltraLowLatArray()
        {
            string[] ultraLowLatency = { "0", "1" };
            return ultraLowLatency;
        }
        public string[] GenerateMaxBufferSizeArray()
        {
            string[] maxBufferSize = { "0", "256", "512", "1024", "2056" };
            return maxBufferSize;
        }
    }
}
