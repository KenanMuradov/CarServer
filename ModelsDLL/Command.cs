using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDLL;

public class Command
{
    public HttpMethods Method { get; set; }
    public Car? Car { get; set; }
}
