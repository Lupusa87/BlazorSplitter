using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorSplitterComponent
{
    public class BsSettings
    {

        public double width { get; set; } = 15;
        public double height { get; set; } = 200;


        public string BgColor { get; set; } = "silver";


        public string GetStyle()
        {

            StringBuilder sb1 = new StringBuilder();

            sb1.Append("width:" + width + "px;height:" + height + "px;");

            sb1.Append("display:inline-block;");
            sb1.Append("background-color:" + BgColor + ";");

            //sb1.Append("cursor:w-resize;");
            sb1.Append("cursor:col-resize;");

            return sb1.ToString();

        }
    }
}
