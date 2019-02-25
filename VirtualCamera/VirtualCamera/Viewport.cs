using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualCamera
{
    class Viewport
    {
        public Viewport(double perspective_coe)
        {
            this.perspective_coe = perspective_coe;
        }

        public double perspective_coe { get; set; }
    }
}
