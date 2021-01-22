var app = new Vue({
	el: "#app",
	data:{
		oldCurrentPage:null,
		currentPage: "home",     
    	menuWidth: $('.header-nav').outerWidth(),
	},
	methods:{
		onClickHumb: function() {
			 $(document.body).toggleClass('open');
        	if( $(document.body).hasClass('open')){
            	$(document.body).stop().animate({'left' : this.menuWidth }, 300);     
            	$('.header-nav').stop().animate({'left' : 0 }, 300);                  
        	} else {
            	$('.header-nav').stop().animate({'left' : -this.menuWidth }, 300);
             	$(document.body).stop().animate({'left' : 0 }, 300);            
        	}             
		},
		onClickLink: function(page) {
			if(!$(document.body).hasClass('open')){
		 		$('.header-nav').animate({'left' : -this.menuWidth }, 300);
            	$(document.body).animate({'left' : 0 }, 300);                         
		 	}
			this.currentPage = page;
  		},
	},
});