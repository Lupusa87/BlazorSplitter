using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSplitterComponent
{
    internal static class BsJsInterop
    {
        internal static Task<bool> Alert(string msg)
        {

            return JSRuntime.Current.InvokeAsync<bool>(
                "BsJsFunctions.alertmsg", msg);
        }
        internal static Task<bool> HandleDrag(string elementID, DotNetObjectRef dotnetHelper)
        {

            return JSRuntime.Current.InvokeAsync<bool>(
                "BsJsFunctions.handleDrag", elementID, dotnetHelper);
        }

        internal static Task<bool> UnHandleDrag(string elementID)
        {

            return JSRuntime.Current.InvokeAsync<bool>(
                "BsJsFunctions.unHandleDrag", elementID);
        }

        internal static Task<bool> StopDrag(string elementID)
        {

            return JSRuntime.Current.InvokeAsync<bool>(
                "BsJsFunctions.stopDrag", elementID);
        }


    }
}
