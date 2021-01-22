Vue.component("shop-content", {
	template: `
		<section class="section-block">
		<h2 class="section-heading">商店一覧</h2>
			<div v-if="list">
				<div class="shop-content" v-for="shop in list">
					<h3 class="shop-name">{{shop.name}}</h3>
					<div class="shop-photo"><img :src="shop.photo" :alt="shop.name"></div>
					<div class="clear-fix"></div>
					<p class="show-shop-modal-btn" @click="onClickPhoto(shop.id)">詳細を表示</p>
					<p class="show-order-modal-btn" @click="showOrderModal(shop.id)">注文</p>
				</div>
			</div>
			<div v-else><p>ロード中...</p></div>
			<transition>
			<div class="modal" v-if="detail">
				<div class="inner-modal">
					<div class="modal-close" @click="closeModal"><i class="fas fa-times"></i></div>
					<h3 class="shop-name">{{detail.name}}</h3>
					<div class="shop-photo-modal"><img :src="detail.photo" :alt="detail.name"></div>
					<p>営業時間：{{detail.opening_time}}～{{detail.closing_time}}</p>
					<p>価格帯：{{detail.price_range}}円</p>
					<div v-for="item in detail.items">
						<h4 class="item-heading">{{item.name}}</h4>
						<div class="item-photo-modal"><img :src="item.photo" :alt="item.name"></div>
						<p>{{item.description}}</p>
						<p>価格：{{item.price}}円</p>
					</div>
				</div>
			</div>
			</transition>
			<div class="modal" v-if="orderDtail">
				<div class="inner-modal">
					<div class="modal-close" @click="closeOrderModal"><i class="fas fa-times"></i></div>
					<div class="order-list"  v-for="(item,index) in orderDtail.items">
						<h4 class="item-heading">{{item.name}}</h4>
						<div class="item-photo-modal"><img :src="item.photo" :alt="item.name"></div>
						<p>{{item.description}}</p>
						<p>価格：{{item.price}}円</p>
						<p>数量：<input type="number" step="1" v-model.number="orderList[index].quantity"></p>
					</div>
					<button class="next-btn"　@click="nextBtn">次へ</button>
					<div class="input-modal">
					<p>合計:{{num2}}円</p>
					<p>名前:<input type="text"></p>
					<p>電話番号:<input type="number"></p>
					<p>郵便番号:<input type="number"></p>
					<p>住所:<input type="text"></p>
					<button class="remove-btn" @click="removeBtn">戻る</button>
					<button class="submit-btn" @click="orderSubmit(orderDtail.id)" :disabled="isSubmit">注文する</button>
					</div>
				</div>
			</div>
		</section>
	`,
	data: function() {
		return {
			list: null,
			detail: null,
			orderDtail:null,
			orderList:[],
			isSubmit:false,
			num2:0,
		};
	},
	methods: {
		onClickPhoto: function(id) {
			var self = this;
			$.ajax({
				type: "GET",
				url: "http://localhost/api2020-test/shops/" + id,
			}).then(function(data) {
				self.detail = data;
			});
		},
		removeBtn: function(){
			$(".next-btn").show();
			$(".input-modal").fadeOut( function(){
				$(".order-list").fadeIn();
			});
		},
		nextBtn: function(){
			var self = this;
			$(".next-btn").hide();
			$(".order-list").fadeOut( function(){
				$(".input-modal").fadeIn();
			});
			var num;
			for (var i = 0; i < this.orderList.length; i++) {
				if(this.orderList[i].quantity>0){
					this.num = this.orderList[i].quantity*this.orderDtail.items[i].price;
					this.num2 += this.num;
				}
			}
		},	
		showOrderModal: function(id) {
			var self = this;
			$.ajax({
				type: "GET",
				url: "http://localhost/api2020-test/shops/" + id,
			}).then(function(data) {
				self.orderDtail = data;
				for (var i =0; i < data.items.length; i++) {
					self.orderList.push({
						id: data.items[i].id,
						quantity:null,
					});
				}
			});
		},
		closeModal: function() {
			this.detail = null;
		},
		closeOrderModal: function() {
			this.orderDtail = null;
			this.orderList = [];
		},
		orderSubmit:function(id){
			var requestItems =[];
			for (var i = 0; i < this.orderList.length; i++) {
				if(this.orderList[i].quantity>0){
					requestItems.push(this.orderList[i]);
				}
			}
			if(requestItems.length<1){
				alert("最低一つは数量を入れてください");
				return;
			}
			console.log(requestItems,"requestItems");
			var requestJson = {
				"id":id,
				"items":requestItems,
			};
			var result = confirm("注文を確定しますか？");
			if(!result){
				return;
			}
			var self = this;
			this.isSubmit = true;
			setTimeout(function(){
			$.ajax({
				type:"POST",
				url:"http://localhost/api2020-test/order/" + id,
				data: JSON.stringify(requestJson),
				dataType:"json",
			})
			.then(function(){
				alert("注文が確定しました");
				self.closeOrderModal();
				self.isSubmit = false;
			}).catch(function(){
				alert("注文失敗しました。もう一度やり直して下さい");
				self.isSubmit = false;
			});
			},3000);
		},
	},
	created: function() {
		var self = this;
		$.ajax({
			method: "GET",
			url: "http://localhost/api2020-test/shops",
		})
		.then(function(data) {
			self.list = data;
		});
	},
});