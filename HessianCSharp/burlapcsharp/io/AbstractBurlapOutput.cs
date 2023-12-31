/*
***************************************************************************************************** 
* HessianCharp - The .Net implementation of the Hessian Binary Web Service Protocol (www.caucho.com) 
* Copyright (C) 2004-2005  by D. Minich, V. Byelyenkiy, A. Voltmann
* http://www.hessiancsharp.org
*
* This library is free software; you can redistribute it and/or
* modify it under the terms of the GNU Lesser General Public
* License as published by the Free Software Foundation; either
* version 2.1 of the License, or (at your option) any later version.
*
* This library is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
* Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public
* License along with this library; if not, write to the Free Software
* Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
* 
* You can find the GNU Lesser General Public here
* http://www.gnu.org/licenses/lgpl.html
* or in the license.txt file in your source directory.
******************************************************************************************************  
* You can find all contact information on http://www.hessiancsharp.org
******************************************************************************************************
*
*
******************************************************************************************************
* Last change: 2005-12-25
* 2005-12-25 initial class definition by Dimitri Minich.
* ....
******************************************************************************************************
*/
#region NAMESPACES
using System;
using hessiancsharp.io;
#endregion

namespace burlapcsharp.io
{
    /// <summary>
    /// Abstract output stream for Burlap requests.    
    /// <code>
    /// OutputStream os = ...; // from http connection
    /// AbstractBurlapOutput out = new BurlapOutput(os);
    /// string value;    
    /// out.StartCall("hello");  // start hello call
    /// out.WriteString("arg1"); // write a string argument
    /// out.CompleteCall();      // complete the call
    /// </code>
    /// </summary>
    public abstract class AbstractBurlapOutput : AbstractHessianOutput
    {
    }
}
