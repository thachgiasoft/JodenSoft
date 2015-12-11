function getPageScroll(){ 
            var yScroll; 
            if (self.pageYOffset) { 
                yScroll = self.pageYOffset; 
            } else if (document.documentElement && document.documentElement.scrollTop){ // Explorer 6 Strict 
                yScroll = document.documentElement.scrollTop; 
            } else if (document.body) {// all other Explorers 
                yScroll = document.body.scrollTop; 
            } 

            arrayPageScroll = new Array('',yScroll) 
            return arrayPageScroll; 
        } 

        function getPageSize(){ 
            var xScroll, yScroll; 
            if (window.innerHeight && window.scrollMaxY) { 
                xScroll = document.body.scrollWidth; 
                yScroll = window.innerHeight + window.scrollMaxY; 
            } else if (document.body.scrollHeight > document.body.offsetHeight){ // all but Explorer Mac 
                xScroll = document.body.scrollWidth; 
                yScroll = document.body.scrollHeight; 
            } else { // Explorer Mac...would also work in Explorer 6 Strict, Mozilla and Safari 
                xScroll = document.body.offsetWidth; 
                yScroll = document.body.offsetHeight; 
            } 

            var windowWidth, windowHeight; 
            if (self.innerHeight) { // all except Explorer 
                windowWidth = self.innerWidth; 
                windowHeight = self.innerHeight; 
            } else if (document.documentElement && document.documentElement.clientHeight) { // Explorer 6 Strict Mode 
                windowWidth = document.documentElement.clientWidth; 
                windowHeight = document.documentElement.clientHeight; 
            } else if (document.body) { // other Explorers 
                windowWidth = document.body.clientWidth; 
                windowHeight = document.body.clientHeight; 
            } 

            // for small pages with total height less then height of the viewport 
            if(yScroll < windowHeight){ 
                pageHeight = windowHeight; 
            } else { 
                pageHeight = yScroll; 
            } 

            if(xScroll < windowWidth){ 
                pageWidth = windowWidth; 
            } else { 
                pageWidth = xScroll; 
            } 

            arrayPageSize = new Array(pageWidth,pageHeight,windowWidth,windowHeight) 
            return arrayPageSize; 
        } 

        function Calculate()
        {
	        var array=getPageSize();
            document.getElementById("txtWinHeight").value=array[3];
            
            var ie = (function(){      
                var undef,v = 3,div = document.createElement('div'),all = div.getElementsByTagName('i');         
                while (div.innerHTML = '<!--[if gt IE ' + (++v) + ']><i></i><![endif]-->', all[0]);         
                return v > 4 ? v : undef;      
                }()); 
            if(ie==undefined){
                ie=0;
            }
            
            //alert(ie);
            document.getElementById("txtIEVersion").value=ie;
        }

Calculate();