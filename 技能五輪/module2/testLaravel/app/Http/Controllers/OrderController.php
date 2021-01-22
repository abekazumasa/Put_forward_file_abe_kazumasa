<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Order;
use App\Models\Shop;
use Validator;

class OrderController extends Controller
{
	//オーダーリストを追加します
    public function store(Request $request,$shop_id){
    	$shops = Shop::find($shop_id);
    	if(is_null($shops)){
    		return response(['message'=>'Not Found'],404);
    	}
    	   $validated = Validator::make($request->all(),[
    	    	 "name"=> "required|unique:App\Models\Order",
  			  "number"=> "required|digits_between:0,40|numeric",
  			   "zip_code"=> "required|digits_between:1,12",
  			  "address"=> "required|string",
    	  ]);
    	  if($validated->fails()){
    	  	return response(['message'=>'Bad Request'],400);
    	  }
    	foreach ($request->items as $item) {
    		$orders = new Order($request->all());
    		$orders->shop_id = $shop_id;
    		$orders->item_id = $item['id'];
    		$orders->quantity = $item['quantity'];
    		$orders->save();
    	}
    	return response(['id'=>$orders->id],201);
    }
}
