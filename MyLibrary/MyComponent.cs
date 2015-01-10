using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary {
    public partial class MyComponent : Component {

        private String text;

        public String Text {
            get { return text; }
            set { text = value; }
        }

        public MyComponent(IContainer container) {
            container.Add(this);

            InitializeComponent();
            text = "tekst z komponentu";
        }

        public string dajMiText(){
            return this.text;
        }
    }
}
