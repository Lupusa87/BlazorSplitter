using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSplitterComponent
{
    public static class BsJsInterop
    {
        public static Task<bool> Alert(string msg)
        {

            return JSRuntime.Current.InvokeAsync<bool>(
                "BsJsFunctions.alertmsg", msg);
        }
        public static Task<bool> HandleDrag(string elementID, DotNetObjectRef dotnetHelper)
        {

            return JSRuntime.Current.InvokeAsync<bool>(
                "BsJsFunctions.handleDrag", elementID, dotnetHelper);
        }

        public static Task<bool> UnHandleDrag(string elementID)
        {

            return JSRuntime.Current.InvokeAsync<bool>(
                "BsJsFunctions.unHandleDrag", elementID);
        }

        public static Task<bool> StopDrag(string elementID)
        {

            return JSRuntime.Current.InvokeAsync<bool>(
                "BsJsFunctions.stopDrag", elementID);
        }


    }
}
