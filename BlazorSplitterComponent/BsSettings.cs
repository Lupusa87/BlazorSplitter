using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorSplitterComponent
{
    public class BsSettings
    {
        public int index { get; set; }


        public bool VerticalOrHorizontal { get; set; } = false;

        public double width { get; set; } = 5;
        public double height { get; set; } = 30;


        public string BgColor { get; set; } = "silver";


        public string GetStyle()
        {

            StringBuilder sb1 = new StringBuilder();

            sb1.Append("width:" + width + "px;height:" + height + "px;");

            if (!VerticalOrHorizontal)
            {
                sb1.Append("display:inline-block;");
            }

            //sb1.Append("background-color:red;");
            sb1.Append("background-color:" + BgColor + ";");


            if (VerticalOrHorizontal)
            {
                sb1.Append("cursor:s-resize;");
                //sb1.Append("cursor:col-resize;");
            }
            else
            {
                sb1.Append("cursor:w-resize;");
                //sb1.Append("cursor:col-resize;");
            }


            return sb1.ToString();

        }
    }
}
