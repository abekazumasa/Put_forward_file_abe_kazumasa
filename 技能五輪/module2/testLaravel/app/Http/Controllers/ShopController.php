<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Shop;
use Validator;
class ShopController extends Controller
{
	//店舗の一覧を獲得します
    public function index(Request $request){
    	$shops = Shop::select();

    	$price_range_sort = $request->input("price_range_sort",null);
    	if(!is_null($price_range_sort)){
    		if($price_range_sort){
    			$shops = $shops->orderBy("price_range","asc");
    		}else{
    			$shops = $shops->orderBy("price_range","desc");
    		}
    	}
    	$opening_only = $request->input("opening_only",null);
    	if(!is_null($opening_only)){
    		if($opening_only){
    			$shops = $shops->where("opening_time","<=",date("H:i"))->where("closing_time",">=",date("H:i"));
    		}
    	}
    	return response($shops->get(),200);
    }
    //店舗の詳細を獲得します
    public function show($shop_id){
    	$shops = Shop::with('items')->find($shop_id);
    	if(is_null($shops)){
    		return response(["messgae"=>"Not Funod"],404);
    	}
    	 $shops = Shop::with(['items'=>function($q){
    	  	$q->select("id","photo","name","description","price");
    	  }])->find($shop_id);

    	return response($shops,200);
    }
    //店舗の編集をします
    public function update(Request $request ,$shop_id){
    	$shops = Shop::find($shop_id);
    	if(is_null($shops)){
    		return response(['message'=>'Not Found'],404);
    	}
    	$validated = Validator::make($request->all(),[
    		"photo" =>"url",
  			"name" =>"unique:App\Models\Shop|max:255",
  			"opening_time"=>"date_format:H:i",
  			"closing_time" =>"date_format:H:i|after:opening_time",
  			"price_range"=>"integer|min:1",
    	]);
    	if($validated->fails()){
    		return response(['message'=>'Bad Request'],400);
    	}
    	$shops->fill($request->all())->save();
    	return response(null,204);
    }
}
