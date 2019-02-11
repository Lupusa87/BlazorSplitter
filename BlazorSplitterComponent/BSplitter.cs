using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlazorSplitterComponent
{
    public class BSplitter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string ID { get; set; } = "BSplitter" + Guid.NewGuid().ToString("d").Substring(1, 4);

        public BsSettings bsbSettings { get; set; }


        public int PreviousPosition { get; set; } = 0;
        public int PreviousPosition2 { get; set; } = 0;
        
        public int Position { get; set; } = 0;

        public int Step { get; set; } = 0;


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InvokePropertyChanged()
        {
            PropertyChanged?.Invoke(this, null);
        }

    }
}
