
scrollObj={interval:0,count:0,duration:0,step:0,srcObj:null,callback:null};
scrollObj.doit=function(obj,b,c,d){
	Machine.OnScrolling = true ;
	var s=scrollObj;
	obj.style.marginTop=calculate(s.count,b,c,d)+'px';
	s.count++;
	if(s.count==d){
		clearInterval(s.interval);
		s.count=0;
		obj.style.marginTop=b+c+'px';
		s.callback();
		Machine.OnScrolling = false ;
	}
	function calculate(t,b,c,d) {return c*((t=t/d-1)*t*t+1)+b;};
}


var Machine={
	current:0,
	next:0,
	scrollInterval:0,
	autoScroller:0,
	s:{},
	OnScrolling:false
};

Machine.turn=function(index,obj){
	if (Machine.OnScrolling) {
		return false ;
	}
	clearInterval(Machine.autoScroller);
	Machine.scroll(index,obj);
}
Machine.scroll=function(index,obj){
	
	var count=0;
	var step=obj.step;
	var duration=16;
	var b=Machine;
	b.next=index;
	if(index!=b.current&&count>duration/8){
		return;
	}
	try { clearInterval(Machine.s.interval);}catch(e){}
	
	var span=-index+b.current;
	Machine.s.duration=duration;
	Machine.s.callback=cb;
	var beign = parseInt(document.getElementById(obj.container).style.marginTop)||0 ;

	Machine.s.interval=setInterval(function(){Machine.s.doit(document.getElementById(obj.container),beign,step*span,duration)},10);

	function cb() {
		Machine.current=index;
		//something callback here

	}
}
Machine.auto=function(obj){
	clearInterval(Machine.autoScroller);
	Machine.autoScroller=setInterval(function(){
		Machine.scroll(Machine.current==(obj.totalcount-1)?0:Machine.current+1,obj);
	},obj.autotimeintval);
}
Machine.pauseSwitch = function() {	
	clearTimeout(Machine.autoScroller);
}

Machine.init=function(obj){
    if(obj.totalcount<=1)
        return;

	Machine.s=scrollObj;
	document.getElementById(obj.container).onmouseover = new Function("Machine.pauseSwitch();") ;		
	document.getElementById(obj.container).onmouseout = new Function("Machine.auto("+obj.objname+");") ;	
	Machine.current=0;
	Machine.next=0;
	Machine.auto(obj);
}
