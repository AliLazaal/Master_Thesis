using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Tool_for_ENNA_.Enums
{
  
    public enum Function
        {
            
            /// <summary>
            /// For Dataset Issues 
            /// </summary>
            Datasets = 0x01,

            /// <summary>
            /// For Adaption Issues
            /// </summary>
            Adaption = 0x02,

            /// <summary>
            /// For Unkown Issues
            /// </summary>
            Unkown = 0x03,

            /// <summary>
            /// For DTC Issues
            /// </summary>
            DTCs = 0x04,

            /// <summary>
            /// For Routine Issues
            /// </summary>
            Routines = 0x05,

            /// <summary>
            /// For KSD Issues
            /// </summary>
            KSD = 0x06,

            /// <summary>
            /// For Identificaiton Issues
            /// </summary>
            Identification = 0x07,

            /// <summary>
            /// For Measurement Issues 
            /// </summary>
            Measurements = 0x08,



        
    }
}
