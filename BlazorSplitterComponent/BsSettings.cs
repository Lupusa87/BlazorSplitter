using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorSplitterComponent
{
    public class BsSettings
    {
        public int index { get; set; }

        public string ID { get; private set; }

        public bool VerticalOrHorizontal { get; set; } = false;

        public bool IsDiagonal { get; set; } = false;

        public double width { get; set; } = 5;
        public double height { get; set; } = 30;


        public string BgColor { get; set; } = "silver";


        public BsSettings(string ScrollBarID = "Splitter")
        {
            if (string.IsNullOrEmpty(ScrollBarID))
            {
                ID = ScrollBarID + Guid.NewGuid().ToString("d").Substring(1, 4);
            }
            else
            {
                ID = "Splitter" + Guid.NewGuid().ToString("d").Substring(1, 4);
            }
        }

        internal string GetStyle()
        {

            StringBuilder sb1 = new StringBuilder();

            sb1.Append("width:" + width + "px;height:" + height + "px;");

            if (!VerticalOrHorizontal)
            {
                sb1.Append("display:inline-block;");
            }

            //sb1.Append("background-color:red;");
            sb1.Append("background-color:" + BgColor + ";");

            if (IsDiagonal)
            {
                sb1.Append("cursor:nwse-resize;");
            }
            else
            {
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
            }


            return sb1.ToString();

        }
    }
}
