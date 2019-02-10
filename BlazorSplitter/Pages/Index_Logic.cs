using BlazorSplitterComponent;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSplitter.Pages
{
    public class Index_Logic:ComponentBase
    {
        public CompBlazorSplitter CompBlazorSplitter1;
        public CompBlazorSplitter CompBlazorSplitter2;

        public int P1 = 0;
        public int P2 = 0;

        public BsSettings bsSettings1 { get; set; } = new BsSettings();

        public BsSettings bsSettings2 { get; set; } = new BsSettings();

        protected override void OnInit()
        {

            bsSettings1 = new BsSettings
            {
                width = 8,
                height = 40,
                BgColor = "lightgray",
            };

            bsSettings2 = new BsSettings
            {
                width = 8,
                height = 40,
                BgColor = "lightgreen",
            };



            base.OnInit();
        }


        protected override void OnAfterRender()
        {
            CompBlazorSplitter1.OnPositionChange += OnPositionChange1;
            CompBlazorSplitter2.OnPositionChange += OnPositionChange2;

            base.OnAfterRender();
        }


        private void OnPositionChange1(int p)
        {
            P1 = p;
            StateHasChanged();
        }

        private void OnPositionChange2(int p)
        {
            P2 = p;
            StateHasChanged();
        }
    }
}
